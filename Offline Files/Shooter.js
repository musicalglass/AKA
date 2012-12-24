var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var BULLET_SPEED = 12.0;
var bullets=[]; // Create an Array to store Projectiles
var skeets=[]; // Stuff to shoot at
var SKEETS_NUM = 4; 
var maxNumSkeets = 2; // How many onscreen at one time
var paddlePos;
var myFont1 = createFont("fantasy", 18);
var score = 0;

// Each time mouse is clicked...
mouseClicked = function(){ 
    bullets.push({  // ...create new Array entry
        x:mouseX,
        y:356
    });
};

var updateBullets = function(b){
    for (var i = 0; i < b.length; i += 1){
        // When the bullet reaches set distance..
        if(b[i].y < 40){ 
            b.splice(i, 1); // ...remove it from Array
        }
        else{
            b[i].y -= BULLET_SPEED; // Update Bullet Position
        }
    }
};

// Declare a couple Variables
var randomX; var randomY;
var createSkeet = function(){
    // Assign random Number from 20 - 380 to Variables
    randomX =  random(20, 380); 
    randomY = random(20, 200);
    // Create a new Array entry
    skeets.push({
        x:randomX,
        y:randomY,
        width: 20,
        height: 20
    });
};

// Check for Collision and Delete Skeet
var updateSkeets = function(b){
    if (bullets.length){
        // Cycle through each Skeet in Array
        for (var i = 0; i < b.length; i++){
            // Compare it with each Bullet
            for (var j = 0; j < bullets.length; j++){
            if (bullets[j].x > (b[i].x - (b[i].width / 2)) && 
            bullets[j].x < (b[i].x  + b[i].width ) && 
            bullets[j].y > b[i].y  - (b[i].height / 2) && 
            bullets[j].y < (b[i].y  + b[i].height) ){
                    score++;
                    SKEETS_NUM--;
                    if (b[i]){ // Still there?
                        b.splice(i, 1);
                    }
                }
            }
        }
    }
};

var drawSkeets = function(b){
    // Cycle through Array and draw each skeet
    for (var i = 0; i < b.length; i++){ 
    strokeWeight (3);
    stroke (153, 0, 255);
    fill (255, 166, 0);  
        rect(b[i].x, b[i].y, b[i].width, b[i].height);
    }
};

var drawBullets = function(b){
strokeWeight (1);
stroke (255, 0, 0);
fill (255, 255, 0);  

// Cycle through Array and draw each bullet at x, y
    for (var i = 0; i < b.length; i += 1){ 
        ellipse(b[i].x, b[i].y, 7, 7);
    }
    
};

// Begin Game Loop
draw = function(){
noStroke (); // Prevent player from suffering a coronary
// Draw Background at 85% Opacity for a bit of motion blur
fill (8, 36, 5, 85);
rect (0, 0, 400, 400); 

if (SKEETS_NUM > 0){
    updateBullets(bullets);
    updateSkeets(skeets);
}

drawBullets(bullets);

if (SKEETS_NUM > 0){
    paddlePos = mouseX - 40; // Center Paddle to Mouse
    if (SKEETS_NUM > 1){ 
        if (skeets.length < maxNumSkeets){
        createSkeet();
        }
    }
}
else{
    fill (255, 0, 0); 
    textFont(myFont1, 52);
    text("Game Over", 96, 200);
}

drawSkeets(skeets); // Happy little targets :)

// Draw Paddle
noStroke (); 
fill(124, 0, 255);
rect(paddlePos, 356, 80, 16);

fill(255, 255, 255);
textFont(myFont1, 20);
text("Score:", 18, 40);text(score, 81, 40); 

};// End Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

