using System;

public class Exercise
{
	static void Main()
	{
		const double ConversionFactor = 39.37;
		double Meter, Inch;
		
		Meter = 12.52;
		Inch = Meter * ConversionFactor;
		Console.WriteLine("{0}m = {1}in\n", Meter, Inch);
		
		Meter = 12.52;
		Inch = Meter * ConversionFactor;
		Console.WriteLine("{0}m = {1}in\n", Meter, Inch);
		
		Meter = 12.52;
		Inch = Meter * ConversionFactor;
		Console.WriteLine("{0}m = {1}in\n", Meter, Inch);
	}
}
