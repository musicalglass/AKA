		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


var DOT_SPEED = 2.8;
var DOT_RADIUS = 24;
var dot_Position_X = 40;
var dot_Direction = "forward";

// Begin Game Loop
var draw = function() {
background(0, 0, 0); // Clear the Screen Black

// Make your point
stroke(255, 0, 0);  
strokeWeight(DOT_RADIUS);
point(dot_Position_X, 200);

// If Dot reaches the Border... 
if (dot_Position_X > 400 - DOT_RADIUS / 2) {
    dot_Direction = "reverse"; // Change it's "flag"
} // If it's on the left
if (dot_Position_X < 0 + DOT_RADIUS / 2){ 
    dot_Direction = "forward"; // It must be Red
}

if(dot_Direction === "forward"){
// Increment the Position each time loop repeats
    dot_Position_X += DOT_SPEED;
}
else{
 // Since there are only 2 possibilities, anything but "forward" ends up here. You could say dot_Direction = 0
    dot_Position_X -= DOT_SPEED;
}

}; // end Game Loop



		}};