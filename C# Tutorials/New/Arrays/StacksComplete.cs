using System;
using System.Collections;
public class myStack
{
   public static void Main()
   { 	// Create and instantiate new Stack
      Stack myStack = new Stack();
	  	// Adding 4 objects to the stack
      myStack.Push("Vijay");
      myStack.Push("Vikas");
      myStack.Push("Emill");
      myStack.Push("Rajiv");
      // Create and initialize one-dimensional Array
      Array myArray=Array.CreateInstance(typeof(String),15);
      // Add 5 elements to the array
      myArray.SetValue("student1", 0);
      myArray.SetValue("student2", 1);
      myArray.SetValue("student3", 2);
      myArray.SetValue("student4", 3);
      myArray.SetValue("student5", 4);
      // Count the number of objects in the stack
      Console.Write("Total number of objects in the stack : " );
      Console.Write(myStack.Count);
      // Print all the objects in the stack
      Console.Write("\nThe objects are :");
      PrintValues(myStack);
      Console.WriteLine();
      Console.WriteLine("\tObject no \t3\t2\t1\t0");
			// Remove an element from the stack (Last In First Out)
			Console.WriteLine();
			Console.WriteLine("Pop method removes and shows Last element from the 
stact first");
			Console.Write("The element removed is : " );
			Console.Write("\t{0}", myStack.Pop());
			// Show an element from the stack
			Console.WriteLine("\nPeek method just shows an element but does not 
remove it from the stack");
			Console.Write("The element shown is : " );
			Console.Write("\t{0}", myStack.Peek());
			Console.WriteLine();
			// Count and print the number of objects in the stack
      Console.Write("\nTotal remaining number of objects in the stack : " );
      Console.Write(myStack.Count);
      Console.WriteLine();
      Console.Write("\nThe objects are :");
      PrintValues(myStack);
      Console.WriteLine();
      Console.WriteLine("\tObject no \t2\t1\t0");;
	  	// Clear the Stack.
	  	myStack.Clear();
      Console.WriteLine();
      Console.Write("The stack is cleared. Now, total number of objects = 
");
      Console.Write(myStack.Count);
      Console.WriteLine();
			// Refill the stack with different values
			myStack.Push("Patil");
			myStack.Push("Agarwal");
			myStack.Push("Tsankov");
			myStack.Push("Gomes");
			myStack.Push("Smith");
			// Count and print the number of objects in the stack
			Console.WriteLine();
			Console.Write("Total number of NEW objects in the stack : " );
			Console.Write(myStack.Count);
			Console.WriteLine();
			Console.Write("\nThe objects are :");
			PrintValues(myStack);
			Console.WriteLine();
			Console.WriteLine("\tObject no \t4\t3\t2\t1\t0");
			Console.WriteLine();
      // Display the values of the target Array instance.
      Console.WriteLine( "The target Array contains following elements 
BEFORE copying):" );
      PrintValues(myArray,' ');
      // Copy the entire source Stack to the target Array instance, starting 
at index 3.
      myStack.CopyTo( myArray, 3 );
      Console.WriteLine();
      Console.WriteLine( "The target Array contains following elements AFTER 
copying):" );
      PrintValues(myArray,' ');
}
  public static void PrintValues(Array myArr, char mySeparator)
  {   System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
      int i = 0;
      int cols = myArr.GetLength( myArr.Rank - 1 );
      while ( myEnumerator.MoveNext() )
      {  	if ( i < cols )
      				{ i++; }
      		else
      				{Console.WriteLine();i = 1;}
         Console.Write( "{0}{1}", mySeparator, myEnumerator.Current );
      }
      Console.WriteLine();
   }
   public static void PrintValues( IEnumerable myCollection )
   {
      System.Collections.IEnumerator myEnumerator = 
myCollection.GetEnumerator();
      while ( myEnumerator.MoveNext() )
         Console.Write( "\t{0}", myEnumerator.Current );
   }
}
