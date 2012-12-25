// Properties.cs
//  Accessing Class Fields With Properties
using System;

public class PropertyHolder
{
    private int someProperty = 0;

    public int SomeProperty
    {
        get
       {
            return someProperty;
        }
        set
       {
            someProperty = value;
        }
    }
}

public class PropertyTester
{
    public static int Main(string[] args)
    {
        PropertyHolder propHold = new PropertyHolder();

        propHold.SomeProperty = 5;

        Console.WriteLine("Property Value: {0}", propHold.SomeProperty);

        return 0;
    }
}

