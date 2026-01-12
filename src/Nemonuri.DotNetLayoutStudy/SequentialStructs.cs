
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
public struct SequentialStruct1<T> : ISupportFieldAddress
{
    public Size3<T> Field0;

    public Size32<T> Field1;

    public Size33<T> Field2;

    public Size34<T> Field3;

    public unsafe void* GetFieldAddressAt(int index)
    {
#pragma warning disable CS8500
        fixed (SequentialStruct1<T>* pThis = &this)
        {
            return index switch
            {
                0 => &pThis->Field0,
                1 => &pThis->Field1,
                2 => &pThis->Field2,
                3 => &pThis->Field3,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
#pragma warning restore CS8500
    }
}

public unsafe interface ISupportFieldAddress
{
    void* GetFieldAddressAt(int index);
}