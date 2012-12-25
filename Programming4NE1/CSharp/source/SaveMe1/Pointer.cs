using System;

class Exercise
{
	unsafe static void Main()
	{
		int Length = 224;
		// The Len variable is a pointer
		int *Len = &Length;
		
		Console.Write("Length ");
		Console.WriteLine(Length);
		Console.Write("Length ");
		Console.WriteLine(*Len);
		Console.WriteLine();

		Length = 804;
		Console.Write("Length ");
		Console.WriteLine(Length);
		Console.Write("Length ");
		Console.WriteLine(*Len);
	}
}
 
