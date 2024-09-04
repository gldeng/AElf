using AElf.Types;

namespace ZkWasmVerifier;

public static class Extensions
{
    public static bool IsZero(this BigIntValue value)
    {
        return value.Value == "0";
    }

    public static byte[] ToBytes32(this BigIntValue value)
    {
        var bytes = value.ToBigEndianBytes();
        var newArray = new byte[32];
        for (int i = 0; i < bytes.Length; i++)
        {
            newArray[31 - i] = bytes[bytes.Length - 1 - i];
        }

        return newArray;
    }
}