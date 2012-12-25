		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


//<Description> Apply Matrix Transformations on a group of primitive graphics objects. </Description>

// This Variable changes 0,0 to the Game Window's Center
// Change this to 0 to see the Window's normal settings
var OFFSET = 200;
// Set up some Variables to effect Transformations
// Try tweaking these numbers :)
var translateX = 0; 
var translateY = 0; 
var scaleX = 2.0; 
var scaleY = 2.0; 
var rotateDegrees = 0; 

// Move 0, 0 from top left corner to Center of screen to make it easier for you to create Sprites
translate(OFFSET, OFFSET); 

// Set Transformation effects using Variables
translate(translateX,translateY); 
scale(scaleX, scaleY); 
rotate(rotateDegrees); 

// Draw "Sprite"
fill(255, 0, 0); // Red
ellipse(0, -30, 15, 20); // Head
ellipse(0, -9, 10, 22); // Thorax (chest)
ellipse(0, 7, 6, 11); // Petiole
ellipse(0, 16, 6, 11); // Node
ellipse(0, 33, 20, 24); // Gaster (tail)
fill(0); // Black
ellipse(4, -33, 4, 5); // Eye Right
ellipse(-4, -33, 4, 5); // Eye Left
stroke(255); // White
point(4,-35); // Eye hilights
point(-4,-35);
stroke(0); // Black
strokeWeight(3); // Thicker lines
line(-5, -13, -13, -21); //Leg Front Left
line(-5, -8, -16, -9); //Leg Mid Left
line(-5, -3, -14, 4); //Leg Rear Left
line(5, -13, 13, -21); // Leg Front Right
line(5, -8, 16, -9); //Leg Mid Right
line(5, -3, 14, 4); //Leg Rear Right
strokeWeight(2); // Thinner Lines
line(-20, -33, -13, -21); // Leg Front Left b
line(-29, -2, -16, -9); //Leg Mid Left b
line(-27, 26, -14, 4); //Leg Rear Left b
line(20, -33, 13, -21); // Leg Front Right b
line(29, -2, 16, -9); //Leg Mid Right b
line(27, 26, 14, 4); //Leg Rear Right b
line(4, -37, 11, -47); // Antenae Right
line(-4, -37, -11, -47); // Antenae Left
strokeWeight(1); // Normal Lines
line(-20, -33, -22, -47); // Leg Front Left c
line(-29, -2, -39, 10); //Leg Mid Left c
line(-27, 26, -30, 46); //Leg Rear Left c
line(20, -33, 22, -47); // Leg Front Right c
line(29, -2, 39, 10); //Leg Mid Right c
line(27, 26, 30, 46); //Leg Rear Right c
line(4, -37, 11, -47); // Antenae Right
line(-4, -37, -11, -47); // Antenae Left
line(9, -59, 11, -47); // Antenae Right b
line(-9, -59, -11, -47); // Antenae Left b



		}};