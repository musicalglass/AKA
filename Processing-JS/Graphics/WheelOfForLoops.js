var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*Drag the Mouse left and right in the 4 screen quadrants to change Variables ;) 
<Description> Use a For Loop to generate evenly spaced iterations revolved around a central axis. </Description>*/

translate(200,200);

// Try tweaking the numbers ;)
var iterations = 11;
var radius = 139;
var triangleWidth = 47;
var centerOffset = 16;

var colorFade = 255;

mouseClicked = function(){
    colorFade = 255;
};

mouseDragged = function(){
colorFade = 255; 
// Top half of Screen
if(mouseY > 0 && mouseY < 200){
    if(mouseX > 0 && mouseX < 200){ // Top Left quadrant
        iterations = mouseX; 
    }
    if(mouseX > 200 && mouseX < 400){ // Top Right
        radius = mouseX - 200; 
    }  
} // End top half
    // Bottom half of Screen
    if(mouseY > 200 && mouseY < 400){ // Bottom Left quadrant
        if(mouseX > 0 && mouseX < 200){
        triangleWidth = mouseX; 
    }
    if(mouseX > 200 && mouseX < 400){ // Bottom Right
        centerOffset = mouseX - 300; 
    }  
} // End bottom half

};

/* Begin Draw Loop */
draw = function(){
background(255); 

fill(255, 140, 0, 100);
stroke(0);
// For Loop repeats based on number of iterations
for(var i = 0; i < iterations; i++){
// Try Commenting & Uncommenting different graphics :)
    line(0, centerOffset, 0, radius);
    //strokeWeight(5);
    //point(0,radius);
    //noFill();
    // Tweak Bezier parameters 3 thru 6 to effect curves
    bezier(0, centerOffset, triangleWidth*2, 150 ,0, 211, 0, radius);
    triangle(0,centerOffset, -triangleWidth, radius, triangleWidth, radius);
    
// Divide rotational degrees evenly by number of copies
rotate(360 / iterations);
}

fill(0, 0, 0, colorFade);
stroke(0, 0, 0, colorFade);
    if(colorFade){
        colorFade-=4;
    }
textSize(14);
text("Iterations = " + iterations + "\nRadius = " + radius + "\nTriangle Width = " + triangleWidth + "\nCenter Offset = " + centerOffset, -190, -180);
if(frameCount < 600){
    textSize(18);
text("<-- Iterations -->",-174,-100);
text("<-- Radius -->",39,-100);
text("<-- Width -->",-157,100);
text("<-- Center -->",39,100);
line(0,-200,0,200);
line(-200,0,200,0);
}

}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */






}};

