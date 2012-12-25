using System;

class IfSelect
{
    public static void Main()
    {
        string myInput;
        int myInt; 

        Console.Write("Please enter a number: ");
        myInput = Console.ReadLine();
        myInt = Int32.Parse(myInput);  // Parse input string into numerical value

        // Single Decision and Action with brackets
        if (myInt > 0)
        {
            Console.WriteLine("Your number {0} is greater than zero.", myInt);
        } 

        // Single Decision and Action without brackets
        if (myInt < 0) 
            Console.WriteLine("Your number {0} is less than zero.", myInt); 

        // Either/Or Decision
        if (myInt != 0)
        {
            Console.WriteLine("Your number {0} is not equal to zero.", myInt);
        }
        else
       {
            Console.WriteLine("Your number {0} is equal to zero.", myInt);
        } 

        // Multiple Case Decision
        if (myInt < 0 || myInt == 0)
        {
            Console.WriteLine("Your number {0} is less than or equal to zero.", myInt);
        }
        else if (myInt > 0 && myInt <= 10)
        {
            Console.WriteLine("Your number {0} is in the range from 1 to 10.", myInt);
        }
        else if (myInt > 10 && myInt <= 20)
        {
            Console.WriteLine("Your number {0} is in the range from 11 to 20.", myInt);
        }
        else if (myInt > 20 && myInt <= 30)
        {
            Console.WriteLine("Your number {0} is in the range from 21 to 30.", myInt);
        }
        else
       {
            Console.WriteLine("Your number {0} is greater than 30.", myInt);
        }
    }
} 