using System;

class ArrayOperations
{
    public static void Main()
    {
        int[] myInts = { 5, 10, 15 };
        bool[][] myBools = new bool[2][];
        myBools[0] = new bool[2];
        myBools[1] = new bool[1];
        double[,] myDoubles = new double[2, 2];
        string[] myStrings = new string[3];

        Console.WriteLine("myInts[0]: {0} \nmyInts[1]: {1} \nmyInts[2]: {2}", myInts[0], myInts[1], myInts[2]);

        myBools[0][0] = true;
        myBools[0][1] = false;
        myBools[1][0] = true;
        Console.WriteLine("myBools[0][0]: {0} \nmyBools[1][0]: {1}", myBools[0][0], myBools[1][0]);

        myDoubles[0, 0] = 3.147;
        myDoubles[0, 1] = 7.157;
        myDoubles[1, 1] = 2.117;
        myDoubles[1, 0] = 56.00138917;
        Console.WriteLine("myDoubles[0, 0]: {0} \nmyDoubles[1, 0]: {1}", myDoubles[0, 0], myDoubles[1, 0]);

        myStrings[0] = "Joe";
        myStrings[1] = "Matt";
        myStrings[2] = "Robert";
        Console.WriteLine("myStrings[0]: {0} \nmyStrings[1]: {1} \nmyStrings[2]: {2}", myStrings[0], myStrings[1], myStrings[2]);

    }
} 
