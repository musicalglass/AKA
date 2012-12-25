var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//<Description> A Variable that can do one of 2 things depending on whether a Condition is True. </Description>

background(49, 0, 128); 

// A variable to define our Condition
var conditionalColor = 0; 
strokeWeight(10); 

for(var i = 40; i <= 360; i += 10){
// If (i is Divisible by 20) Condition = 0 : otherwise 255
  conditionalColor = ( i % 20) ? 0 : 255; 
  // Set the stroke color depending on Condition
  stroke(conditionalColor); 
  line(i, i, i, 30); // Draw lines
}


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

