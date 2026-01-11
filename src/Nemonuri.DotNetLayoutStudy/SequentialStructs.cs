
using Nemonuri.DotNetLayoutStudy.Promoted;

namespace Nemonuri.DotNetLayoutStudy;

[StructLayout(LayoutKind.Sequential)]
public struct ByteAndTAndByte<T>
{
    public byte Field0;
    public T Field1;
    public byte Field2;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ByteAndTAndBytePack1<T>
{
    public byte Field0;
    public T Field1;
    public byte Field2;
}

[StructLayout(LayoutKind.Sequential)]
public struct SequentialStruct1
{
    public Size3 Field0;

    public Size32 Field1;

    public Size33 Field2;

    public Size34 Field3;
}

[StructLayout(LayoutKind.Sequential)]
public struct SequentialStruct1<T>
{
    public Size3<T> Field0;

    public Size32<T> Field1;

    public Size33<T> Field2;

    public Size34<T> Field3;
}