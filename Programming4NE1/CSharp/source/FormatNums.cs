/* Add Two Digits
This program reads long integers from the keyboard
and prints them with leading zeros in the form
006,856 with a comma between the 3rd & 4th digits
Written by: YourName
Date: 11/24/05
*/
// Namespace Declaration
using System;

// Program start class
class InteractiveWelcome
{
    // Main begins program execution.
    public static void Main()
    {

	Console.Write("\nEnter a number with up to 6 digits: ") ;
	int num = int.Parse ( Console.ReadLine () ) ;

	int thousands = num / 1000 ;
	int hundreds = num % 1000 ;

	printf ( "\nThe number you entered is \t%03d,%03d",
			thousands, hundreds ) ;

	}/* main */

} 