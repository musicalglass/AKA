// AttributeTargetDemo.cs
//  Using Positional and Named Attribute Parameters
using System;

[assembly:CLSCompliant(true)]

public class AttributeTargetDemo
{
    public void NonClsCompliantMethod(uint nclsParam)
    {
        Console.WriteLine("Called NonClsCompliantMethod().");
    }

    [STAThread]
    static void Main(string[] args)
    {
        uint myUint = 0;

        AttributeTargetDemo tgtDemo = new AttributeTargetDemo();

        tgtDemo.NonClsCompliantMethod(myUint);
    }
}

