using System ; 

class NumericRepresentation
{
	static void Main()
	{
		short NumberOfPages;
		short Temperature;

		NumberOfPages = 842;
		Temperature   = -1544;

		Console.Write("Number of Pages of the book: ");
		Console.WriteLine(NumberOfPages);
		Console.Write("Temperature to reach during the experiment: ");
		Console.Write(Temperature);
		Console.WriteLine(" degrees\n");
	}
}