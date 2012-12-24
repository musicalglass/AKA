var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Fire events using built in frameCount Function. </Description>*/

//so you can think in seconds instead of FPS
var framesPerSecond = 30; 

//The Draw loop repeats approximately 30 Frames Per Second
//Begin Game Loop
draw = function(){
background(0, 0, 0); // Erase all and clear the Screen Black

textSize(12); // Change Text Size
text("Frame Count:",10,30); text(frameCount,99,30);

textSize(36);
if ((frameCount > framesPerSecond * 3) && 
 (frameCount < framesPerSecond * 7)){
 text("In the beginning..",82,150);
}
if ((frameCount > framesPerSecond * 9) && 
 (frameCount < framesPerSecond * 15)){
 text("there was nothing...",61,150);
}
if ((frameCount > framesPerSecond * 17) && 
 (frameCount < framesPerSecond * 21)) {
 text("which exploded!",79,150);
}
if (frameCount > framesPerSecond * 23) {
 textSize(24);
 text("Tutorials in plain English",79,150);
 text("by Dillinger",144,185);
}
//Use an exact number to jump to specific point at 1/30 Second.
if (frameCount > 1024) { 
 frameCount = 0; // Go back to the beginning
/* Notice that the built in Timer Variable can be set back to 0. All the built in Function does is increment a Variable by 1. By resetting the frameCount Variable to whatever you like, you can jump forward or backward to any point in your animation :) */
}
}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

