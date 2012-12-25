/* Note: If you create a file called Break.cs, it will compile fine
but when you try to run it by typing break nothing happens
This is because break is a Command Prompt command
go to the Command Prompt and type help
you should avoid using words which are commands as filenames 
you could still run the compiled application by explicitly typing break.exe*/
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