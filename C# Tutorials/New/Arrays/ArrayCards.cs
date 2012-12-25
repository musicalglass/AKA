// ArrayCards.cs
// Create an Array of 53 Cards ( 0 - 52 )
// Store Value from 1 to 52 in corresponding Array location using a For Loop
// Then print the values to the screen ( ignoring location 0 )

using System ;
public class ArrayCards
       {
         static void Main ( )
         {
         // Local Declarations
         const int Cards = 53 ; 

          // Create an Array of 53 Cards 
         int[ ] Deck = new int[ Cards ]  ;  

          // Starting at 1, cycle through each and insert the appropriate number 
         // by assigning the current value of iCounter to the corresponding
         // array location each time the For Loop cycles through 

          for ( int iCounter = 1 ; iCounter < Cards ; iCounter++ ) 
         Deck[ iCounter ] = iCounter ; 

          // Use another For Loop to print them out sequencially          
         for (int iCounter = 1; iCounter < Cards ; iCounter++ ) 
         Console.WriteLine( Deck[ iCounter ] ) ;  
 
         } // end Main 
} //  end ArrayCards