
namespace Nemonuri.DotNetLayoutStudy.Promoted;

[StructLayout(LayoutKind.Sequential, Size = 3)]
public readonly struct Size3
{}

[StructLayout(LayoutKind.Sequential, Size = 32)]
public readonly struct Size32
{}

[StructLayout(LayoutKind.Sequential, Size = 33)]
public readonly struct Size33
{}

[StructLayout(LayoutKind.Sequential, Size = 34)]
public readonly struct Size34
{}

[StructLayout(LayoutKind.Sequential, Size = 3)]
public readonly struct Size3<T>
{
    public readonly T Field0;
}

[StructLayout(LayoutKind.Sequential, Size = 32)]
public readonly struct Size32<T>
{
    public readonly T Field0;
}

[StructLayout(LayoutKind.Sequential, Size = 33)]
public readonly struct Size33<T>
{
    public readonly T Field0;
}

[StructLayout(LayoutKind.Sequential, Size = 34)]
public readonly struct Size34<T>
{
    public readonly T Field0;
}