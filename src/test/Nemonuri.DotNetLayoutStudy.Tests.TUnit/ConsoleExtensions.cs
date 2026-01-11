using System.Runtime.CompilerServices;

namespace Nemonuri.DotNetLayoutStudy.Tests;

public static class ConsoleExtensions
{
    extension(System.Console)
    {
        public unsafe static void WriteValue(void* ptr, [CallerArgumentExpression(nameof(ptr))] string ptrExpr = "")
        {
            Console.WriteLine($"{ptrExpr} = {(nint)ptr}");
        }

        public static void WriteValue<TValue>(TValue value, [CallerArgumentExpression(nameof(value))] string ptrExpr = "")
        {
            Console.WriteLine($"{ptrExpr} = {value}");
        }
    }
}