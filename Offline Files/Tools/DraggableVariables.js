var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);

/*<Description> Drag the Mouse left and right in the 4 screen quadrants to change Variables. <Description> */

var colorFade = 255;
var myVar1, myVar2, myVar3, myVar4;

mouseClicked = function(){
    colorFade = 255;
};

mouseDragged = function(){
colorFade = 255; 
// Top half of Screen
if(mouseY > 0 && mouseY < 200){
    if(mouseX > 0 && mouseX < 200){ // Top Left quadrant
        myVar1 = mouseX; 
    }
    if(mouseX > 200 && mouseX < 400){ // Top Right
        myVar2 = mouseX - 200; 
    }  
} // End top half
    // Bottom half of Screen
    if(mouseY > 200 && mouseY < 400){ // Bottom Left quadrant
        if(mouseX > 0 && mouseX < 200){
        myVar3 = mouseX; 
    }
    if(mouseX > 200 && mouseX < 400){ // Bottom Right
        myVar4 = mouseX - 200; 
    }  
} // End bottom half

};

/* The Draw Loop is only being used to erase the text when you stop dragging */
draw = function(){
// Black backgrounds save power on handheld devices ;)
background(0); 
if(colorFade){
    colorFade-=8;
}
fill(255, 255, 255, colorFade);
text("myVar1 = " + myVar1 + "\nmyVar2 = " + myVar2 + "\nmyVar3 = " + myVar3 + "\nmyVar4 = " + myVar4, 20, 50);
}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

