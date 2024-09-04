using System.Linq;
using AElf.CSharp.Core;
using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;
using ZkWasmVerifier;

namespace AElf.Contracts.ZkWasmVerifier
{
    public partial class ZkWasmVerifier : ZkWasmVerifierContainer.ZkWasmVerifierBase
    {
        public override Empty Verify(VerifyInput input)
        {
            var proof = input.Proof.Select(x => (BigIntValue)x).ToArray();
            var aux = input.Aux.Select(x => (BigIntValue)x).ToArray().ToArray();
            var verifyInstance = input.VerifyInstance.Select(x => (BigIntValue)x).ToArray();
            var targetInstance = input.TargetInstance.Select(x => x.Value.Select(y => (BigIntValue)y).ToArray())
                .ToArray();
            var buf = new BigIntValue[43];

            var forCalulatingKeccakHash = targetInstance.SelectMany(x => x)
                .Concat(verifyInstance).ToArray();
            var hash = Context.Keccak256(forCalulatingKeccakHash.SelectMany(x => x.ToBytes32()).ToArray()); 
            buf[2] = BigIntValue.FromBigEndianBytes(hash).ModPow(1, AggregatorLib.QMod);

            BigIntValue[] verifyCircuitPairingBuf = new BigIntValue[12];
            {
                // step 1: calculate verify circuit instance commitment
                Context.CalcVerifyCircuitLagrange(buf);

                // step 2: calculate challenge
                // take transcript[0..102]
                // calculate challenges and store them in buf[0..10]
                Context.GetChallenges(proof, buf);

                // step 3: calculate verify circuit pair
                buf = VerifyProofStep1(proof, aux, buf);
                buf = VerifyProofStep2(proof, aux, buf);
                buf = VerifyProofStep3(proof, aux, buf);

                verifyCircuitPairingBuf[0] = buf[0];
                verifyCircuitPairingBuf[1] = buf[1];
                verifyCircuitPairingBuf[6] = buf[2];
                verifyCircuitPairingBuf[7] = buf[3];
                if (verifyCircuitPairingBuf[0].IsZero() || verifyCircuitPairingBuf[1].IsZero())
                {
                    throw new AssertionException("invalid w point");
                }

                if (verifyCircuitPairingBuf[6].IsZero() || verifyCircuitPairingBuf[7].IsZero())
                {
                    throw new AssertionException("invalid g point");
                }
            }
            var checked_ = false;
            AggregatorConfig.FillVerifyCircuitsG2(verifyCircuitPairingBuf);
            checked_ = Context.Pairing(verifyCircuitPairingBuf);
            if (!checked_)
            {
                throw new AssertionException("pairing check failed");
            }

            return new Empty();
        }
    }
}