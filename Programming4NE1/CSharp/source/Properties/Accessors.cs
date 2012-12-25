//  Accessors.cs
//  An Example of Traditional Class Field Access 
using System;

public class PropertyHolder
{
    private int someProperty = 0;

    public int getSomeProperty()
    {
        return someProperty;
    }

    public void setSomeProperty(int propValue)
    {
        someProperty = propValue;
    }

}

public class PropertyTester
{
    public static int Main(string[] args)
    {
        PropertyHolder propHold = new PropertyHolder();

        propHold.setSomeProperty(5);

        Console.WriteLine("Property Value: {0}", propHold.getSomeProperty());

        return 0;
    }
} 

