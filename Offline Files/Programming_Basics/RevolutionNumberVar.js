var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Generate Iterations divided by 360 Degrees. </Description>*/

background(0); 
var iterations = 11;
var angle = 0.0; 

// Set angleMode to degrees
angleMode = "degrees"; 
translate(200, 200); 

var sinY, cosX;

// how long each spoke is
var radius = 160;

for(var i = 0; i < iterations; i += 1){
// calculate coordinates of the orbit using sin and cosine
    sinY = (sin(angle) * radius);
    cosX = (cos(angle) * radius);

    // Draw Lines
    strokeWeight(2); 
    stroke(186, 0, 252); // The Color Purple
    line(0, 0, sinY, cosX);
    
    // Update angle for next loop
    angle += 360 / iterations; 
}


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */





}};

