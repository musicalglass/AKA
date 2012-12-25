		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


/*<Description> Use the built in Keyboard Functions to update Variables. </Description>*/

// Declare a CONSTANT_VARIABLE. This never changes.
var DOT_SPEED = 4.2;
// Declare an operatorVariable. This will be updated.
var dotPositionX = 200;
var dotPositionY = 200;

// Begin Game Loop. Everything in here will loop at 30 FPS
draw = function(){

// Erase everything and paint the background black
background(0); 

if(keyIsPressed){ // If any key is pressed...
    // Check for specific keys
    if(keyCode === DOWN){ 
        // Add DOT_SPEED to Y Position Variable
        dotPositionY = dotPositionY + DOT_SPEED; 
    }
    if(keyCode === UP){
        // Subtract DOT_SPEED from Y Position Variable
        dotPositionY = dotPositionY - DOT_SPEED;
    }
    if(keyCode === RIGHT){
        // Another way to add 2 numbers
        dotPositionX += DOT_SPEED; 
    }
    if(keyCode === LEFT){
        // Another way to increment by 1
        dotPositionX -= DOT_SPEED; 
    }   
		keyCode = 0;
}

// Draw Point
stroke(255, 0, 0);  // Set Color
strokeWeight(12); // Set Point Radius 
// Draw point using updated Variables
point(dotPositionX, dotPositionY); 

}; // end Game Loop

// Tutorials in plain English by Dillinger 2012




		}};