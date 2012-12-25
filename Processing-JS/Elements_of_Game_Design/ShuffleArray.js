		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


/*<Description> Randomly sort an Array by swapping each entry with a Random entry. </Description>*/

var SIZE_OF_DECK = 26; // Set the size of our Array
var LINE_WIDTH = 14; // Distance in pixels to next new line of Text

// Create an Array of Cards, plus 1 extra swap space ;)
var deckOfCards = [SIZE_OF_DECK + 1]; 

// Populate Array with corresponding numbers
for (var i = 0; i <= SIZE_OF_DECK; i++) { // i gets incremented by 1
    deckOfCards[i] = i; // Cycle through each and write the value
}

// Skipping Array location 0, print the values onscreen
    fill(0, 0, 0); // Set Text color
for (var i = 1; i <= SIZE_OF_DECK; i++) { 
    text(deckOfCards[i], 100, i * LINE_WIDTH); // Print on new line
}

// Shuffle the Deck
// Skipping Array location 0, go through each card in the deck
for (var i = 1; i <= SIZE_OF_DECK; i++) {
// Copy first card into the Swap Space at Array[0]
    deckOfCards[0] = deckOfCards[i];
// Generate a random whole number by rounding off the decimals
    var randomCard = round( random(1, SIZE_OF_DECK) );
// Overwrite the first card with random card
    deckOfCards[i] = deckOfCards[randomCard];
// Move copy of first card from Swap Space to 2nd card space
    deckOfCards[randomCard] = deckOfCards[0];
}

// Print the new values to the screen
for (var i = 1; i <= SIZE_OF_DECK; i++) { 
    text(deckOfCards[i], 230, i * LINE_WIDTH); 
}

// Tutorials in plain English by Dillinger 2012


		}};