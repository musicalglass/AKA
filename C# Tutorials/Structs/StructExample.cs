//  StructExample.cs
using System;

struct Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point Add(Point pt)
    {
        Point newPt;

        newPt.x = x + pt.x;
        newPt.y = y + pt.y;

        return newPt;
    }
}

/// <summary>
/// Example of declaring and using a struct
/// </summary>
class StructExample
{
    static void Main(string[] args)
    {
        Point pt1 = new Point(1, 1);
        Point pt2 = new Point(2, 2);
        Point pt3;

        pt3 = pt1.Add(pt2);

        Console.WriteLine("pt3: {0}:{1}", pt3.x, pt3.y);
    }
} 

