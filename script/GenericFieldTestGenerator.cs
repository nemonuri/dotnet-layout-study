#!/usr/bin/env dotnet

using System.Runtime.CompilerServices;
using System.Text;

static FileInfo GetOutputFileInfo([CallerFilePath] string thisFilePath = "")
{
    var path = Path.Combine([thisFilePath, "..", "..", "src", "Nemonuri.DotNetLayoutStudy.Tests.TUnit", "SequentialStruct1Test.g.cs"]);
    return new FileInfo(path);
}

static string[] GetTypeArguments() => 
[
"Empty",
"byte",
"char",
"short",
"int",
"float",
"long",
"nint",
"object",
"string",
"int[]",
"int?",
"ByteAndTAndByte<byte>",
"ByteAndTAndBytePack1<byte>",
"ByteAndTAndByte<char>",
"ByteAndTAndBytePack1<char>",
"ByteAndTAndByte<int>",
"ByteAndTAndBytePack1<int>",
"System.Int128",
"System.Runtime.Intrinsics.Vector64<byte>",
"System.Runtime.Intrinsics.Vector128<byte>",
"System.Runtime.Intrinsics.Vector256<byte>",
"System.Runtime.Intrinsics.Vector512<byte>"
];

static string SelectGenerateGenericTestAttribute(string typeArg)
{
    string[] typeParams = 
    [
        typeArg, $"SequentialStruct1<{typeArg}>", $"Size3<{typeArg}>",
        $"Size32<{typeArg}>", $"Size33<{typeArg}>", $"Size34<{typeArg}>"
    ];
    var typeOfWraps = typeParams.Select(static a => $"typeof({a})");

    StringBuilder sb = new();
    sb.Append("    [GenerateGenericTest(");
    sb.AppendJoin(", ", typeOfWraps);
    sb.Append(")]");
    return sb.ToString();
}

StringBuilder sb = new ();

sb.AppendLine
(
"""
using Nemonuri.DotNetLayoutStudy.Promoted;

namespace Nemonuri.DotNetLayoutStudy.Tests;

public partial class SequentialStruct1Test
{

    [Test]
"""    
);

sb.AppendJoin(Environment.NewLine, GetTypeArguments().Select(SelectGenerateGenericTestAttribute));
sb.AppendLine();

sb.AppendLine
(
"""
    public unsafe void GenericFieldTest<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()
    {
#pragma warning disable CS8500
        // Arrange
        TSequentialStruct1 s = new();
        TSequentialStruct1* baseAddress = &s;
        TSize3* field0Address = &s.Field0;
        TSize32* field1Address = &s.Field1;
        TSize33* field2Address = &s.Field2;
        TSize34* field3Address = &s.Field3;

        // Act
        Console.WriteValue(typeof(TSequentialStruct1).Name);
        Console.WriteValue(FieldSlot.Create<TSize3>(baseAddress, field0Address, field1Address));
        Console.WriteValue(FieldSlot.Create<TSize32>(field0Address+1, field1Address, field2Address));
        Console.WriteValue(FieldSlot.Create<TSize33>(field1Address+1, field2Address, field3Address));
        Console.WriteValue(FieldSlot.Create<TSize34>(field2Address+1, field3Address, baseAddress + 1));

        // Assert

#pragma warning restore CS8500
    }
"""
);

sb.AppendLine("}");

string fullPath = GetOutputFileInfo().FullName;
File.WriteAllText(fullPath, sb.ToString());

Console.WriteLine($"Complete. Path={fullPath}");
