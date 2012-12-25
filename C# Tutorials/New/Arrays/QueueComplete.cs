using System;
using System.Collections;
public class myQueue
{
   public static void Main()
   { 	// Create and instantiate new queue
      Queue myQueue = new Queue();
	  	// Adding 4 objects to the Queue
      myQueue.Enqueue("Vijay");
      myQueue.Enqueue("Vikas");
      myQueue.Enqueue("Emill");
      myQueue.Enqueue("Rajiv");
      // Create and initialize one-dimensional Array
      Array myArray=Array.CreateInstance(typeof(String),15);
      // Add 5 elements to the array
      myArray.SetValue("student1", 0);
      myArray.SetValue("student2", 1);
      myArray.SetValue("student3", 2);
      myArray.SetValue("student4", 3);
      myArray.SetValue("student5", 4);
      // Count the number of objects in the queue
			Console.Write("Total number of objects in the queue : " );
      Console.Write(myQueue.Count);
      Console.WriteLine();
      // Print all the objects in the stack
      Console.Write("\nThe objects are :");
      PrintValues(myQueue); Console.WriteLine();
      Console.WriteLine("\tObject no \t0\t1\t2\t3");
			// Remove an element from the queue (First In First Out)
			Console.WriteLine();
			Console.WriteLine("Dequeue method removes and shows FIRST element from 
the queue FIRST ");
			Console.Write("The element removed is : " );
			Console.Write("\t{0}", myQueue.Dequeue());Console.WriteLine();
			// Show an element from the queue
			Console.WriteLine("\nPeek method just shows an element but does not 
remove it from the queue");
			Console.Write("The element shown is : " );
			Console.Write("\t{0}", myQueue.Peek());
			// Count and print the number of objects in the stack
      Console.WriteLine();
      Console.Write("\nTotal remaining number of objects in the queue : " );
      Console.Write(myQueue.Count);
      Console.WriteLine();
      Console.Write("\nThe objects are :");
      PrintValues(myQueue);
      Console.WriteLine();
      Console.WriteLine("\tObject no \t0\t1\t2");
      Console.WriteLine();
	  	// Clear the Stack.
	  	myQueue.Clear();
      Console.Write("The queue is cleared. Now, total number of objects = 
");
      Console.Write(myQueue.Count);
      Console.WriteLine();
			// Refill the stack with different values
			myQueue.Enqueue("Patil");
			myQueue.Enqueue("Agarwal");
			myQueue.Enqueue("Tsankov");
			myQueue.Enqueue("Gomes");
			myQueue.Enqueue("Smith");
			// Count and print the number of objects in the stack
			Console.WriteLine();
			Console.Write("Total number of NEW objects in the stack : " );
			Console.Write(myQueue.Count);
			Console.WriteLine();
			Console.Write("\nThe objects are :");
			PrintValues(myQueue);
			Console.WriteLine();
			Console.WriteLine("\tObject no \t0\t1\t2\t3\t4");
      // Display the values of the target Array instance.
      Console.WriteLine();
      Console.WriteLine( "The target Array contains following elements 
BEFORE copying):" );
      PrintValues(myArray,' ');
      // Copy the entire source Stack to the target Array instance, starting 
at index 3.
      myQueue.CopyTo( myArray, 3 );
      Console.WriteLine();
      Console.WriteLine( "The target Array contains following elements AFTER 
copying):" );
      PrintValues(myArray,' ');
}
  public static void PrintValues(Array myArr, char mySeparator)
  {		System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
      int i = 0;
      int cols = myArr.GetLength( myArr.Rank-1);
      while ( myEnumerator.MoveNext())
      {
         if ( i < cols )
         			{  i++; }
         		else
         		{ Console.WriteLine(); i = 1; }
         Console.Write("{0}{1}", mySeparator, myEnumerator.Current);
      }
      Console.WriteLine();
   }
   public static void PrintValues( IEnumerable myCollection )
   { 	System.Collections.IEnumerator myEnumerator = 
myCollection.GetEnumerator();
      while ( myEnumerator.MoveNext() )
         Console.Write( "\t{0}", myEnumerator.Current );
   }
}
