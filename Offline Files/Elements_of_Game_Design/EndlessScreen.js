		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


/* <Description> If object goes offscreen, set it back to the other side. </Description>*/

var DOT_SPEED = 2.8;
var dot_Position_X = 40;

// Begin Game Loop
draw = function() {
background(0, 0, 0); // Clear the Screen Black

// Draw Point
stroke(255, 0, 0);  // Set the color
strokeWeight(12); // Set the Point's Width
point(dot_Position_X, 200);

 // Increment the Position each time Game Loop repeats
dot_Position_X += DOT_SPEED; // Add DOT_SPEED to Position

// If Dot goes offsceen on the Right... 
// If the X Position is greater than the Screen Width (400) + Point's Radius
if (dot_Position_X > 406 ) { 
    dot_Position_X = -6 ; // reset it's Position to the Left
}

}; // end Game Loop

// Tutorials in plain English by Dillinger



		}};