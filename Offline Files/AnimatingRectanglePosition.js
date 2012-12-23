		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


//<Description> Move a Rectangle by changing it's Y value each time through the Game Loop. </Description>

// Declare CONSTANT_VARIABLE (this never changes)
var RECT_POSITION_X = 140;
// Declare operatorVariable (this will be updated)
var rectPositionY = 320;

/* Begin Game Loop. Everything in here will be drawn over and over at 30 Frames Per Second. */
draw = function(){
// Erase everything and repaint the screen Black
background(0, 0, 0);

// Update the Position each time through the Loop
rectPositionY = rectPositionY + -1.5;

// Set Drawing color
fill(127, 0, 255);

// Draw Rectangle using Variables for X and Y Position
rect(RECT_POSITION_X, rectPositionY, 100, 100);

// If it tries to go offscreen...
if (rectPositionY < -100){
rectPositionY = 400; // set it back to the beginning ;)
}

}; // End Game Loop

// Tutorials in plain English by Dillinger 2012



		}};