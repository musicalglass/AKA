var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Spawning objects using an Array. </Description>*/

var bullets=[]; // Create an Array to store Projectiles
var BULLET_SPEED = 12.0;

mouseClicked = function(){ // Each time mouse is clicked...
    bullets.push({  // create new Array entry
        x:mouseX,
        y:356
    });
};

var updateBullets = function(b){
    for (var i = 0; i < b.length; i += 1){
    // If the bullet reaches set distance..
        if(b[i].y < 40){ 
            b.splice(i, 1); // Remove it from Array
        }
        else{
            b[i].y -= BULLET_SPEED; // Update Bullet Position
        }
    }
};

var drawBullets = function(b){
strokeWeight (3); // Set Size, color, etc
stroke (255, 255, 0);
fill (255, 0, 0); 

// Cycle through Array and draw each bullet at x,y coordinates
    for (var i = 0; i < b.length; i++){ 
        ellipse(b[i].x, b[i].y, 7, 7);
    }
};

// Begin Game Loop
draw = function () {
    noStroke (); // Prevent player from suffering a coronary
    // Draw Background at 85% Opacity for a bit of motion blur
    fill (8, 36, 5, 85);
    rect (0, 0, 400, 400); 

    // Draw Paddle at MouseX centered offset 
    fill(124, 0, 255);
    rect(mouseX - 40, 356, 80, 16);
   
   // Pass the Array (bullets) to the Functions
    updateBullets(bullets);
    drawBullets(bullets);
    
};// End Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

