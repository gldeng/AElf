namespace AElf.CrossChain.Cache
{
    // todo : generic type
    public interface ICrossChainDataConsumer
    {
        IBlockInfo TryTake(int crossChainId, long height, bool isCacheSizeLimited);
        int GetCachedChainCount();
        void TryRegisterNewChainCache(int remoteChainId, long chainHeight = KernelConstants.GenesisBlockHeight);
        bool CheckAlreadyCachedChain(int remoteChainId);
    }
}