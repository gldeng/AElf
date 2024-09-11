using AElf.Types;

namespace ZkWasmVerifier;

public interface IAggregatorVerifierCoreStep
{
    BigIntValue[] VerifyProof(BigIntValue[] transcript, BigIntValue[] aux, BigIntValue[] buf);
}