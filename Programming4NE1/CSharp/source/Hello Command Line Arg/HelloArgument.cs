// This application accepts an argument from the Command Line
// To run it from the Command Line, type: NameOfApplication SomeName
// Namespace Declaration
using System;

// Program start class
class NamedWelcome
{
    // Main begins program execution.
    public static void Main( string[ ] args )
    {
        // Write to console
        Console.WriteLine( "Hello, {0}!", args[0] ) ;
    }
} 