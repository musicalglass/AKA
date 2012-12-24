var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//<Description> Freeze and Resume the Draw Loop </Description> 

mousePressed = function() { noLoop(); };

mouseReleased = function() { loop(); };

// Declare Constant Variables
var DOT_SPEED = 5.9;
var DOT_WIDTH = 24;
// Game Variables
var dot_Position_X = 40;
var dot_Direction = "forward";

// Begin Game Loop
draw = function() {
background(0); // Clear the Screen Black
fill(255);
text("Click the screen to freeze the Game Loop",80,55);
// Make your point
stroke(255, 0, 0); // Set color
strokeWeight(DOT_WIDTH);
point(dot_Position_X, 200);

// If Dot reaches the Border... 
if (dot_Position_X > 400 - DOT_WIDTH / 2) {
    dot_Direction = "reverse"; // Change it's "flag"
} // If it's on the left
if (dot_Position_X < 0 + DOT_WIDTH / 2){ 
    dot_Direction = "forward"; // It must be Red
}

if(dot_Direction === "forward"){
// Increment the Position each time loop repeats
    dot_Position_X += DOT_SPEED; // Add DOT_SPEED to Position
}
else{ // otherwise...
 // Since there are only 2 possibilities, anything but "forward" ends up here. You could say dot_Direction = 0
    dot_Position_X -= DOT_SPEED; // Subtract DOT_SPEED
}

}; // end Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

