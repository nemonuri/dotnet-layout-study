using Nemonuri.DotNetLayoutStudy.Promoted;
using Xunit.Sdk;

namespace Nemonuri.DotNetLayoutStudy.Tests;

public class SequentialStruct1Test
{
    private readonly ITestOutputHelper _out;

    public SequentialStruct1Test(ITestOutputHelper @out)
    {
        _out = @out;
    }

    [Fact]
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
        _out.WriteValue(baseAddress);
        _out.WriteValue(field0Address);
        _out.WriteValue(field1Address);
        _out.WriteValue(field2Address);
        _out.WriteValue(field3Address);
        _out.WriteValue(&s + 1);
        _out.WriteValue(GetPointerOffset(field0Address, field1Address));
        _out.WriteValue(GetPointerOffset(field1Address, field2Address));
        _out.WriteValue(GetPointerOffset(field2Address, field3Address));
        _out.WriteValue(GetPointerOffset(field3Address, &s + 1));

        _out.WriteValue(sizeof(Size3));
        _out.WriteValue(sizeof(Size32));
        _out.WriteValue(sizeof(Size33));
        _out.WriteValue(sizeof(Size34));
        _out.WriteValue(sizeof(SequentialStruct1));

        // Assert
    }

    private unsafe void GenericFieldTestCore<T>()
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
        _out.WriteValue(typeof(SequentialStruct1<T>).ToDisplayName());
        _out.WriteValue(FieldSlot.Create<Size3<T>>(baseAddress, field0Address, field1Address));
        _out.WriteValue(FieldSlot.Create<Size32<T>>(field0Address+1, field1Address, field2Address));
        _out.WriteValue(FieldSlot.Create<Size33<T>>(field1Address+1, field2Address, field3Address));
        _out.WriteValue(FieldSlot.Create<Size34<T>>(field2Address+1, field3Address, baseAddress + 1));

        // Assert

#pragma warning restore CS8500
    }

    [Fact]
    public void GenericFieldTest()
    {
        GenericFieldTestCore<Empty>();
        GenericFieldTestCore<byte>();
        GenericFieldTestCore<char>();
        GenericFieldTestCore<short>();
        GenericFieldTestCore<int>();
        GenericFieldTestCore<float>();
        GenericFieldTestCore<long>();
        GenericFieldTestCore<nint>();
        GenericFieldTestCore<object>();
        GenericFieldTestCore<string>();
        GenericFieldTestCore<int[]>();
        GenericFieldTestCore<int?>();
        GenericFieldTestCore<ByteAndTAndByte<byte>>();
        GenericFieldTestCore<ByteAndTAndBytePack1<byte>>();
        GenericFieldTestCore<ByteAndTAndByte<char>>();
        GenericFieldTestCore<ByteAndTAndBytePack1<char>>();
        GenericFieldTestCore<ByteAndTAndByte<int>>();
        GenericFieldTestCore<ByteAndTAndBytePack1<int>>();
    }


    private unsafe long GetPointerOffset(void* low, void* high)
    {
        return (byte*)high - (byte*)low;
    }
}
