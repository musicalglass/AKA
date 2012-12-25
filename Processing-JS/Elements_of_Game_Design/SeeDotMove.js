		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


/*<Description> Use a Variable to change Point's Position in the X Axis, by udating it in the Game Loop. </Description>*/

// Declare a CONSTANT_VARIABLE. This never changes.
var DOT_SPEED = 1.8;
// Declare an operatorVariable. This will be updated.
var dotPositionX = 1;

// Begin Game Loop. Everything in here will loop at 30 FPS
draw = function(){
// Erase everything and paint the background black
background(0, 0, 0); 

// Draw Point
stroke(255, 0, 0);  // Set Color
strokeWeight(12); // Set Point Radius
point(dotPositionX, 200); // Make your point :)

 // Increment the Position each time loop repeats
dotPositionX = dotPositionX + DOT_SPEED;

}; // end Game Loop

// Tutorials in plain English by Dillinger 2012



		}};