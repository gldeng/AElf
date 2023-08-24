namespace AElf.Runtime.WebAssembly.Extensions;

public static class EnumExtensions
{
    public static bool Contains(this CallFlags callFlags, CallFlags other)
    {
        return (callFlags & other) == other;
    }
}