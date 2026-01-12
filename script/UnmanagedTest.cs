#!/usr/bin/env dotnet

using System.Runtime.CompilerServices;


static void WriteValue<T>(T value, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
{
    Writer.Instance.WriteLine($"{valueExpr} = {value}");
}

static void DescribeUnmanagedType<T>() where T : unmanaged, allows ref struct
{
    Writer.Instance.WriteLine(nameof(DescribeUnmanagedType));
    WriteValue(typeof(T).FullName);
    WriteValue(Unsafe.SizeOf<T>());
    WriteValue(RuntimeHelpers.IsReferenceOrContainsReferences<T>());
    WriteValue(typeof(T).IsByRef);
    WriteValue(typeof(T).IsByRefLike);

    T local1 = default;
    T local2 = default;
    WriteValue(Unsafe.ByteOffset(in local2, in local1));

    Writer.Instance.WriteLine();
}

static void DescribeAnyType<T>() where T : allows ref struct
{
    Writer.Instance.WriteLine(nameof(DescribeAnyType));
    WriteValue(typeof(T).FullName);
    WriteValue(Unsafe.SizeOf<T>());
    WriteValue(RuntimeHelpers.IsReferenceOrContainsReferences<T>());
    WriteValue(typeof(T).IsByRef);
    WriteValue(typeof(T).IsByRefLike);

    T local1 = default!;
    T local2 = default!;
    WriteValue(Unsafe.ByteOffset(in local2, in local1));

    Writer.Instance.WriteLine();
}

static void DescribeTypeHandle(RuntimeTypeHandle rth)
{
    Writer.Instance.WriteLine(nameof(DescribeTypeHandle));
    WriteValue(rth.GetType());
    WriteValue(RuntimeHelpers.SizeOf(rth));

    Writer.Instance.WriteLine();
}

DescribeUnmanagedType<int>();
DescribeUnmanagedType<nint>();
DescribeUnmanagedType<EmptyRefStruct>();
DescribeUnmanagedType<SingleFieldRefStruct>();

//DescribeUnmanagedType<SingleRefFieldRefStruct>(); // compile error: CS8377
DescribeAnyType<SingleRefFieldRefStruct>();
DescribeAnyType<Span<byte>>();

//DescribeUnmanagedType<System.RuntimeArgumentHandle(); // compile error: CS0201, CS1955
//DescribeUnmanagedType<System.ArgIterator(); // compile error: CS0201, CS1955
//DescribeUnmanagedType<System.TypedReference(); // compile error: CS0201, CS1955

DescribeTypeHandle(typeof(RuntimeArgumentHandle).TypeHandle);
DescribeTypeHandle(typeof(ArgIterator).TypeHandle);
DescribeTypeHandle(typeof(TypedReference).TypeHandle);

// ...Namespace 가 'System' 인 ref struct 는 그냥 다 managed 라고 봐도 될 듯.

Writer.Instance.Dispose();

public readonly ref struct EmptyRefStruct
{}

public ref struct SingleFieldRefStruct
{
    public int Field0;
}

public ref struct SingleRefFieldRefStruct
{
    public ref int Field0;
}

file static class Writer
{
    public static TextWriter Instance => field ??= GetOutputFileInfo().CreateText();

    private static FileInfo GetOutputFileInfo([CallerFilePath] string thisFilePath = "")
    {
        return new FileInfo(Path.Combine(thisFilePath, "..", "..", "doc", "UnmanagedTest.Result.txt"));
    }
}
