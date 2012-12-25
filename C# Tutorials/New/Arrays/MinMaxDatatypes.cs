// DataTypes.cs 
using System;
class DataTypes
{
    static void Main()
    {
        Console.WriteLine("The minimum and maximum sizes of C#'s datatypes:\n");
        Console.WriteLine("sbyte\nMin: {0}\nMax: {1}\n", sbyte.MinValue, sbyte.MaxValue);
        Console.WriteLine("byte\nMin: {0}\nMax: {1}\n", byte.MinValue, byte.MaxValue);
        Console.WriteLine("short\nMin: {0}\nMax: {1}\n", short.MinValue, short.MaxValue);
        Console.WriteLine("ushort\nMin: {0}\nMax: {1}\n", ushort.MinValue, ushort.MaxValue);
        Console.WriteLine("int\nMin: {0}\nMax: {1}\n", int.MinValue, int.MaxValue);
        Console.WriteLine("uint\nMin: {0}\nMax: {1}\n", uint.MinValue, uint.MaxValue);
        Console.WriteLine("long\nMin: {0}\nMax: {1}\n", long.MinValue, long.MaxValue);
        Console.WriteLine("ulong\nMin: {0}\nMax: {1}\n", ulong.MinValue, ulong.MaxValue);
        Console.WriteLine("float\nMin: {0}\nMax: {1}\n", float.MinValue, float.MaxValue);
        Console.WriteLine("double\nMin: {0}\nMax: {1}\n", double.MinValue, double.MaxValue);
        Console.WriteLine("decimal\nMin: {0}\nMax: {1}\n", decimal.MinValue, decimal.MaxValue);
        Console.ReadLine(); // Keep the console opened until you press Enter 
    }
}
