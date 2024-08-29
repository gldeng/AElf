using System.Linq;
using AElf.Contracts.ZkWasmVerifier;
using AElf.Types;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.ZkWasmGame;

public class ZkWasmGameContract : ZkWasmGameContainer.ZkWasmGameBase
{
    public override Empty SubmitGame(SubmitGameInput input)
    {
        Assert(State.Verifier.Value != null, "Verifier not set.");
        State.Verifier.Verify.Send(MapInput(input));
        Settle(input.TargetInstance);
        return new Empty();
    }

    public override Empty SetVerifier(Address input)
    {
        State.Verifier.Value = input;
        return new Empty();
    }

    public override Address GetVerifier(Empty input)
    {
        return State.Verifier.Value;
    }

    public override GameState GetGameState(Empty input)
    {
        return State.GameState.Value;
    }

    #region Private Methods

    private VerifyInput MapInput(SubmitGameInput input)
    {
        var inputToVerifier = new VerifyInput();
        inputToVerifier.Proof.AddRange(input.Proof);
        inputToVerifier.Aux.AddRange(input.Aux);
        inputToVerifier.VerifyInstance.AddRange(input.VerifyInstance);
        inputToVerifier.TargetInstance.AddRange(input.TargetInstance.Select(arr =>
        {
            var newArr = new VerifyInput.Types.StringArray();
            newArr.Value.AddRange(arr.Value);
            return newArr;
        }));
        return inputToVerifier;
    }

    private void Settle(RepeatedField<SubmitGameInput.Types.StringArray> instances)
    {
        var instance = instances.FirstOrDefault();
        if (instance == null)
        {
            return;
        }

        var startState = new GameState()
        {
            TotalSteps = instance.Value[0],
            CurrentPosition = instance.Value[1]
        };
        var endState = new GameState()
        {
            TotalSteps = instance.Value[2],
            CurrentPosition = instance.Value[3]
        };
        Assert(startState.Equals(State.GameState.Value ?? new GameState()
        {
            TotalSteps = "0",
            CurrentPosition = "0",
        }), "Invalid start state.");
        State.GameState.Value = endState;
    }

    #endregion
}