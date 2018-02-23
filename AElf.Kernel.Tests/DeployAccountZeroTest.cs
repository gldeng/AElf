using System;
using System.Reflection;
using AElf.Kernel.Extensions;
using AElf.Kernel.KernelAccount;
using Xunit;

namespace AElf.Kernel.Tests
{
    public class DeployAccountZeroTest
    {
        [Fact]
        public void DeployAccountZero()
        {
            var transactionInGenesisBlock = new Transaction {Params = new object[3]};
            transactionInGenesisBlock.Params[0] = 0;
            transactionInGenesisBlock.Params[1] = "SmartContractInitialization";
            
            // load assembly
            var path = @"/../../../Assembly/SimpleClass.dll";
            byte[] data = System.IO.File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + path);
            transactionInGenesisBlock.Params[2] = data;

            var genesisBlock = new GenesisBlock {Transaction = transactionInGenesisBlock};
            var worldState = new WorldState();
            var chain = new Chain(worldState, genesisBlock);
            
            // deployment
            Assert.True(chain.Initialize());
            // deployment only once
            Assert.False(chain.Initialize());
            
            Assert.Equal(chain.Blocks.Count, 1);
            
            const string smartContractMapKey = "SmartContractMap";
            var accountDataProvider = worldState.GetAccountDataProviderByAccount(chain.AccountZero);
           
            var serializable = accountDataProvider.GetDataProvider().GetDataProvider(smartContractMapKey)
                .GetAsync(new Hash<SmartContractRegistration>(accountDataProvider.CalculateHashWith("SmartContract")))
                .Result;
            
            // TODO: get SmartContractRegistration instance with deserilization
        }
    }
}