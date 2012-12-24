var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Print Keyboard and Mouse Functions to the screen. </Description>*/

textSize(24);

keyPressed = function(){ text("Key Pressed",35,60); };

keyReleased = function(){ text("Key Released",35,114); };

keyTyped = function(){ text("keyTyped" ,35,86); };

mousePressed = function(){ text("mousePressed",35,210); };

mouseClicked = function(){ text("Mouse Clicked ",35,250); };

// Begin Game Loop
draw = function(){
// Black backgrounds save power on handheld devices ;)
background(0); 

text("keyCode: " + keyCode, 35, 35);

text("keyIsPressed: " + keyIsPressed, 35, 150); 

text("key: " + key, 35, 180);

text("mouseButton: " + mouseButton+" \n(2 or 3 button mouse)",35,280);

}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */





}};

