using System;
using System.Collections.Generic;

class ShuffleList
{
    static void Main()
    {
       // byte bSwap = 42;
        List<int> Deck = new List<int>();

        for (int bCards = 0; bCards < 52; bCards++)
        {
            Deck.Insert(0, bCards + 1); //PUSH 
        }

        foreach (int card in Deck )
        {
            Console.WriteLine(card);
        }


        //if (Deck.Count > 0) //Check within bounds
        //{
        //    //POP
        //    bSwap = Deck[0];
        //    Deck.RemoveAt(0);
        //}
    }
}
