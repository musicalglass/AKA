		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


// <Description> Check to see if the Mouse Position is within the boundaries of a Rectangle. </Description>

var Rect_X = 150;
var Rect_Y = 160;
var Rect_Width = 100;
var Rect_Height = 60;

// Begin Game Loop
draw = function() {
background(0); // Clear the Screen
fill(255); // Set the Text color to White
text("Greater than Left =", 15, 30);
// Is it inside the Left?
if (mouseX > Rect_X) {
fill(0, 255, 0);
text("True", 125, 30);
} 
else {
fill(255, 0, 0);
text("False", 125, 30);
}

fill(255); // Set the Text color to White
text("Less than Right =", 15, 50);
// Is it inside the Right?
if (mouseX < Rect_X + Rect_Width) {
fill(0, 255, 0);
text("True", 125, 50);
} 
else {
fill(255, 0, 0);
text("False", 125, 50);
}

fill(255); // Set the Text color to White
text("Greater than Top =", 15, 70);
// Is the number higher than the Y value?
if (mouseY > Rect_Y) {
fill(0, 255, 0);
text("True", 125, 70);
} 
else {
fill(255, 0, 0);
text("False", 125, 70);
}

fill(255); 
text("Less than Bottom =", 15, 90);
// Is the number lower than the Y + Rect_Height?
if (mouseY < Rect_Y + Rect_Height) {
fill(0, 255, 0);
text("True", 125, 90);
} 
else {
fill(255, 0, 0);
text("False", 125, 90);
}

fill(255); 
text("Are all 4 True?", 160, 280);
text("Colision Detected =", 127, 300);
// If the Mouse is within all 4 boundaries
// Collision Detected!
if( (mouseX > Rect_X) && 
(mouseX < Rect_X + Rect_Width) &&
(mouseY > Rect_Y) &&
(mouseY < Rect_Y + Rect_Height))
{
fill(0, 255, 0);
text("True", 240, 300);
} 
else {
fill(255, 0, 0);
text("False", 240, 300);
}
noStroke();
// Draw a Rectangle
rect(Rect_X, Rect_Y, Rect_Width, Rect_Height);

stroke(255); // Color White
// Create a Cursor icon
// Draw a Point at Mouse Position(X, Y)
point(mouseX, mouseY); 
// Draw 4 Lines around Mouse Position
line(mouseX, mouseY - 14, mouseX, mouseY - 7); 
line(mouseX, mouseY + 7, mouseX, mouseY + 14); 
line(mouseX - 14, mouseY, mouseX - 7, mouseY ); 
line(mouseX + 7, mouseY, mouseX + 14, mouseY );

}; // end Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


		}};