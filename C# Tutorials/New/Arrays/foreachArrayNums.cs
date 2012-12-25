using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorials.MyArray
{
    class WriteArray
    {
        static void Main()
        {
        // Initialize an Array of 6 shorts
        sbyte[] MyArray = new sbyte[] { 1, 2, 3, 4, 2, 7 } ; 

        foreach ( int iArraySpace in MyArray ) // Step through each field in the Array
        Console.WriteLine( iArraySpace ); // Print each

        }
    }
}
