		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


//<Description> Use Matrix Transformations to manipulate an Image. </Description> 

// Set up some Variables to effect Transformations
// Try tweaking these numbers :)
var translateX = 200; 
var translateY = 200; 
var scaleX = 1.0; // Try a negative number
var scaleY = 1.0; 
var rotateDegrees = 0; 

// Load image into Variable mr_Pink
var mr_Pink = getImage(butterfly.png); 

// Use Variables for Transformation Effects
translate(translateX,translateY); 
scale(scaleX, scaleY); 
rotate(rotateDegrees); 

// Draw Image centered at screen 0,0 (Image is 128 X 128)
// We use translate(variables) to move it back
image(mr_Pink, -64, -64); 

// Needed inside your Game Loop. Reset so you can apply Matrix Transformations over and over. Not needed here for one time use.
//resetMatrix(); 

// Tutorials in plain English by Dillinger 2012



		}};