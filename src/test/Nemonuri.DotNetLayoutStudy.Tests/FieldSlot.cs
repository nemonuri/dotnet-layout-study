using System.Runtime.CompilerServices;

namespace Nemonuri.DotNetLayoutStudy.Tests;

public readonly struct FieldSlot<T>
{
    public readonly nint UnalignedAddress;

    public readonly nint AlignedAddress;

    public readonly nint NextFieldSlotAddress;

    public FieldSlot(nint unalignedAddress, nint alignedAddress, nint nextFieldSlotAddress)
    {
        UnalignedAddress = unalignedAddress;
        AlignedAddress = alignedAddress;
        NextFieldSlotAddress = nextFieldSlotAddress;
    }

    public nint Padding => AlignedAddress - UnalignedAddress;

    public int UnpromotedSize => Unsafe.SizeOf<T>();

    public int PromotedSize => (int)(NextFieldSlotAddress - AlignedAddress);

    public override string ToString() => 
        $"{nameof(Padding)}={Padding}, {nameof(UnpromotedSize)}={UnpromotedSize}, {nameof(PromotedSize)}={PromotedSize}, " +
        $"{nameof(UnalignedAddress)}={UnalignedAddress}, {nameof(AlignedAddress)}={AlignedAddress}"
        ;
}

public static class FieldSlot
{
    public static unsafe FieldSlot<T> Create<T>(void* unalignedAddress, void* alignedAddress, void* nextFieldSlotAddress) => 
        new((nint)unalignedAddress, (nint)alignedAddress, (nint)nextFieldSlotAddress);
}