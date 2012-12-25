// EnumTricks.cs
// Enum Conversions and using the System.Enum Type
using System;

// declares the enum
public enum Volume : byte
{
    Low = 1,
    Medium,
    High
}

// shows different ways
// to work with enums
class EnumTricks
{
    static void Main(string[] args)
    {
        // instantiate type
        EnumTricks enumTricks = new EnumTricks();

        // demonstrates explicit cast
        // of int to Volume
        enumTricks.GetEnumFromUser();

        // iterate through Volume enum by name
        enumTricks.ListEnumMembersByName();

        // iterate through Volume enum by value
        enumTricks.ListEnumMembersByValue();

        Console.ReadLine();
    }

    // demonstrates explicit cast
    // of int to Volume
    public void GetEnumFromUser()
    {
        Console.WriteLine("\n----------------");
        Console.WriteLine("Volume Settings:");
        Console.WriteLine("----------------\n");

        Console.Write(@"
1 - Low
2 - Medium
3 - High

Please select one (1, 2, or 3): ");

        // get value user provided
        string volString = Console.ReadLine();
        int volInt = Int32.Parse(volString);

        // perform explicit cast from
        // int to Volume enum type
        Volume myVolume = (Volume)volInt;

        Console.WriteLine();

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

        Console.WriteLine();
    }

    // iterate through Volume enum by name
    public void ListEnumMembersByName()
    {
        Console.WriteLine("\n---------------------------- ");
        Console.WriteLine("Volume Enum Members by Name:");
        Console.WriteLine("----------------------------\n");

        // get a list of member names from Volume enum,
        // figure out the numeric value, and display
        foreach (string volume in Enum.GetNames(typeof(Volume)))
        {
            Console.WriteLine("Volume Member: {0}\n Value: {1}", 
                volume, (byte)Enum.Parse(typeof(Volume), volume));
        }
    }

    // iterate through Volume enum by value
    public void ListEnumMembersByValue()
    {
        Console.WriteLine("\n----------------------------- ");
        Console.WriteLine("Volume Enum Members by Value:");
        Console.WriteLine("-----------------------------\n");

        // get all values (numeric values) from the Volume
        // enum type, figure out member name, and display
        foreach (byte val in Enum.GetValues(typeof(Volume)))
        {
            Console.WriteLine("Volume Value: {0}\n Member: {1}", 
                val, Enum.GetName(typeof(Volume), val));
        }
    }
}

