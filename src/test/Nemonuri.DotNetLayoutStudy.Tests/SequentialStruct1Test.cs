using System.Runtime.CompilerServices;
using Nemonuri.DotNetLayoutStudy;
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
        _out.WriteValue(sizeof(SequentialStruct1));

        // Assert
    }

    private unsafe void GenericFieldTestCore<T>()
    {
#pragma warning disable CS8500
        // Arrange
        SequentialStruct1<T> s = new();
        void* baseAddress = &s;
        void* field0Address = &s.Field0;
        void* field1Address = &s.Field1;
        void* field2Address = &s.Field2;
        void* field3Address = &s.Field3;

        // Act
        _out.WriteValue(typeof(SequentialStruct1<T>).ToDisplayName());
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
        _out.WriteValue(sizeof(SequentialStruct1));

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
        GenericFieldTestCore<long>();
    }


    private unsafe long GetPointerOffset(void* low, void* high)
    {
        return (byte*)high - (byte*)low;
    }
}
