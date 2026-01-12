using Nemonuri.DotNetLayoutStudy.Promoted;

namespace Nemonuri.DotNetLayoutStudy.Tests;

public partial class SequentialStruct1Test
{

    internal void GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>() 
        where TSequentialStruct1 : struct, ISupportFieldAddress
    {
#pragma warning disable CS8500, CS9123
        unsafe
        {
            // Arrange
            TSequentialStruct1 s = new();
            TSequentialStruct1* baseAddress = &s;
            TSize3* field0Address = (TSize3*)s.GetFieldAddressAt(0);
            TSize32* field1Address = (TSize32*)s.GetFieldAddressAt(1);
            TSize33* field2Address = (TSize33*)s.GetFieldAddressAt(2);
            TSize34* field3Address = (TSize34*)s.GetFieldAddressAt(3);

            // Act
            Console.WriteLine();
            Console.WriteValue(typeof(T).FullName);
            Console.WriteValue(typeof(TSequentialStruct1).Attributes);
            Console.WriteValue(FieldSlot.Create<TSize3>(baseAddress, field0Address, field1Address));
            Console.WriteValue(FieldSlot.Create<TSize32>(field0Address+1, field1Address, field2Address));
            Console.WriteValue(FieldSlot.Create<TSize33>(field1Address+1, field2Address, field3Address));
            Console.WriteValue(FieldSlot.Create<TSize34>(field2Address+1, field3Address, baseAddress + 1));
        }

        // Assert

#pragma warning restore CS8500, CS9123
    }

