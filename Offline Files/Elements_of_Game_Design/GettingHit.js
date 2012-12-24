var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//<Description> Use an Array to create multiple Game objects with collision detection. </Description>

var thingies = []; // Things to Catch or Avoid, depending

// Declare CONSTANT_VARIABLES
var THINGIE_SPEED = 8.1; 
var THINGIE_SIZE = 20; 
var PADDLE_WIDTH = 80; 
var PADDLE_HEIGHT = 16; 
var PADDLE_Y = 380; 
var MAX_NUM_THINGIES = 2; 

// Declare operatorVariables 
var numThingies = 10; 
var paddleX; 
var hitCounter = 0; 

// Variables for storing Random numbers
var randomX; 
var randomY; 

// Define custom Font
var myFont1 = createFont("fantasy", 18); 

var createThingie = function(){
    // Update Variables with new Random numbers
    randomX =  random(10, 390); // Random locations offscreen
    randomY =  random(-100, -10);

    thingies.push({ // Add group entry to the Array
        x:randomX,
        y:randomY,
        width: THINGIE_SIZE,
        height: THINGIE_SIZE,
        collision: false}); 
}; 

/* (b) is the Array thingies[] that we pass to the Function in the Game Loop. Example: updateThingies(nameOfArray) */
var updateThingies = function(b){
    // Cycle through Array and change Thingie X, Y Positions
    for (var i = b.length - 1; i >= 0; i -= 1){
    // Update Thingie Position
    b[i].y = b[i].y + THINGIE_SPEED;

        if(b[i].y > 420){ // If it goes offscreen...
            b.splice(i, 1); // You're Terminated!
            numThingies--; 
        }

// Check for Collision with Paddle
if( ((b[i].x + b[i].width > paddleX && b[i].x + b[i].width < paddleX + PADDLE_WIDTH) || (b[i].x > paddleX && b[i].x < paddleX + PADDLE_WIDTH))&& ((b[i].y > PADDLE_Y && b[i].y < PADDLE_Y + PADDLE_HEIGHT) || (b[i].y + b[i].height > PADDLE_Y && b[i].y + b[i].height < PADDLE_Y + PADDLE_HEIGHT)) ){

            // If Collision was detected, call Bladerunner
            b[i].collision = true; // Mark it for Termination
            hitCounter++; // Call it in to the home office
        } 
    } 
};

var drawThingies = function(b){
    if( b.length > 0 ){ // Is there anybody...in there?
    // Cycle through Array and draw each Thingie
        for (var i = 0; i < b.length; i++){ 
            // Set size, colors
            strokeWeight (3); 
            stroke (153, 0, 255);
            fill (255, 166, 0); 

            // Draw Thingies
            rect(b[i].x, b[i].y, b[i].width, b[i].height);
        }
    }
};

var drawPlayer = function(){
noStroke(); // No lines around paddle
// Draw Player
if (numThingies > 0){ 
    // Update Player
    paddleX = mouseX - PADDLE_WIDTH / 2;
}

fill(124, 0, 255);
rect(paddleX, 356, PADDLE_WIDTH, PADDLE_HEIGHT);
};

// Bladerunner
var agentSmith = function(){
        // Cycle through the list of suspects
        for (var i = 0; i < thingies.length; i++){ 
            // If your time is up...
            if (thingies[i].collision === true){
                // Subtract from total numThingies
                thingies.splice(i, 1); // You're Terminated!
                numThingies--; 
        }
    }
}; 

// This is outside of the Game Loop and will run 1 time
// Populate game with MAX_NUM_THINGIES before we start
for(var i = 0; i < MAX_NUM_THINGIES; i++){
    createThingie(); // Do your Thingie(s)
}

// Begin Game Loop
draw = function(){
background(0); // Set color(greyscale)
fill(255); // Font color(greyscale)

textFont(myFont1, 20); // Set (Custom Font, Size)
text("Collisions:", 18, 40); text(hitCounter, 110, 40); 

if (thingies.length < MAX_NUM_THINGIES ){ 
    if  (numThingies >= MAX_NUM_THINGIES){
    createThingie(); 
    }
}

// Pass the Array (thingies) to the Update Function
updateThingies(thingies);

drawThingies(thingies); // Draw Thingies if there are any

drawPlayer();

agentSmith(); // Garbage Collector

if(numThingies === 0){
  fill(255, 0, 0);
        textFont(myFont1, 36);
        text("Game Over", 124, 166); // ...order a pizza :)
}

}; // That's all folks! 

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

