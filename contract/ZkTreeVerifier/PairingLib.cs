using AElf.CSharp.Core;
using AElf.Sdk.CSharp;
using AElf.Types;

// ReSharper disable MethodNameNotMeaningful
// ReSharper disable TooManyArguments

namespace AElf.Contracts.ZkTreeVerifier;

using PairingInput = (byte[], byte[], byte[], byte[], byte[], byte[]);

public class Proof
{
    public G1Point A { get; set; }
    public G2Point B { get; set; }
    public G1Point C { get; set; }
}

public class G1Point
{
    public BigIntValue X { get; set; }
    public BigIntValue Y { get; set; }
}

public class G2Point
{
    public Fp2 X { get; set; }
    public Fp2 Y { get; set; }
}

public class Fp2
{
    public BigIntValue A { get; set; }
    public BigIntValue B { get; set; }
}

public static class PairingLib
{
    internal static bool IsZero(this BigIntValue v)
    {
        return v == BigIntValue.Zero;
    }

    internal static BigIntValue ToBigIntValue(this string v)
    {
        return v;
    }

    internal static G1Point P1()
    {
        return new G1Point()
        {
            X = "1",
            Y = "2"
        };
    }

    internal static G2Point P2()
    {
        return new G2Point()
        {
            X = new Fp2()
            {
                A = "11559732032986387107991004021392285783925812861821192530917403151452391805634",
                B = "10857046999023057135944570762232829481370756359578518086990519993285655852781"
            },
            Y = new Fp2()
            {
                A = "4082367875863433681332203403145435568316851327593401208105741076214120093531",
                B = "8495653923123431417604973247489272438418190587263600148770280649306958101930"
            }
        };
    }

    internal static G1Point Negate(this CSharpSmartContractContext ctx, G1Point p)
    {
        BigIntValue q = "21888242871839275222246405745257275088696311157297823662689037894645226208583";
        if (p.X.IsZero() && p.Y.IsZero())
        {
            return new G1Point()
            {
                X = "0",
                Y = "0"
            };
        }

        return new G1Point()
        {
            X = p.X,
            Y = q - p.Y.ModPow(1, q)
        };
    }

    internal static G1Point Addition(this CSharpSmartContractContext ctx, G1Point p1, G1Point p2)
    {
        var (x, y) = ctx.Bn254G1Add(
            p1.X.ToBigEndianBytes(),
            p1.Y.ToBigEndianBytes(),
            p2.X.ToBigEndianBytes(),
            p2.Y.ToBigEndianBytes()
        );
        return new G1Point()
        {
            X = BigIntValue.FromBigEndianBytes(x),
            Y = BigIntValue.FromBigEndianBytes(y)
        };
    }

    internal static G1Point ScalarMul(this CSharpSmartContractContext ctx, G1Point p, BigIntValue scalar)
    {
        var (x, y) = ctx.Bn254G1Mul(
            p.X.ToBigEndianBytes(),
            p.Y.ToBigEndianBytes(),
            scalar.ToBigEndianBytes()
        );
        return new G1Point()
        {
            X = BigIntValue.FromBigEndianBytes(x),
            Y = BigIntValue.FromBigEndianBytes(y)
        };
    }

    internal static bool Pairing(this CSharpSmartContractContext ctx, G1Point[] p1, G2Point[] p2)
    {
        if (p1.Length != p2.Length)
        {
            throw new AssertionException("pairing-lengths-failed");
        }

        var elements = p1.Length;
        var input = new PairingInput[elements];
        for (var i = 0; i < elements; i++)
        {
            input[i] = (
                p1[i].X.ToBigEndianBytes(),
                p1[i].Y.ToBigEndianBytes(),
                p2[i].X.A.ToBigEndianBytes(),
                p2[i].X.B.ToBigEndianBytes(),
                p2[i].Y.A.ToBigEndianBytes(),
                p2[i].Y.B.ToBigEndianBytes()
            );
        }

        var success = ctx.Bn254Pairing(input);
        if (!success)
        {
            throw new AssertionException("pairing-check-failed");
        }

        return true;
    }

    internal static bool PairingProd2(this CSharpSmartContractContext ctx,
        G1Point a1, G2Point a2,
        G1Point b1, G2Point b2)
    {
        return ctx.Pairing(new[]
        {
            a1, b1
        }, new[]
        {
            a2, b2
        });
    }

    internal static bool PairingProd3(this CSharpSmartContractContext ctx,
        G1Point a1, G2Point a2,
        G1Point b1, G2Point b2,
        G1Point c1, G2Point c2)
    {
        return ctx.Pairing(new[]
        {
            a1, b1, c1
        }, new[]
        {
            a2, b2, c2
        });
    }

    internal static bool PairingProd4(this CSharpSmartContractContext ctx,
        G1Point a1, G2Point a2,
        G1Point b1, G2Point b2,
        G1Point c1, G2Point c2,
        G1Point d1, G2Point d2)
    {
        return ctx.Pairing(new[]
        {
            a1, b1, c1, d1
        }, new[]
        {
            a2, b2, c2, d2
        });
    }
}