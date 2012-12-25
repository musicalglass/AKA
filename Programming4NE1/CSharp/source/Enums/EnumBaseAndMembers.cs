// EnumBaseAndMembers.cs
//  Setting the Enum Base and Initializing Members
using System;

// declares the enum
public enum Volume : byte
{
    Low = 1,
    Medium,
    High
}

class EnumBaseAndMembers
{
    static void Main()
    {
        // create and initialize 
        // instance of enum type
        Volume myVolume = Volume.Low;

        // make decision based
        // on enum value
        switch (myVolume)
        {
            case Volume.Low:
                Console.WriteLine("The volume has been turned Down.");
                break;
            case Volume.Medium:
                Console.WriteLine("The volume is in the middle.");
                break;
            case Volume.High:
                Console.WriteLine("The volume has been turned up.");
                break;
        }
        Console.ReadLine();
    }
}

