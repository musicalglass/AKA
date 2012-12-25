// TryCatchDemo.cs
// Using try/catch Blocks
using System;
using System.IO;

class TryCatchDemo
{
    static void Main(string[] args)
    {
        try
        {
            File.OpenRead("NonExistentFile");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
