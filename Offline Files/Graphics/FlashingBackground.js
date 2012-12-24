var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Use built in frameCount function to create a flashing Background effect. </Description>*/

/* Begin Game Loop. Everything in here will be drawn over and over at 30 Frames Per Second. */
draw = function(){
if (frameCount > 2){ 
    background(255, 0, 0); }
if (frameCount > 4){ 
    background(0); 
    frameCount = 0;
}

textSize(24);
text("Red Alert!",150,150);

}; // End Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

