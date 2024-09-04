using System;
using System.Collections.Generic;
using AElf.CSharp.Core;
using AElf.Sdk.CSharp;
using AElf.Types;

namespace ZkWasmVerifier;

public class NotOnCurveException : AssertionException
{
    public NotOnCurveException(string message) : base(message)
    {
    }
}

public static class AggregatorLib
{
    private static BigIntValue PMod => new BigIntValue
    {
        Value =
            "21888242871839275222246405745257275088696311157297823662689037894645226208583"
    };

    public static BigIntValue QMod => new BigIntValue
    {
        Value = "21888242871839275222246405745257275088548364400416034343698204186575808495617"
    };

    // public static BigIntValue HashInstances(BigIntValue[] absorbing)
    // {
    //     var hash = Sha3Keccack.Current.CalculateHash(absorbing.SelectMany(x => x.ToBytes32()).ToArray());
    //     return hash.ToBigIntValue() % QMod;
    // }

    public static void CheckOnCurve(BigIntValue x, BigIntValue y)
    {
        // y^2 = x^3 + 3
        if (x.IsZero()) return;
        if (y.IsZero()) return;
        BigIntValue l = (y * y).ModPow(1, PMod);
        BigIntValue r = (x * x).ModPow(1, PMod);
        r = (r * x).ModPow(1, PMod);
        r = (r + 3).ModPow(1, PMod);
        if (l != r)
        {
            throw new NotOnCurveException("Not on curve");
        }
    }

    private static (bool, BigIntValue x, BigIntValue y) TryMul(this CSharpSmartContractContext ctx, BigIntValue x1,
        BigIntValue y1, BigIntValue s)
    {
        try
        {
            var (x, y) = ctx.Bn254G1Mul(x1.ToBytes32(), y1.ToBytes32(), s.ToBytes32());
            return (true, BigIntValue.FromBigEndianBytes(x), BigIntValue.FromBigEndianBytes(y));
        }
        catch (Exception e)
        {
            return (false, 0, 0);
        }
    }

    private static (bool, BigIntValue x, BigIntValue y) TryAdd(this CSharpSmartContractContext ctx, BigIntValue x1,
        BigIntValue y1, BigIntValue x2,
        BigIntValue y2)
    {
        try
        {
            var (x, y) = ctx.Bn254G1Add(x1.ToBytes32(), y1.ToBytes32(), x2.ToBytes32(),
                y2.ToBytes32());
            return (true, BigIntValue.FromBigEndianBytes(x), BigIntValue.FromBigEndianBytes(y));
        }
        catch (Exception e)
        {
            return (false, 0, 0);
        }
    }

    public static bool Pairing(this CSharpSmartContractContext ctx, BigIntValue[] input)
    {
        var elements = new List<(byte[], byte[], byte[], byte[], byte[], byte[])>();
        for (var i = 0; 6 * i < input.Length; i++)
        {
            var (x1, y1, x2, y2, x3, y3) = (
                input[6 * i], input[6 * i + 1],
                input[6 * i + 2], input[6 * i + 3],
                input[6 * i + 4], input[6 * i + 5]
            );
            elements.Add((x1.ToBytes32(), y1.ToBytes32(), x2.ToBytes32(), y2.ToBytes32(),
                x3.ToBytes32(), y3.ToBytes32()));
        }

        return ctx.Pairing(elements.ToArray());
    }

    public static void Msm(this CSharpSmartContractContext ctx, BigIntValue[] input, int offset, int count)
    {
        if (count == 0)
        {
            input[offset] = 0;
            input[offset + 1] = 0;
            return;
        }

        var ret = false;
        var start = offset + count * 3 - 3;
        {
            var (ret0, x, y) = ctx.TryMul(input[start], input[start + 1], input[start + 2]);
            ret = ret0;
            input[start] = x;
            input[start + 1] = y;
        }
        // Require(ret);

        while (start != offset)
        {
            start -= 3;
            {
                var (ret0, x, y) = ctx.TryMul(input[start], input[start + 1], input[start + 2]);
                ret = ret0;
                input[start + 1] = x;
                input[start + 2] = y;
            }
            {
                var (ret0, x, y) = ctx.TryAdd(input[start + 1], input[start + 2], input[start + 3], input[start + 4]);
                ret = ret0;
                input[start] = x;
                input[start + 1] = y;
            }
        }
    }

    public static void EccMul(this CSharpSmartContractContext ctx, BigIntValue[] input, int offset)
    {
        if (input[offset + 2].Value == "1")
        {
            return;
        }

        ctx.Msm(input, offset, 1);
    }

    public static void EccMulAdd(this CSharpSmartContractContext ctx, BigIntValue[] input, int offset)
    {
        var ret = false;
        var p1 = offset;
        var p2 = p1 + 2;
        {
            var (ret0, x, y) = ctx.TryMul(input[p2], input[p2 + 1], input[p2 + 2]);
            ret = ret0;
            input[p2] = x;
            input[p2 + 1] = y;
        }
        {
            var (ret0, x, y) = ctx.TryAdd(input[p1], input[p1 + 1], input[p1 + 2], input[p1 + 3]);
            ret = ret0;
            input[p1] = x;
            input[p1 + 1] = y;
        }
    }

    // function ecc_mul_add(
    //     uint256[] memory input,
    // uint256 offset
    // ) internal view {
    //     bool ret = false;
    //     uint256 p1 = offset * 0x20 + 0x20;
    //     uint256 p2 = p1 + 0x40;
    //
    //     assembly {
    //         ret := staticcall(
    //             gas(),
    //             7,
    //             add(input, p2),
    //             0x60,
    //             add(input, p2),
    //             0x40
    //         )
    //     }
    //     require(ret);
    //
    //     assembly {
    //         ret := staticcall(
    //             gas(),
    //             6,
    //             add(input, p1),
    //             0x80,
    //             add(input, p1),
    //             0x40
    //         )
    //     }
    //     require(ret);
    // }

    public static BigIntValue FrPow(BigIntValue a, BigIntValue power)
    {
        return SafeMath.ModPow(a, power, QMod);
    }

    public static BigIntValue FrDiv(BigIntValue a, BigIntValue b, BigIntValue aux)
    {
        var r = (b * aux).ModPow(1, QMod);
        if (a != r)
        {
            throw new AssertionException("div fail");
        }

        if (b.IsZero())
        {
            throw new AssertionException("div zero");
        }

        return aux.ModPow(1, QMod);
    }

    // function fr_div(uint256 a, uint256 b, uint256 aux) internal pure returns (uint256) {
    //     uint256 r = mulmod(b, aux, QMod.DecToUInt256());
    //     require(a == r, "div fail");
    //     require(b != 0, "div zero");
    //     return aux % QMod.DecToUInt256();
    // }

    // function fr_pow(uint256 a, uint256 power) internal view returns (uint256) {
    //     uint256[6] memory input;
    //     uint256[1] memory result;
    //     bool ret;
    //
    //     input[0] = 32;
    //     input[1] = 32;
    //     input[2] = 32;
    //     input[3] = a;
    //     input[4] = power;
    //     input[5] = QMod.DecToUInt256();
    //
    //     assembly {
    //         ret := staticcall(gas(), 0x05, input, 0xc0, result, 0x20)
    //     }
    //     require(ret);
    //
    //     return result[0];
    // }
}