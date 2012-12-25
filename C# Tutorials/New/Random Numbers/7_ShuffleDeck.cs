// ShuffleDeck.cs
// Create an Array of 53 Cards ( 0 - 52 )
// Store Value from 1 to 52 in corresponding Array location using a For Loop
// Shuffle the Array values by swapping each consecutive Array Cell with another random Cell
// Then print the values to the screen ( ignoring location 0 )

using System ;
public class ArrayCards
       {
         static void Main ( )
         {
         // Local Declarations
         const int Cards = 53 ; 

          // Create an Array of 53 "Cards" 
         int[ ] Deck = new int[ Cards ]  ;  

          // Starting at 1, cycle through each and insert the appropriate number 
         // by assigning the current value of iCounter to the corresponding
         // Array Cell each time the For Loop cycles through 

          for ( int iCounter = 1 ; iCounter < Cards ; iCounter++ ) 
         Deck[ iCounter ] = iCounter ; 

          // Use another For Loop to print them out sequencially          
         for (int iCounter = 1; iCounter < Cards ; iCounter++ ) 
         Console.WriteLine( Deck[ iCounter ] ) ;  

	 /* ========= Shuffle the deck ======== */
	 // Declare an Instance of Random Class outside the Loop
	Random MyRandNumb = new Random() ;

   for ( int iCounter = 1 ; iCounter < Cards ; iCounter++ ) 
{
	 // Generate Random number from 1 to CardNum - 1
	int RandomCard = MyRandNumb.Next(1, Cards) ;

	Deck[ 0 ] = Deck[ iCounter ] ; // Store random card in extra space 0
	Deck[ iCounter ] = Deck[ RandomCard ] ; // Swap two random cards
	Deck[ RandomCard ] = Deck[ 0 ] ; // Put spare card back in leftover space
}
  
          // Print them out sequencially          
         for (int iCounter = 1; iCounter < Cards ; iCounter++ ) 
         Console.WriteLine( Deck[ iCounter ] ) ;  
 
         } // end Main 
} //  end ArrayCards