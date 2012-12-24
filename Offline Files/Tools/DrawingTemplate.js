var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//<Description> Drawing Template. </Description>

var centerX = 0; 
var centerY = 0; 
var centerOffset = 0;
var rectOffset = 150;
rotate(0);
centerX = centerY += centerOffset;

translate(centerX, centerY);

// Begin Game Loop 
draw = function(){
background(255); 

stroke(0); // Black
fill(255, 0, 0);
rect(rectOffset,rectOffset,100,100);

// Draw Black Crosshair Lines at 0,0
line(0, -400, 0, 400); // Y Axis Line
line(-400, 0, 400, 0); // X Axis Line

// Draw Blue Grid
strokeWeight(1); // Line Thickness
stroke(0, 100, 255, 75); // Opaque Blue
for(var i = -400; i < 400 ; i = i + 10){
    line(i, -400, i, 400);
    line(-400, i, 400, i);
}

}; // End Game Loop



/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */




}};

