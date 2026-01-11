using System.Runtime.InteropServices;

namespace Nemonuri.DotNetLayoutStudy;

[StructLayout(LayoutKind.Explicit)]
public struct ExplicitObjectStruct
{
    [FieldOffset(0)]
    public object? Obj1;

    [FieldOffset(8)]
    public object? Obj2;

    public ExplicitObjectStruct(object? obj1, object? obj2)
    {
        Obj1 = obj1;
        Obj2 = obj2;
    }

    public override string ToString() => $"{nameof(Obj1)} = {Obj1}, {nameof(Obj2)} = {Obj2}";
}
