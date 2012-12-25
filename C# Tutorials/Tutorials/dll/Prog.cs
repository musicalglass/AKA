using System;
class Prog{
static void Main() {
Counter c = new Counter();
c.Add(3); c.Add(5);
Console.WriteLine("val = " + c.Val());
}
}