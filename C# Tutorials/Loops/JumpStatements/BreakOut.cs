/* Note: If you create a file called Break.cs, it will compile fine
but when you try to run it by typing break nothing happens
This is because break is a Command Prompt command
Go to the Command Prompt and type help to see the full list of commands
You should avoid using words which are commands as filenames 
You could still run the compiled application by explicitly typing break.exe
*/
using System;

class GimmeABreak
{
    public static void Main()
    {
        int myInt = 0 ; 

        while ( true ) // This will create an infinite loop
        {
            Console.WriteLine (  myInt ) ; 
            myInt++ ; 
	    if ( myInt > 10 ) break ; 
        }
            Console.WriteLine (  "The loop done broke" ) ; 
    }
} 