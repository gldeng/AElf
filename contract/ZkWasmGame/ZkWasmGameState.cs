using AElf.Contracts.ZkWasmVerifier;
using AElf.Sdk.CSharp.State;

namespace AElf.Contracts.ZkWasmGame;

public class ZkWasmGameState : ContractState
{
    public SingletonState<GameState> GameState { get; set; }
    internal ZkWasmVerifierContainer.ZkWasmVerifierReferenceState Verifier { get; set; }
}