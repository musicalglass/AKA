//  Classes.cs
// Namespace Declaration
using System;

// helper class
class OutputClass 
{
    string myString;

    // Constructor
    public OutputClass(string inputString) 
    {
        myString = inputString;
    }

    // Instance Method
    public void printString() 
    {
        Console.WriteLine("{0}", myString);
    }

    // Destructor
    ~OutputClass() 
    {
        // Some resource cleanup routines
    }
}

// Program start class
class ExampleClass 
{
    // Main begins program execution.
    public static void Main() 
    {
        // Instance of OutputClass
        OutputClass outCl = new OutputClass("This is printed by the output class.");

        // Call Output class' method
        outCl.printString(); 
    }
}
