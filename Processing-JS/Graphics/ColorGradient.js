var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


// A Gradient Effect using Lines (or Points)

var rectX = 100; 
var rectY = 120; 
var rectWidth = 200; 
var rectHeight = 128; 
var rectStroke = 4; 
var gradientOffset = 255; 
var gradientCenter = 1.8;

background(255); 
stroke(0); 

// Gradient Fill Base Color
fill(255, 255, 0); 
strokeWeight(rectStroke); // Rect Line Thickness
rect(rectX, rectY, rectWidth, rectHeight); // Draw rect

strokeWeight(1); 
// Draw color bands using For Loops
for (var x = rectX + rectStroke/2 ; x < rectX + rectWidth - rectStroke/2; x += 1){

// Set Gradient Overlay Color
stroke(255, 0, 0, gradientOffset); 
gradientOffset -= gradientCenter; 

// Draw Columns of Points w/ Nested For Loop (for later use)
//for(var y = rectY + rectStroke/2; y < rectY + rectHeight - rectStroke/2 ; y += 1){ point(x, y) ; } 

// Draw colored Vertical Lines across inside of rect
line(x, rectY + rectStroke/2, x, rectY + rectHeight - rectStroke/2);
}


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and 
made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

