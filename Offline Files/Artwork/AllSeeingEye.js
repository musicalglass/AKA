var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/* Based on Hynoswirl
http://www.khanacademy.org/cs/hypnoswirl/826002294 */

background(0, 0, 0);

//how far around the center the circle is, in radians
var angle = 0;
//how far from center the circle is
var radius = 15;
//the center of the canvas
var centerX = 200;
var centerY = 200;

//Create Variables to represent Circle colors
var myColor = 0;
var myColor2 = 0;
var myColor3 = 0;

var draw = function() {
//calculate coordinates of the ball using sin and cosine
 var x = sin(angle) * radius ;
 var y = cos(angle) * radius;

 // Draw Circle outline only
 noFill();
 // Assign variables to Circle color
 stroke(myColor, myColor2, myColor3);

 // Draw Oval
 ellipse(x + centerX, y + centerY, 20, 40);

 // Increment Colors
 myColor = myColor + 1;
 myColor2 = myColor2 + 3;
 myColor3 = myColor3 + 5;

 // If colors max out, reset to beginning
 if (myColor > 255){
     myColor = 0;
 }
 if (myColor2 > 255){
     myColor2 = 0;
 }
 if (myColor3 > 255){
     myColor3 = 0;
 }
 
 // move the circle forward
 angle = angle + 0.6;
 // increase it's distance from center
 radius = radius + 0.2;
};


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

