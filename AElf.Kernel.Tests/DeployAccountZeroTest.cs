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
            var category = 0;
            var name = "SmartContractInitialization";
            transactionInGenesisBlock.Params[0] = category;
            transactionInGenesisBlock.Params[1] = name;
            
            // load assembly
            var path = @"/../../../Assembly/SimpleClass.dll";
            var data = System.IO.File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + path);
            transactionInGenesisBlock.Params[2] = data;
            
            var genesisBlock = new GenesisBlock {Transaction = transactionInGenesisBlock};
            var worldState = new WorldState();
            var chain = new Chain(worldState, genesisBlock);
            
            // deployment
            Assert.True(chain.Initialize());
            // deployment only once
            Assert.False(chain.Initialize());
            
            // only genesis block should be in the chain
            Assert.Equal(chain.Blocks.Count, 1);
            
            const string smartContractMapKey = "SmartContractMap";
            var accountZeroDataProvider = worldState.GetAccountDataProviderByAccount(chain.AccountZero);
            Assert.NotNull(accountZeroDataProvider);

            var smartContractRegistration =
                (SmartContractRegistration) accountZeroDataProvider.GetDataProvider()
                    .GetDataProvider(smartContractMapKey)
                    .GetAsync(new Hash<SmartContractRegistration>(
                        accountZeroDataProvider.CalculateHashWith("SmartContract")))
                    .Result;
            Assert.NotNull(new Hash<SmartContractRegistration>(accountZeroDataProvider.CalculateHashWith("SmartContract")));
            
            Assert.Equal(smartContractRegistration.Category, category);
            Assert.Equal(smartContractRegistration.Name, name);
            Assert.True(smartContractRegistration.Bytes == data);
            
            // TODO: get SmartContractRegistration instance with deserilization
        }
    }
}