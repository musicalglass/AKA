using System;

class ForLoop
{
    public static void Main()
    {
        for (int i=0; i < 20; i++)
        {
            if (i == 10)
                break;

            if (i % 2 == 0)
                continue;

            Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }
} 