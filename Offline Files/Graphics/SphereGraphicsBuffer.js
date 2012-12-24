var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Draw complex graphics into Graphics Buffer to make it reusable without eating up extra processing. </Description>*/

background(0); // In the beginning, it was dark
// Set angleMode to prevent it converting to degrees
angleMode = "radians"; 
var angle = 0.0;
// how big the Sphere is
var radius = 98;
// the Sphere's center
var centerX = 50;
var centerY = 50;
// The secret ingredient
var sinParabola;
var cosParabola;

// Create a Graphics Object called bufferedImage
var bufferedImage = this.createGraphics(100,100);
bufferedImage.beginDraw(); // Begin Graphic Image
bufferedImage.background(0, 0, 0, 0);
var i = 0.0; // Using a Float in the For Loop
for( i = 0; i <= 1.6; i = i + 0.005){
    // Increment angle using For Loop
    angle = i ; 
    sinParabola = sin(angle) * radius ;
    cosParabola = cos(angle) * radius;

    // Draw the Sphere
    bufferedImage.noFill(); // Only drawing Ellipse outlines
    bufferedImage.strokeWeight(1); // Set line thickness
    // The color values are also Parabolic! ;)
    bufferedImage.stroke(sinParabola , sinParabola * 2, 244); 
// Draw Concentric Ellipses
bufferedImage.ellipse( centerX, centerY, cosParabola, cosParabola);
}
bufferedImage.endDraw(); // End Graphic Image

// Print Graphics Buffer as an Image
image(bufferedImage, 50, 50);

// Tweak the Position and Size and draw another
translate(150, 150);
scale(1.4,0.4);
image(bufferedImage, 38, 150);

/* Based on Off-Screen Graphics Buffer by Chris Hohmann
Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */




}};

