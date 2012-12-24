var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/* Inspired by Vi Hart. Domo Arigato Sal Khan. */

var centerX = 0; 
var centerY = 0; 
var craneSize = 0.5;
var numBirds = 0;

var spacey = getImage("space/background"); 

// Set angleMode to prevent it converting to degrees
angleMode = "radians"; 

var sinY;
var radius = 120;
var randomX;

var customFont = createFont("cursive", 18); 

translate(centerX, centerY);

// Create an empty Array to store Crane's Coordinates
var cranes = [];

// When function is called, "push" a new Array entry
var createCrane = function(){
// Assign Random number from to Movement Variable
randomX = random(0, 6.4) ; 
// Create new Array entry at current Mouse Coordinates
    cranes.push({
    x:mouseX,
    y:mouseY,
    angle:randomX,
    elevation: 0, 
    color: color(random(0,255), random(0,255), random(0,255))
    });
    numBirds++; // Add 1 to the counter
};

// Click the screen to add more Cranes
mousePressed = function(){
    createCrane();
};

var drawFlock = function(c){
var counter = 0;
// Cycle through the Array and draw a Crane for each entry
    for (counter; counter < c.length; counter++){
        pushMatrix(); // Prepare for Matrix Translations
        if(c[counter].x <-50){
            c.splice(counter, 1); // Remove it from Array
        }else{
            fill(c[counter].color); // Set Crane Color
        c[counter].x-=1.8;
        translate(c[counter].x, c[counter].y-c[counter].elevation/10);
        scale(craneSize, craneSize);
        strokeWeight(2);
        c[counter].angle = c[counter].angle + 0.6; 
        if(c[counter].angle > 6.4){c[counter].angle -= 6.4;}
        c[counter].elevation = (sin(c[counter].angle) * radius);

// Tail
triangle(50,0,0,0,106,-100); 
// Head
triangle(-91,-68,-134,-52,-107,-80); 
// Neck
quad(-107, -80, -80, -76, 0, 0, -50, 0);
// Body
triangle(0,-60,-50,0,50,0); 
// Wing Right
triangle(-8,c[counter].elevation*0.8,-50,0,50,0); 
// Feet
triangle(-25,30,-50,0,0,0); 
// Belly
triangle(25,30,0,0,50,0); 
// Wing Right
triangle(8,c[counter].elevation*0.8,-50,0,50,0); 
        }
popMatrix();
    }
};

// Begin Game Loop 
draw = function(){
pushMatrix(); 
scale(0.7,0.7);
image(spacey, 0, 0); 
popMatrix(); 

fill(0); 
textFont(customFont, 24); // Set Custom Font
if(!numBirds){
    text("It is said that if you make\n1000 Origami Cranes\nyou will have good luck.\n\n\nClick on the sky to make\nOrigami Cranes :)",56,100);
}else{
    text(numBirds,330,30);
}

drawFlock(cranes);

}; // End Game Loop 


/* Animations by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

