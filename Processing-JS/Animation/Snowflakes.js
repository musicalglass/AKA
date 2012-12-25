var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);

//<Description> Create a Snowstorm of random Points.</Description>

//Create an empty Array to store Flakes 
var flakes = []; 

//Constant Variables
var FLAKE_SPEED = 1.1; 
var NUMBER_FLAKES = 8;

//Declare Variables to store Random Numbers
var randomX;
var randomY;
var createSnow = function(){ // Each time Function is called...
 randomX =  random(0, 400); // Update Random Variables
 randomY =  random(0, 400); 

 flakes.push({ // ...add an entry to the Array
     x: randomX,
     y: randomY });
};

var updateSnow = function(b){
 // Cycle through Array and move each flake
     for (var i = 0; i < b.length; i++){ 
     b[i].y = b[i].y + FLAKE_SPEED;
     b[i].x = b[i].x + (random(-0.8, 0.8));

     if(b[i].y > 400){
         b[i].y = 0;
         b[i].x =  random(0, 400);
     }
 }
};

var drawSnow = function(b){
 // Cycle through Array and draw each Flake based on X, Y
     for (var i = 0; i < b.length; i++){ 
     strokeWeight (3); // Flake size
     stroke (255, 255, 255); // Set color
     point(b[i].x, b[i].y); // Draw point at Array[] X, Y
     }
};

//Use a For Loop to call createSnow Function repeatedly
for (var i = 1; i < NUMBER_FLAKES; i++){ 
createSnow();
}

//Begin Game Loop
draw = function(){
 background(0, 0, 0);

 updateSnow(flakes);
 drawSnow(flakes);

}; // End Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

