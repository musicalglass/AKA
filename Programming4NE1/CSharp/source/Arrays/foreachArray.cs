using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class ArrayChar
    {
        static void Main(  )
        {
        int[ ] MyNums = { 7 , 3 , 2 , 9 , 0 } ; // Assign some Variables to an Array of 5
	
        Console.WriteLine ( MyNums[ 1 ] ); // Write the second digit ( 0 1 2 3 4 )

         foreach (int i in MyNums) // Use a foreach loop to write them all
         {
          System.Console.Write(i);
         }

        }
    }
}
