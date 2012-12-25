using System;

class ForEachLoop
{
    public static void Main()
    {
        string[] names = { "Cheryl", "Joe", "Matt", "Robert" } ;

        foreach ( string person in names )
        {
            Console.WriteLine ( "{0} ", person ) ;
        }
    }
}