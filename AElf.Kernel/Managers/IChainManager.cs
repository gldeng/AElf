﻿using System.Threading.Tasks;

namespace AElf.Kernel.Managers
{
    public interface IChainManager
    {
        Task AppendBlockToChainAsync(Chain chain, Block block);
        Task<Chain> GetChainAsync(Hash id);
        Task<Chain> AddChainAsync(Hash chainId);
    }
} 