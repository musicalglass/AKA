// UsingDirective.cs
// Namespace Declaration
using System;
using csharp_station.tutorial;

// Program start class
class UsingDirective 
{
    // Main begins program execution.
    public static void Main() 
    {
        // Call namespace member
        myExample.myPrint(); 
    }
}

// C# Station Tutorial Namespace
namespace csharp_station.tutorial 
{
    class myExample 
    {
        public static void myPrint() 
        {
            Console.WriteLine("Example of using a using directive.");
        }
    }
}

