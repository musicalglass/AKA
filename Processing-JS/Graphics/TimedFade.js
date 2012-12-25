var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//<Description> Fade Effect. </Description>

//Declare CONSTANT_VARIABLES
var FRAMES_PER_SECOND = 30; 

//Declare operatorVariables
var colorFade = 255;

/* Begin Game Loop. Everything in here will be drawn over and over at 30 Frames Per Second. */
draw = function(){
//Black Backgrounds save power on handheld devices ;)
background(0); 

//Use built in frameCount Function to time event
if(frameCount > FRAMES_PER_SECOND * 4){
 colorFade -= 4.2; // Set speed of fade
}

fill(255, 0, 0, colorFade);
textSize(24);
text("frameCount = " + frameCount,80,91);
fill(255, 0, 255, colorFade);
text("Hey Yo!",80,150);
ellipse(200,260, 100,64);

}; // End Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

