//  AliasDirective.cs
// Namespace Declaration
using System;
using csTut = csharp_station.tutorial.myExample; // alias

// Program start class
class AliasDirective 
{
    // Main begins program execution.
    public static void Main() 
    {
        // Call namespace member
        csTut.myPrint();
        myPrint();
    }

    // Potentially ambiguous method.
    static void myPrint() 
    {
        Console.WriteLine("Not a member of csharp_station.tutorial.myExample.");
    }
}

// C# Station Tutorial Namespace
namespace csharp_station.tutorial 
{
    class myExample 
    {
        public static void myPrint() 
        {
            Console.WriteLine("This is a member of csharp_station.tutorial.myExample.");
        }
    }
}

