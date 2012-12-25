using System;

class SwitchSelect
{
    public static void Main()
    {
        string myInput;
        int myInt;

        begin:

        Console.Write("Please enter a number between 1 and 3: ");
        myInput = Console.ReadLine();
        myInt = Int32.Parse(myInput);

        // switch with integer type
        switch (myInt)
        {
            case 1:
                Console.WriteLine("Chapter 1. In the beginning there was nothing...");
                break;
            case 2:
                Console.WriteLine("Chapter 2. In the middle there wasn't much to speak of either");
                break;
            case 3:
                Console.WriteLine("Chapter 3. In the end, you ain't nothin but a pimple on the Buddha's butt");
                break;
            default:
                Console.WriteLine("Your number {0} is not between 1 and 3.", myInt);
                break;
        }

        decide:

        Console.Write("Type \"continue\" to go on or \"quit\" to stop: ");
        myInput = Console.ReadLine();

        // switch with string type
        switch (myInput)
        {
            case "continue":
                goto begin;
            case "quit":
                Console.WriteLine("Bye.");
                break;
            default:
                Console.WriteLine("Your input {0} is incorrect.", myInput);
                goto decide;
        }
    }
} 

