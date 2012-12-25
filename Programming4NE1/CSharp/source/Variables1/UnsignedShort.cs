using System;

class NumericRepresentation
{
	static void Main()
	{
		// These variables must hold only positive integers
		ushort NumberOfTracks;
		ushort MusicCategory;

		NumberOfTracks = 16;
		MusicCategory  = 2;

		Console.Write("This music album contains ");
		Console.Write(NumberOfTracks);
		Console.WriteLine(" tracks");
		Console.Write("Music Category: ");
		Console.Write(MusicCategory);
		Console.WriteLine();
	}
}