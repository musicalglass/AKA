var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//Declare CONSTANT_VARIABLES
var NUM_1 = 7 ; 
var NUM_2 = 5 ; 

var TEXT_LEADING = 14;

//Declare operatorVariables
var textY = 100;
var iResult = 0; 

background(0); // Set color(greyscale)
fill(127, 0, 255); 

iResult = NUM_1 + NUM_2; 
text( "NUM_1 + NUM_2:" , 100, textY) ; 
text( iResult, 214, textY ) ; 
textY += TEXT_LEADING;

iResult = NUM_1 - NUM_2; 
text( "NUM_1 - NUM_2:", 100, textY) ; 
text( iResult, 214, textY); 
textY += TEXT_LEADING;

iResult = NUM_1 * NUM_2 ; 
text( "NUM_1 * NUM_2:", 100, textY ) ; 
text( iResult, 214, textY ) ; 
textY += TEXT_LEADING;

iResult = NUM_1 / NUM_2 ; 
text( "NUM_1 / NUM_2:", 100, textY ) ; 
text( iResult, 214, textY ) ; 
textY += TEXT_LEADING;

text( "NUM_1 / NUM_2:", 100, textY ) ; 
text( round(iResult), 214, textY ) ; 
textY += TEXT_LEADING;

iResult = NUM_1 % NUM_2 ; 
text( "NUM_1 % NUM_2:", 100, textY ) ; 
text( iResult, 214, textY ) ; 
textY += TEXT_LEADING;

NUM_1 += NUM_2 ; 
text( "NUM_1 += NUM_2:", 100, textY ) ; 
text( iResult, 214, textY ) ; 


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

