using System.Linq;
using AElf.CSharp.Core;
using AElf.Sdk.CSharp;
using AElf.Types;

namespace ZkWasmVerifier;

public static class AggregatorConfig
{
    public static void FillVerifyCircuitsG2(BigIntValue[] s)
    {
        s[2] = "10912121346736960153119032326674308622836895172287017181004332853287395747540";
        s[3] = "1141242303575873671169773919745529817497021056319105990006251901769180589131";
        s[4] = "13736722489223410979012950988289654946078517441362861355057236908979399480985";
        s[5] = "17920167001006791983741102148022475408561884350390649459550129912018198675534";

        s[8] = "11559732032986387107991004021392285783925812861821192530917403151452391805634";
        s[9] = "10857046999023057135944570762232829481370756359578518086990519993285655852781";
        s[10] = "17805874995975841540914202342111839520379459829704422454583296818431106115052";
        s[11] = "13392588948715843804641432497768002650278120570034223513918757245338268106653";
    }

    public static void GetChallenges(this CSharpSmartContractContext ctx, BigIntValue[] transcript, BigIntValue[] buf)
    {
        ctx.GetChallengesShplonk(transcript, buf);
    }

    public static void GetChallengesShplonk(this CSharpSmartContractContext ctx, BigIntValue[] transcript, BigIntValue[] buf)
    {
        BigIntValue[] absorbing = new BigIntValue[112];
        absorbing[0] = "8987513744584090369347489657311893833926946877426413758008060670913747976065";
        absorbing[1] = buf[0];
        absorbing[2] = buf[1];
        var pos = 3;
        var transcriptPos = 0;
        for (var i = 0; i < 8; i++)
        {
            AggregatorLib.CheckOnCurve(transcript[transcriptPos], transcript[transcriptPos + 1]);
            absorbing[pos++] = transcript[transcriptPos++];
            absorbing[pos++] = transcript[transcriptPos++];
        }

        // theta        
        buf[2] = ctx.SqeezeChallenge(absorbing, pos);

        pos = 1;
        for (var i = 0; i < 4; i++)
        {
            AggregatorLib.CheckOnCurve(transcript[transcriptPos], transcript[transcriptPos + 1]);
            absorbing[pos++] = transcript[transcriptPos++];
            absorbing[pos++] = transcript[transcriptPos++];
        }

        // beta
        buf[3] = ctx.SqeezeChallenge(absorbing, pos);

        pos = 1;
        // gamma
        buf[4] = ctx.SqeezeChallenge(absorbing, pos);

        pos = 1;
        for (var i = 0; i < 7; i++)
        {
            AggregatorLib.CheckOnCurve(transcript[transcriptPos], transcript[transcriptPos + 1]);
            absorbing[pos++] = transcript[transcriptPos++];
            absorbing[pos++] = transcript[transcriptPos++];
        }

        // y
        buf[5] = ctx.SqeezeChallenge(absorbing, pos);

        pos = 1;
        for (var i = 0; i < 3; i++)
        {
            AggregatorLib.CheckOnCurve(transcript[transcriptPos], transcript[transcriptPos + 1]);
            absorbing[pos++] = transcript[transcriptPos++];
            absorbing[pos++] = transcript[transcriptPos++];
        }

        // x
        buf[6] = ctx.SqeezeChallenge(absorbing, pos);

        pos = 1;
        for (var i = 0; i < 56; i++)
        {
            absorbing[pos++] = transcript[transcriptPos++];
        }

        // y
        buf[7] = ctx.SqeezeChallenge(absorbing, pos);

        pos = 1;
        // v
        buf[8] = ctx.SqeezeChallenge(absorbing, pos);

        AggregatorLib.CheckOnCurve(transcript[transcriptPos], transcript[transcriptPos + 1]);
        absorbing[pos++] = transcript[transcriptPos++];
        absorbing[pos++] = transcript[transcriptPos++];

        // u
        buf[9] = ctx.SqeezeChallenge(absorbing, pos);
        AggregatorLib.CheckOnCurve(transcript[transcriptPos], transcript[transcriptPos + 1]);
    }

    public static void CalcVerifyCircuitLagrange(this CSharpSmartContractContext ctx, BigIntValue[] buf)
    {
        buf[0] = "2735708597799451452160332461848350692128893288992167946537450125562183732533";
        buf[1] = "16512170175385812892195391099574916023024416995263347775961451770318731872745";
        ctx.Msm(buf, 0, 1);
    }

    public static BigIntValue Hash(this CSharpSmartContractContext ctx, BigIntValue[] absorbing, int length)
    {
        var bytes = absorbing.Take(length).SelectMany(x => x.ToBytes32()).Concat(new byte[1]).ToArray();
        var hash = ctx.Keccak256(bytes);
        return BigIntValue.FromBigEndianBytes(hash);
    }

    public static BigIntValue SqeezeChallenge(this CSharpSmartContractContext ctx, BigIntValue[] absorbing, int length)
    {
        absorbing[length] = 0;
        var hash = ctx.Hash(absorbing, length);
        absorbing[0] = hash;
        return hash.ModPow(1, AggregatorLib.QMod);
    }
}