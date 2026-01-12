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


    private unsafe long GetPointerOffset(void* low, void* high)
    {
        return (byte*)high - (byte*)low;
    }
}
