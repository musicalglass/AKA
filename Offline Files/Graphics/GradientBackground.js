var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> A Gradient Effect using Opaque Lines. </Description> 
Decreasing Line Thickness will increase the "resolution" by adding more lines, but maybe slow things down a bit if you decide to use it as a background in the Draw Loop. */

background(255, 255, 0); // Bottom Gradient Color
var lineThickness = 8;
var greyValue = 0; // Gradient Opacity Value
strokeWeight(lineThickness);

// Starting from the Bottom and going Up
for(var i = 400; i >= 0; i = i - lineThickness){
 stroke(255, 0, 0, greyValue); // Top Gradient Color 
 // Use Variable from For Loop to change each line's Position
 line(0, i, 400, i); 
 greyValue = greyValue + 6; 
 

 var customFont = createFont("fantasy", 18); //
// Add a 4th parameter to color to define Opacity 0 - 255
 fill(0, 0, 0, 3);
textFont(customFont, 36); // Set Custom Font
 textSize(72);
 text("    Khan \nAcademy\n  Rocks!!",60, 134); 
 fill(255, 186, 59); 
  text("    Khan \nAcademy\n  Rocks!!", 54, 130); 
}


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and 
made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

