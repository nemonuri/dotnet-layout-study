using System.Runtime.CompilerServices;

namespace Nemonuri.DotNetLayoutStudy.Tests;

public static class TestOutputHelperExtensions
{
    extension(ITestOutputHelper self)
    {
        public unsafe void WriteValue(void* ptr, [CallerArgumentExpression(nameof(ptr))] string ptrExpr = "")
        {
            self.WriteLine($"{ptrExpr} = {(nint)ptr}");
        }

        public void WriteValue<TValue>(TValue value, [CallerArgumentExpression(nameof(value))] string ptrExpr = "")
        {
            self.WriteLine($"{ptrExpr} = {value}");
        }
    }
}