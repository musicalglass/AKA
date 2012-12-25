using System;
using System.Collections.Generic;

class ShuffleList
{
    static void Main()
    {
	// Create a List called Deck
        List<int> Deck = new List<int>();

        for (int iCards = 0; iCards < 52; iCards++)
        {
            Deck.Insert(0, iCards + 1); //PUSH 
        }

        //Shuffle Deck
	// Declare an Instance of Random Class outside the Loop

	Random MyRandNumb = new Random() ;
	       int iSwap = 0;

	foreach (int card in Deck )
        {
	// Generate Random number from 1 to CardNum - 1
	int RandomCard = MyRandNumb.Next(1, 52) ;
            iSwap = Deck[RandomCard];
            Deck.RemoveAt(RandomCard);
	Deck.Insert(0, iSwap);
        }


Console.WriteLine("Count: {0}", Deck.Count);

	// Print them to the screen
        foreach (int card in Deck )
        {
            Console.WriteLine(card);
        }

    }
}
