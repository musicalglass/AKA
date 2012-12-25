// BasicAttributeDemo.cs
//  How to Use Attributes
using System;

class BasicAttributeDemo
{
    [Obsolete]
    public void MyFirstDeprecatedMethod()
    {
        Console.WriteLine("Called MyFirstDeprecatedMethod().");
    }

    [ObsoleteAttribute]
    public void MySecondDeprecatedMethod()
    {
        Console.WriteLine("Called MySecondDeprecatedMethod().");
    }

    [Obsolete("You shouldn't use this method anymore.")]
    public void MyThirdDeprecatedMethod()
    {
        Console.WriteLine("Called MyThirdDeprecatedMethod().");
    }

    // make the program thread safe for COM
    [STAThread]
    static void Main(string[] args)
    {
        BasicAttributeDemo attrDemo = new BasicAttributeDemo();

        attrDemo.MyFirstDeprecatedMethod();
        attrDemo.MySecondDeprecatedMethod();
        attrDemo.MyThirdDeprecatedMethod();
    }
}

