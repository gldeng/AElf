using System.IO;
using AElf.Contracts.ZkTreeVerifier;
using AElf.Cryptography.ECDSA;
using AElf.Kernel;
using AElf.Standards.ACS0;
using AElf.Types;
using Google.Protobuf;
using Volo.Abp.Threading;

namespace AElf.Contracts.ZkWasmVerifier;

public class ZkTreeVerifierTestBase : ContractTestKit.ContractTestBase<ZkTreeVerifierTestAElfModule>
{
    protected ECKeyPair DefaultKeyPair => Accounts[0].KeyPair;
    protected Address DefaultAddress => Accounts[0].Address;
    internal ACS0Container.ACS0Stub ZeroContractStub { get; set; }
    protected Address ZkWasmVerifierContractAddress { get; set; }

    internal ZkTreeVerifierContainer.ZkTreeVerifierStub ZkWasmVerifierStub { get; set; }

    protected ZkTreeVerifierTestBase()
    {
        // TokenContractStub = GetTokenContractTester(DefaultKeyPair);
        // TokenContractImplStub = GetTester<TokenContractImplContainer.TokenContractImplStub>(TokenContractAddress,
        //     DefaultKeyPair);
        ZeroContractStub = GetContractZeroTester(DefaultKeyPair);
        var result = AsyncHelper.RunSync(async () => await ZeroContractStub.DeploySmartContract.SendAsync(
            new ContractDeploymentInput
            {
                Category = KernelConstants.CodeCoverageRunnerCategory,
                Code = ByteString.CopyFrom(
                    File.ReadAllBytes(typeof(ZkTreeVerifier.ZkTreeVerifier).Assembly.Location)),
                ContractOperation = new ContractOperation
                {
                    Deployer = DefaultAddress
                }
            }));

        ZkWasmVerifierContractAddress = Address.Parser.ParseFrom(result.TransactionResult.ReturnValue);
        ZkWasmVerifierStub = GetZkWasmVerifierTester(DefaultKeyPair);
    }


    internal ZkTreeVerifierContainer.ZkTreeVerifierStub GetZkWasmVerifierTester(ECKeyPair keyPair)
    {
        return GetTester<ZkWasmVerifierContainer.ZkWasmVerifierStub>(ZkWasmVerifierContractAddress,
            keyPair);
    }

    // internal TokenContractImplContainer.TokenContractImplStub GetTokenContractTester(
    //     ECKeyPair keyPair)
    // {
    //     return GetTester<TokenContractImplContainer.TokenContractImplStub>(TokenContractAddress,
    //         keyPair);
    // }
    //
    internal ACS0Container.ACS0Stub GetContractZeroTester(
        ECKeyPair keyPair)
    {
        return GetTester<ACS0Container.ACS0Stub>(ContractZeroAddress, keyPair);
    }
}