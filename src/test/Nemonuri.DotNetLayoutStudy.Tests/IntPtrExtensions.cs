namespace Nemonuri.DotNetLayoutStudy.Tests;

public static unsafe class IntPtrExtensions
{
#if !NETSTANDARD2_1_OR_GREATER
    extension(nint)
    {
        public static nint operator -(nint left, nint right) => (nint)((byte*)left - (byte*)right);
    }
#endif
}