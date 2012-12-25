// WriteOnlyProperty.cs
using System;

public class PropertyHolder
{
    private int someProperty = 0;

    public int SomeProperty
    {
        set
       {
            someProperty = value;

            Console.WriteLine("someProperty is equal to {0}", someProperty);
        }
    }
}

public class PropertyTester
{
    public static int Main(string[] args)
    {
        PropertyHolder propHold = new PropertyHolder();

        propHold.SomeProperty = 5;

        return 0;
    }
}

