﻿using System.Text.Json;
using AElf.Kernel;
using AElf.Kernel.SmartContract;
using AElf.Kernel.SmartContract.Infrastructure;
using AElf.Types;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using NBitcoin.DataEncoders;
using Solang;
using Solang.Extensions;
using Wasmtime;

namespace AElf.Runtime.WebAssembly;

public class Executive : IExecutive
{
    public IReadOnlyList<ServiceDescriptor> Descriptors { get; }
    public Hash ContractHash { get; set; }
    public Timestamp LastUsedTime { get; set; }
    public string ContractVersion { get; set; }

    private readonly WebAssemblyRuntime _webAssemblyRuntime;
    private readonly SolangABI _solangAbi;

    private IHostSmartContractBridgeContext _hostSmartContractBridgeContext;
    private ITransactionContext CurrentTransactionContext => _hostSmartContractBridgeContext.TransactionContext;

    public Executive(IExternalEnvironment ext, CompiledContract compiledContract)
    {
        var wasmCode = compiledContract.WasmCode.ToByteArray();
        _solangAbi = JsonSerializer.Deserialize<SolangABI>(compiledContract.Abi)!;
        _webAssemblyRuntime = new WebAssemblyRuntime(ext, wasmCode);
        ContractHash = HashHelper.ComputeFrom(wasmCode);
        ContractVersion = "Unknown solidity version.";
    }

    public IExecutive SetHostSmartContractBridgeContext(IHostSmartContractBridgeContext smartContractBridgeContext)
    {
        _hostSmartContractBridgeContext = smartContractBridgeContext;
        _webAssemblyRuntime.SetHostSmartContractBridgeContext(smartContractBridgeContext);
        return this;
    }

    public Task ApplyAsync(ITransactionContext transactionContext)
    {
        _hostSmartContractBridgeContext.TransactionContext = transactionContext;
        Execute();
        return Task.CompletedTask;
    }

    private void Execute()
    {
        var s = CurrentTransactionContext.Trace.StartTime = TimestampHelper.GetUtcNow().ToDateTime();

        var transactionContext = _hostSmartContractBridgeContext.TransactionContext;
        var transaction = transactionContext.Transaction;

        var isCallConstructor = transaction.MethodName == "deploy";

        if (isCallConstructor && (_hostSmartContractBridgeContext.Origin != null ||
                                  _hostSmartContractBridgeContext.Origin == _hostSmartContractBridgeContext.Sender))
        {
            transactionContext.Trace.ExecutionStatus = ExecutionStatus.Prefailed;
            transactionContext.Trace.Error = "Cannot execute constructor.";
            return;
        }

        var selector = _solangAbi.GetSelector(transaction.MethodName);
        var parameter = transaction.Params.ToHex();
        _webAssemblyRuntime.Input = Encoders.Hex.DecodeData(selector + parameter);
        var instance = _webAssemblyRuntime.Instantiate();
        var actionName = isCallConstructor ? "deploy" : "call";
        var action = instance.GetFunction<ActionResult>(actionName);
        if (action is null)
        {
            throw new WebAssemblyRuntimeException($"error: {actionName} export is missing");
        }

        var invokeResult = new RuntimeActionInvoker().Invoke(action);
        if (!invokeResult.Success)
        {
            _webAssemblyRuntime.DebugMessages.Add(invokeResult.DebugMessage);
        }

        if (_webAssemblyRuntime.DebugMessages.Count > 0)
        {
            transactionContext.Trace.ExecutionStatus = ExecutionStatus.ContractError;
            transactionContext.Trace.Error = _webAssemblyRuntime.DebugMessages.First();
        }
        else
        {
            transactionContext.Trace.ReturnValue = ByteString.CopyFrom(_webAssemblyRuntime.ReturnBuffer);
            transactionContext.Trace.ExecutionStatus = ExecutionStatus.Executed;
            foreach (var depositedEvent in _webAssemblyRuntime.Events)
            {
                transactionContext.Trace.Logs.Add(new LogEvent
                {
                    Address = transaction.To,
                    Name = depositedEvent.Item1.ToHex(),
                    NonIndexed = ByteString.CopyFrom(depositedEvent.Item2)
                });
            }
        }

        var changes = _webAssemblyRuntime.GetChanges();
        CurrentTransactionContext.Trace.StateSet = changes;

        var e = CurrentTransactionContext.Trace.EndTime = TimestampHelper.GetUtcNow().ToDateTime();
        CurrentTransactionContext.Trace.Elapsed = (e - s).Ticks;
    }

    public string GetJsonStringOfParameters(string methodName, byte[] paramsBytes)
    {
        throw new NotImplementedException();
    }

    public bool IsView(string methodName)
    {
        throw new NotImplementedException();
    }

    public byte[] GetFileDescriptorSet()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FileDescriptor> GetFileDescriptors()
    {
        throw new NotImplementedException();
    }
}