var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Using Parabolic Gradients and Scaling to simulate a 3D Ball drawn from Concentric Circles. </Description>*/

//The "rotational" angle used in a different context here
var angle = 0.0;

//how big the Sphere is
var radius = 64;

//the Sphere's center
var centerX = 200;
var centerY = 200;

//The secret ingredient
var sinParabola;
var cosParabola;

//Black backgrounds save power on handheld devices ;)
background(0);

/* Hypnoswirl did this over time. Here I use a For Loop to call a one time operation :) */
var i = 0.0; // Using a Float in the For Loop
for( i = 0; i <= 1.6; i = i + 0.005){
 // Increment angle using For Loop
 angle = i ; 
 sinParabola = sin(angle) * radius ;
 cosParabola = cos(angle) * radius;

 // Draw the Sphere
 noFill(); // Only drawing Ellipse outlines
 strokeWeight(2); // Set line thickness
 // The color values are also Parabolic! ;)
 stroke(sinParabola * 2, sinParabola * 2, 244); 
//Draw Concentric Ellipses
ellipse( centerX, centerY, cosParabola * 4, cosParabola * 4);
}


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