    [Test]
    [GenerateGenericTest(typeof(Empty), typeof(SequentialStruct1<Empty>), typeof(Size3<Empty>), typeof(Size32<Empty>), typeof(Size33<Empty>), typeof(Size34<Empty>))]
    public void GenericFieldTest_Empty<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(byte), typeof(SequentialStruct1<byte>), typeof(Size3<byte>), typeof(Size32<byte>), typeof(Size33<byte>), typeof(Size34<byte>))]
    public void GenericFieldTest_byte<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(char), typeof(SequentialStruct1<char>), typeof(Size3<char>), typeof(Size32<char>), typeof(Size33<char>), typeof(Size34<char>))]
    public void GenericFieldTest_char<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(short), typeof(SequentialStruct1<short>), typeof(Size3<short>), typeof(Size32<short>), typeof(Size33<short>), typeof(Size34<short>))]
    public void GenericFieldTest_short<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(int), typeof(SequentialStruct1<int>), typeof(Size3<int>), typeof(Size32<int>), typeof(Size33<int>), typeof(Size34<int>))]
    public void GenericFieldTest_int<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(float), typeof(SequentialStruct1<float>), typeof(Size3<float>), typeof(Size32<float>), typeof(Size33<float>), typeof(Size34<float>))]
    public void GenericFieldTest_float<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(long), typeof(SequentialStruct1<long>), typeof(Size3<long>), typeof(Size32<long>), typeof(Size33<long>), typeof(Size34<long>))]
    public void GenericFieldTest_long<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(nint), typeof(SequentialStruct1<nint>), typeof(Size3<nint>), typeof(Size32<nint>), typeof(Size33<nint>), typeof(Size34<nint>))]
    public void GenericFieldTest_nint<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(object), typeof(SequentialStruct1<object>), typeof(Size3<object>), typeof(Size32<object>), typeof(Size33<object>), typeof(Size34<object>))]
    public void GenericFieldTest_object<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(string), typeof(SequentialStruct1<string>), typeof(Size3<string>), typeof(Size32<string>), typeof(Size33<string>), typeof(Size34<string>))]
    public void GenericFieldTest_string<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(int[]), typeof(SequentialStruct1<int[]>), typeof(Size3<int[]>), typeof(Size32<int[]>), typeof(Size33<int[]>), typeof(Size34<int[]>))]
    public void GenericFieldTest_int__<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(int?), typeof(SequentialStruct1<int?>), typeof(Size3<int?>), typeof(Size32<int?>), typeof(Size33<int?>), typeof(Size34<int?>))]
    public void GenericFieldTest_int_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndByte<byte>), typeof(SequentialStruct1<ByteAndTAndByte<byte>>), typeof(Size3<ByteAndTAndByte<byte>>), typeof(Size32<ByteAndTAndByte<byte>>), typeof(Size33<ByteAndTAndByte<byte>>), typeof(Size34<ByteAndTAndByte<byte>>))]
    public void GenericFieldTest_ByteAndTAndByte_byte_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndBytePack1<byte>), typeof(SequentialStruct1<ByteAndTAndBytePack1<byte>>), typeof(Size3<ByteAndTAndBytePack1<byte>>), typeof(Size32<ByteAndTAndBytePack1<byte>>), typeof(Size33<ByteAndTAndBytePack1<byte>>), typeof(Size34<ByteAndTAndBytePack1<byte>>))]
    public void GenericFieldTest_ByteAndTAndBytePack1_byte_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndByte<char>), typeof(SequentialStruct1<ByteAndTAndByte<char>>), typeof(Size3<ByteAndTAndByte<char>>), typeof(Size32<ByteAndTAndByte<char>>), typeof(Size33<ByteAndTAndByte<char>>), typeof(Size34<ByteAndTAndByte<char>>))]
    public void GenericFieldTest_ByteAndTAndByte_char_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndBytePack1<char>), typeof(SequentialStruct1<ByteAndTAndBytePack1<char>>), typeof(Size3<ByteAndTAndBytePack1<char>>), typeof(Size32<ByteAndTAndBytePack1<char>>), typeof(Size33<ByteAndTAndBytePack1<char>>), typeof(Size34<ByteAndTAndBytePack1<char>>))]
    public void GenericFieldTest_ByteAndTAndBytePack1_char_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndByte<int>), typeof(SequentialStruct1<ByteAndTAndByte<int>>), typeof(Size3<ByteAndTAndByte<int>>), typeof(Size32<ByteAndTAndByte<int>>), typeof(Size33<ByteAndTAndByte<int>>), typeof(Size34<ByteAndTAndByte<int>>))]
    public void GenericFieldTest_ByteAndTAndByte_int_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndBytePack1<int>), typeof(SequentialStruct1<ByteAndTAndBytePack1<int>>), typeof(Size3<ByteAndTAndBytePack1<int>>), typeof(Size32<ByteAndTAndBytePack1<int>>), typeof(Size33<ByteAndTAndBytePack1<int>>), typeof(Size34<ByteAndTAndBytePack1<int>>))]
    public void GenericFieldTest_ByteAndTAndBytePack1_int_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndByte<string>), typeof(SequentialStruct1<ByteAndTAndByte<string>>), typeof(Size3<ByteAndTAndByte<string>>), typeof(Size32<ByteAndTAndByte<string>>), typeof(Size33<ByteAndTAndByte<string>>), typeof(Size34<ByteAndTAndByte<string>>))]
    public void GenericFieldTest_ByteAndTAndByte_string_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndBytePack1<string>), typeof(SequentialStruct1<ByteAndTAndBytePack1<string>>), typeof(Size3<ByteAndTAndBytePack1<string>>), typeof(Size32<ByteAndTAndBytePack1<string>>), typeof(Size33<ByteAndTAndBytePack1<string>>), typeof(Size34<ByteAndTAndBytePack1<string>>))]
    public void GenericFieldTest_ByteAndTAndBytePack1_string_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(System.Int128), typeof(SequentialStruct1<System.Int128>), typeof(Size3<System.Int128>), typeof(Size32<System.Int128>), typeof(Size33<System.Int128>), typeof(Size34<System.Int128>))]
    public void GenericFieldTest_System_Int128<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(System.Runtime.Intrinsics.Vector64<byte>), typeof(SequentialStruct1<System.Runtime.Intrinsics.Vector64<byte>>), typeof(Size3<System.Runtime.Intrinsics.Vector64<byte>>), typeof(Size32<System.Runtime.Intrinsics.Vector64<byte>>), typeof(Size33<System.Runtime.Intrinsics.Vector64<byte>>), typeof(Size34<System.Runtime.Intrinsics.Vector64<byte>>))]
    public void GenericFieldTest_System_Runtime_Intrinsics_Vector64_byte_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(System.Runtime.Intrinsics.Vector128<byte>), typeof(SequentialStruct1<System.Runtime.Intrinsics.Vector128<byte>>), typeof(Size3<System.Runtime.Intrinsics.Vector128<byte>>), typeof(Size32<System.Runtime.Intrinsics.Vector128<byte>>), typeof(Size33<System.Runtime.Intrinsics.Vector128<byte>>), typeof(Size34<System.Runtime.Intrinsics.Vector128<byte>>))]
    public void GenericFieldTest_System_Runtime_Intrinsics_Vector128_byte_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(System.Runtime.Intrinsics.Vector256<byte>), typeof(SequentialStruct1<System.Runtime.Intrinsics.Vector256<byte>>), typeof(Size3<System.Runtime.Intrinsics.Vector256<byte>>), typeof(Size32<System.Runtime.Intrinsics.Vector256<byte>>), typeof(Size33<System.Runtime.Intrinsics.Vector256<byte>>), typeof(Size34<System.Runtime.Intrinsics.Vector256<byte>>))]
    public void GenericFieldTest_System_Runtime_Intrinsics_Vector256_byte_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(System.Runtime.Intrinsics.Vector512<byte>), typeof(SequentialStruct1<System.Runtime.Intrinsics.Vector512<byte>>), typeof(Size3<System.Runtime.Intrinsics.Vector512<byte>>), typeof(Size32<System.Runtime.Intrinsics.Vector512<byte>>), typeof(Size33<System.Runtime.Intrinsics.Vector512<byte>>), typeof(Size34<System.Runtime.Intrinsics.Vector512<byte>>))]
    public void GenericFieldTest_System_Runtime_Intrinsics_Vector512_byte_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(System.Runtime.InteropServices.GCHandle), typeof(SequentialStruct1<System.Runtime.InteropServices.GCHandle>), typeof(Size3<System.Runtime.InteropServices.GCHandle>), typeof(Size32<System.Runtime.InteropServices.GCHandle>), typeof(Size33<System.Runtime.InteropServices.GCHandle>), typeof(Size34<System.Runtime.InteropServices.GCHandle>))]
    public void GenericFieldTest_System_Runtime_InteropServices_GCHandle<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(System.Runtime.InteropServices.GCHandle?), typeof(SequentialStruct1<System.Runtime.InteropServices.GCHandle?>), typeof(Size3<System.Runtime.InteropServices.GCHandle?>), typeof(Size32<System.Runtime.InteropServices.GCHandle?>), typeof(Size33<System.Runtime.InteropServices.GCHandle?>), typeof(Size34<System.Runtime.InteropServices.GCHandle?>))]
    public void GenericFieldTest_System_Runtime_InteropServices_GCHandle_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndByte<System.Runtime.InteropServices.GCHandle>), typeof(SequentialStruct1<ByteAndTAndByte<System.Runtime.InteropServices.GCHandle>>), typeof(Size3<ByteAndTAndByte<System.Runtime.InteropServices.GCHandle>>), typeof(Size32<ByteAndTAndByte<System.Runtime.InteropServices.GCHandle>>), typeof(Size33<ByteAndTAndByte<System.Runtime.InteropServices.GCHandle>>), typeof(Size34<ByteAndTAndByte<System.Runtime.InteropServices.GCHandle>>))]
    public void GenericFieldTest_ByteAndTAndByte_System_Runtime_InteropServices_GCHandle_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

    [Test]
    [GenerateGenericTest(typeof(ByteAndTAndBytePack1<System.Runtime.InteropServices.GCHandle>), typeof(SequentialStruct1<ByteAndTAndBytePack1<System.Runtime.InteropServices.GCHandle>>), typeof(Size3<ByteAndTAndBytePack1<System.Runtime.InteropServices.GCHandle>>), typeof(Size32<ByteAndTAndBytePack1<System.Runtime.InteropServices.GCHandle>>), typeof(Size33<ByteAndTAndBytePack1<System.Runtime.InteropServices.GCHandle>>), typeof(Size34<ByteAndTAndBytePack1<System.Runtime.InteropServices.GCHandle>>))]
    public void GenericFieldTest_ByteAndTAndBytePack1_System_Runtime_InteropServices_GCHandle_<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
        where TSequentialStruct1 : struct, ISupportFieldAddress
    => GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();

}
