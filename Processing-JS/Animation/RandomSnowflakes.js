var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Create Snowflakes using For Loop and Animate using Matrix Translations. </Description>*/

//Create an empty Array to store Flakes 
var flakes = []; 

//Declare CONSTANT_VARIABLES
var FLAKE_SPEED = 1.1; 
var NUMBER_FLAKES = 36; 

//Each time Function is called...
var createSnow = function(){ 
 flakes.push({ // ...add an entry to the Array
     x: random(0, 480),
     y: random(-40, 400),
     trunk: random(110, 130),
     lower: random(4, 30),
     lowerX: random(10, 26),
     lowerY: random(15, 40),
     mid: random(34, 60),
     midX: random(15, 30),
     midY: random(60, 90),
     topb: random(64, 90),
     topX: random(10, 20),
     topY: random(90, 110)
     });
};

var updateSnow = function(b){ 
 // Cycle through Array and move each flake 
     for (var i = 0; i < b.length; i++){ 
     b[i].y = b[i].y + FLAKE_SPEED; 
     b[i].x = b[i].x + (random(-0.8, 0)); 

     // If it goes offscreen, reset 
     if(b[i].y > 440 || b[i].x < -40){ 
         b[i].y = -40; 
         b[i].x =  random(-40, 480); 
     } 
 } 
}; 

var drawSnow = function(b){
//Cycle through Array and draw each Flake based on X, Y
for (var i = 0; i < b.length; i++){ 
stroke(158, 156, 255); // Set Flake Color 

 pushMatrix(); // Enter the Matrix 
 // Translate World Center from 0,0 to Flake Center 
 translate(b[i].x, b[i].y); // Move Flakes 
 scale(0.15,0.15); // Set Flake size 
 rotate(random(-1.8, 1.8)); // Jiggle rotation 
 // Draw Snowflake 
 for(var triangles = 0; triangles < 6; triangles++){ 
     strokeWeight(10); 
     line(0,5,0,b[i].trunk); // Spoke 
     strokeWeight(8); 
     // lower branches 
     line(0,b[i].lower,b[i].lowerX,b[i].lowerY); 
     line(0,b[i].lower,-b[i].lowerX,b[i].lowerY); 
     // mid branches 
     line(0,b[i].mid,b[i].midX,b[i].midY); 
     line(0,b[i].mid,-b[i].midX,b[i].midY); 
     strokeWeight(6); 
     line(0,b[i].topb,b[i].topX,b[i].topY); // top branches 
     line(0,b[i].topb,-b[i].topX,b[i].topY); 
     rotate(60); // Revolve around 0,0 
 } 
popMatrix(); // Exit the Matrix 
 } 
}; 

//Use a For Loop to call createSnow Function repeatedly
for (var i = 1; i < NUMBER_FLAKES; i++){ 
createSnow();
}

//Begin Game Loop
draw = function(){
 background(0);

 updateSnow(flakes);
 drawSnow(flakes);
}; // End Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

