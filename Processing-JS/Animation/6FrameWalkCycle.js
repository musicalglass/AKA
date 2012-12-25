var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);

/*<Description> A Heirarchy of Dependencies using Matrix Transformations. </Description>*/

frameRate(6);
var frameNum = 3;
var Action = 1;

// Declare operatorVariables
var pelvisTranslateX = 200; 
var pelvisTranslateY = 200; 

var leftLegTranslateX = 0; 
var leftLegTranslateY = 0; 
var leftLegRotate = 0; 
var leftShinRotate = 0; 
var leftFootRotate = 0; 

var rightLegTranslateX = 0; 
var rightLegTranslateY = 0; 
var rightLegRotate = 0; 
var rightShinRotate = 0; 
var rightFootRotate = 0; 

// Begin Game Loop
draw = function (){
background(255); // Set color(greyscale)

if(Action){
    frameNum++; // Animate
}

if(frameNum === 7){
    frameNum = 1;
}



/* The Pelvis is the Character's Center in this Heirarchy. Translating it moves the entire "Rig". */
translate(pelvisTranslateX, pelvisTranslateY); 
//scale(1.0, 1.0);
//rotate(0);
strokeWeight(20); 

// Leg Right
pushMatrix(); // Begin Right Leg Transformations
translate(rightLegTranslateX,rightLegTranslateY);
rotate(rightLegRotate);
line(0, 0, 0, 60); // draw Leg Right

// Shin Right
translate(0,60);
rotate(rightShinRotate);
line(0, 0, 0, 54); // draw Shin Right

// Foot Right
strokeWeight(12); // Right Foot Thickness
translate(0,60);
rotate(rightFootRotate);
triangle(-58, 20, 0, -6, 14, 20); // Draw foot right

popMatrix(); // End Right Leg Transformations

// Pelvis
strokeWeight(4); // Pelvis line thickness
ellipse(0, 0, 60, 52); //Draw Pelvis

// Leg Left
pushMatrix(); 
strokeWeight(20); // Leg Thickness
translate(leftLegTranslateX,leftLegTranslateY);
rotate(leftLegRotate);
line(0, 0, 0, 60); // Draw Leg Left

// Shin Left
translate(0,60);
rotate(leftShinRotate);
line(0, 0, 0, 54); // draw Shin Left

// Foot Left
strokeWeight(12); // Foot line Thickness
translate(0,60);
rotate(leftFootRotate);
triangle(-58, 20, 0, -6, 14, 20); // Draw Foot Left
popMatrix(); // End Left Leg

resetMatrix();

fill(0, 0, 0);
textSize(32); // Change Text Size
text("frame:",24,45); text(frameNum,122,45); 
fill(255);

// Contact
// Frame 1 Transformation Settings
if(frameNum === 1){ 
pelvisTranslateX = 200; 
pelvisTranslateY = 209; 

leftLegTranslateX = 4; 
leftLegTranslateY = 12; 
leftLegRotate = -26; 
leftShinRotate = -17; 
leftFootRotate = 37; 

rightLegTranslateX = -4; 
rightLegTranslateY = 12; 
rightLegRotate = 38; 
rightShinRotate = -1; 
rightFootRotate = 6; 
} // End Frame 1

//Propel
// Frame 2 Transformation Settings
if(frameNum === 2){ 
pelvisTranslateX = 200; 
pelvisTranslateY = 200; 

leftLegTranslateX = 6; 
leftLegTranslateY = 12; 
leftLegRotate = -25; 
leftShinRotate = -49; 
leftFootRotate = -26; 

rightLegTranslateX = -4; 
rightLegTranslateY = 12; 
rightLegRotate = 17; 
rightShinRotate = -17; 
rightFootRotate = 0; 
} // End Frame 2

// Passing
// Frame 3 Transformation Settings
if(frameNum === 3){ 
pelvisTranslateX = 200; 
pelvisTranslateY = 189; 

leftLegTranslateX = 0; 
leftLegTranslateY = 14; 
leftLegRotate = 32; 
leftShinRotate = -103; 
leftFootRotate = 19; 

rightLegTranslateX = 0; 
rightLegTranslateY = 12; 
rightLegRotate = 0; 
rightShinRotate = 0; 
rightFootRotate = 0; 
} // End Frame 3

// Contact
// Frame 4 Transformation Settings
if(frameNum === 4){ 
pelvisTranslateX = 200; 
pelvisTranslateY = 209; 

leftLegTranslateX = -4; 
leftLegTranslateY = 12; 
leftLegRotate = 38; 
leftShinRotate = -1; 
leftFootRotate = 6; 

rightLegTranslateX = 4; 
rightLegTranslateY = 12; 
rightLegRotate = -26; 
rightShinRotate = -17; 
rightFootRotate = 37; 
} // End Frame 4

//Propel
// Frame 5 Transformation Settings
if(frameNum === 5){ 
pelvisTranslateX = 200; 
pelvisTranslateY = 200; 

leftLegTranslateX = -6; 
leftLegTranslateY = 12; 
leftLegRotate = 17; 
leftShinRotate = -17; 
leftFootRotate = 0; 

rightLegTranslateX = 4; 
rightLegTranslateY = 12; 
rightLegRotate = -25; 
rightShinRotate = -49; 
rightFootRotate = -26; 
} // End Frame 4

// Passing
// Frame 6 Transformation Settings
if(frameNum === 6){ 
pelvisTranslateX = 200; 
pelvisTranslateY = 189; 

rightLegTranslateX = 0; 
rightLegTranslateY = 14; 
rightLegRotate = 32; 
rightShinRotate = -103; 
rightFootRotate = 19; 

leftLegTranslateX = 0; 
leftLegTranslateY = 12; 
leftLegRotate = 0; 
leftShinRotate = 0; 
leftFootRotate = 0; 
} // End Frame 6

// Background
stroke(0); 
strokeWeight(6); 
line(0, 350, 400, 350);

}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

