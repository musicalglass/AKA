/*  Continue allows you to bypass executing the loop one time 
if a certain condition is met without breaking out of the loop */
using System;

class ToBeContinued
{
    public static void Main ( ) 
    {
        int iElevator = 0 ; 

        while ( iElevator < 21 )
        {
            iElevator++ ; 
	    if ( iElevator == 13 ) continue ; // If true, skip the next bit
            Console.WriteLine (  "Floor {0}" , iElevator ) ; 
        }
            Console.WriteLine (  "You have reached the top floor" ) ; 
    }
} 