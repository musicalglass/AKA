var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var radius = 170;
//Set angleMode to prevent it converting to degrees
angleMode = "radians"; 
var angle = 1.6; // Starting @ 90 "degrees"

translate(200, 200); 
textSize(16); 

var sinY, cosX;
background(0); 
var countMe = -40;
for(var i = 0; i < 63; i++){
//calculate coordinates of the orbit using sin and cosine
 sinY = (sin(angle) * radius);
 cosX = (cos(angle) * radius);

 // Update angle
 angle += 0.05; 

 // Draw Lines
 stroke(111, 0, 255); // The Color Purple
 line(0, 0, sinY, cosX);
 line(sinY,40,sinY, 0);
 line(sinY,40,countMe, 80);
 line(countMe,110,sinY, 180);
 stroke(110, 0, 255, sinY / 1.2);
 line(countMe,80,countMe, 110);
 stroke(110, 0, 255, -sinY / 1.2);
 line(countMe,80,countMe, 110);
 countMe++;
} 

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

