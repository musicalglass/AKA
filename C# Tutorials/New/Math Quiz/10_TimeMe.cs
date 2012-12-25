using System;
public class TimeMe
{
    static void Main()
    {
    /* Read the initial time. */
    DateTime startTime = DateTime.Now;
    Console.Write("\nStart Time: "); Console.WriteLine(startTime);

    /* Do something that takes up some time. For example sleep for 1.7 seconds. */
	Console.Write ( "\nEnter something to burn some time " ) ;  // Prompt the user for input
	String UserInput = Console.ReadLine() ;  // Store whatever user types in Variable

    /* Read the end time. */
    DateTime stopTime = DateTime.Now;
    Console.Write("Stop Time: "); Console.WriteLine(stopTime);

    /* Compute the duration between the initial and the end time. 
     * Print out the number of elapsed hours, minutes, seconds and milliseconds. */
    TimeSpan duration = stopTime - startTime;
    Console.Write("\nIt took you ");
    Console.Write(duration.TotalSeconds);
    Console.WriteLine(" seconds to respond");

    }
}