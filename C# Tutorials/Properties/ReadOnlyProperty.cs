//  ReadOnlyProperty.cs
using System;

public class PropertyHolder
{
    private int someProperty = 0;

    public PropertyHolder(int propVal)
    {
        someProperty = propVal;
    }

    public int SomeProperty
    {
        get
       {
            return someProperty;
        }
    }
}

public class PropertyTester
{
    public static int Main(string[] args)
    {
        PropertyHolder propHold = new PropertyHolder(5);

        Console.WriteLine("Property Value: {0}", propHold.SomeProperty);

        return 0;
    }
}

