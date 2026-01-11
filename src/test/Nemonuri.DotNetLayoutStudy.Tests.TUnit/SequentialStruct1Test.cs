using Nemonuri.DotNetLayoutStudy.Promoted;

namespace Nemonuri.DotNetLayoutStudy.Tests;

public partial class SequentialStruct1Test
{

    [Test]
    public unsafe void NoFieldTest()
    {
        // Arrange
        SequentialStruct1 s = new();
        void* baseAddress = &s;
        void* field0Address = &s.Field0;
        void* field1Address = &s.Field1;
        void* field2Address = &s.Field2;
        void* field3Address = &s.Field3;

        // Act
        Console.WriteValue(baseAddress);
        Console.WriteValue(field0Address);
        Console.WriteValue(field1Address);
        Console.WriteValue(field2Address);
        Console.WriteValue(field3Address);
        Console.WriteValue(&s + 1);
        Console.WriteValue(GetPointerOffset(field0Address, field1Address));
        Console.WriteValue(GetPointerOffset(field1Address, field2Address));
        Console.WriteValue(GetPointerOffset(field2Address, field3Address));
        Console.WriteValue(GetPointerOffset(field3Address, &s + 1));

        Console.WriteValue(sizeof(Size3));
        Console.WriteValue(sizeof(Size32));
        Console.WriteValue(sizeof(Size33));
        Console.WriteValue(sizeof(Size34));
        Console.WriteValue(sizeof(SequentialStruct1));

        // Assert
    }

    [Test]
    [GenerateGenericTest(typeof(Empty))]
    [GenerateGenericTest(typeof(byte))]
    [GenerateGenericTest(typeof(char))]
    [GenerateGenericTest(typeof(short))]
    [GenerateGenericTest(typeof(int))]
    [GenerateGenericTest(typeof(float))]
    [GenerateGenericTest(typeof(long))]
    [GenerateGenericTest(typeof(nint))]
    [GenerateGenericTest(typeof(object))]
    [GenerateGenericTest(typeof(string))]
    [GenerateGenericTest(typeof(int[]))]
    [GenerateGenericTest(typeof(int?))]
    [GenerateGenericTest(typeof(ByteAndTAndByte<byte>))]
    [GenerateGenericTest(typeof(ByteAndTAndBytePack1<byte>))]
    [GenerateGenericTest(typeof(ByteAndTAndByte<char>))]
    [GenerateGenericTest(typeof(ByteAndTAndBytePack1<char>))]
    [GenerateGenericTest(typeof(ByteAndTAndByte<int>))]
    [GenerateGenericTest(typeof(ByteAndTAndBytePack1<int>))]
    [GenerateGenericTest(typeof(System.Int128))]
    [GenerateGenericTest(typeof(System.Runtime.Intrinsics.Vector64<byte>))]
    [GenerateGenericTest(typeof(System.Runtime.Intrinsics.Vector128<byte>))]
    [GenerateGenericTest(typeof(System.Runtime.Intrinsics.Vector256<byte>))]
    [GenerateGenericTest(typeof(System.Runtime.Intrinsics.Vector512<byte>))]
    public unsafe void GenericFieldTest<T>()
    {
#pragma warning disable CS8500
        // Arrange
        SequentialStruct1<T> s = new();
        SequentialStruct1<T>* baseAddress = &s;
        Size3<T>* field0Address = &s.Field0;
        Size32<T>* field1Address = &s.Field1;
        Size33<T>* field2Address = &s.Field2;
        Size34<T>* field3Address = &s.Field3;

        // Act
        Console.WriteValue(typeof(SequentialStruct1<T>).Name);
        Console.WriteValue(FieldSlot.Create<Size3<T>>(baseAddress, field0Address, field1Address));
        Console.WriteValue(FieldSlot.Create<Size32<T>>(field0Address+1, field1Address, field2Address));
        Console.WriteValue(FieldSlot.Create<Size33<T>>(field1Address+1, field2Address, field3Address));
        Console.WriteValue(FieldSlot.Create<Size34<T>>(field2Address+1, field3Address, baseAddress + 1));

        // Assert

#pragma warning restore CS8500
    }


    private unsafe long GetPointerOffset(void* low, void* high)
    {
        return (byte*)high - (byte*)low;
    }
}
