// Calculate part of day based on Hour
using System;
class AmPm
{
	public static void Main()
	{
	Console.Write (  "Please enter the hour 0 - 24: " ) ;
	int iTimeOfDay = int.Parse ( Console.ReadLine () ) ; 	

	if  ( iTimeOfDay < 12 ) 
	Console.Write (  "Good Morning" ) ;
	if ( ( iTimeOfDay >= 12 ) && ( iTimeOfDay < 18 ) )
	Console.Write (  "Good Afternoon" ) ;
	if ( iTimeOfDay >= 18 ) 
	Console.Write (  "Good Evening" ) ;
	}
}
