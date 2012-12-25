// DrawingObject.cs
// A Base Class With a Virtual Method
using System;

public class DrawingObject
{
    public virtual void Draw()
    {
        Console.WriteLine("I'm just a generic drawing object.");
    }
} 
