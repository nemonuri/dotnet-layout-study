#!/usr/bin/env dotnet

using System.Runtime.CompilerServices;
using System.Text;

const string GenericConstraint = "where TSequentialStruct1 : struct, ISupportFieldAddress";

static FileInfo GetOutputFileInfo([CallerFilePath] string thisFilePath = "")
{
    var path = Path.Combine([thisFilePath, "..", "..", "src", "test", "Nemonuri.DotNetLayoutStudy.Tests.TUnit", "SequentialStruct1Test.g.cs"]);
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
"ByteAndTAndByte<string>",
"ByteAndTAndBytePack1<string>",
"System.Int128",
"System.Runtime.Intrinsics.Vector64<byte>",
"System.Runtime.Intrinsics.Vector128<byte>",
"System.Runtime.Intrinsics.Vector256<byte>",
"System.Runtime.Intrinsics.Vector512<byte>",
"System.Runtime.InteropServices.GCHandle",
"System.Runtime.InteropServices.GCHandle?",
"ByteAndTAndByte<System.Runtime.InteropServices.GCHandle>",
"ByteAndTAndBytePack1<System.Runtime.InteropServices.GCHandle>",
"ExplicitObjectStruct",
"ExplicitObjectStruct?",
"ByteAndTAndByte<ExplicitObjectStruct>",
"ByteAndTAndBytePack1<ExplicitObjectStruct>"
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
    sb.Append("[GenerateGenericTest(");
    sb.AppendJoin(", ", typeOfWraps);
    sb.Append(")]");
    return sb.ToString();
}

static string SelectTestMethod(string typeArg)
{
    StringBuilder sb = new();
    sb.Indent().AppendLine("[Test]");
    sb.Indent().AppendLine(SelectGenerateGenericTestAttribute(typeArg));
    sb.Indent().Append("public void GenericFieldTest_").Append(typeArg.ReplaceInvalidChars()).AppendLine("<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>()");
    sb.Indent().Indent().AppendLine(GenericConstraint);
    sb.Indent().AppendLine("=> GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>();");
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

"""    
);

sb.AppendLine
(
$$"""
    internal void GenericFieldTestCore<T, TSequentialStruct1, TSize3, TSize32, TSize33, TSize34>() 
        {{GenericConstraint}}
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
"""
);

sb.AppendLine();
sb.AppendJoin(Environment.NewLine, GetTypeArguments().Select(SelectTestMethod));
sb.AppendLine();

sb.AppendLine("}");

string fullPath = GetOutputFileInfo().FullName;
File.WriteAllText(fullPath, sb.ToString());

Console.WriteLine($"Complete. Path={fullPath}");

file static class StringExtensions
{
    const string IndentValue = "    ";

    extension(string str)
    {
        public string ReplaceInvalidChars()
        {
            ReadOnlySpan<char> chars = str.AsSpan();
            Span<char> destChars = stackalloc char[chars.Length];
            chars.ReplaceAny(destChars, System.Buffers.SearchValues.Create(['.', '<', '>', '?', '[', ']']), '_');
            return new string(destChars);
        }
    }

    extension(StringBuilder sb)
    {
        public StringBuilder Indent() => sb.Append(IndentValue);
    }
}