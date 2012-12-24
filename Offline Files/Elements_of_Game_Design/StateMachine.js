var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


/* <Description> A State Machine allows you to change different parameters of your game depending on it's current "State". Useful for creating Levels which may share some, but not necessarily all game attributes. Only that which is within the current Case Statement will be executed. </Description>*/

// The Starting State of the Game
var gameState = "Intro";

// An Array to store Button Data, in case you want more than 1
var myButton=[];

// A Boolean which prevents you from zipping through more than one level in case the level you are going to also uses button clicks.
var buttonClicked = 0;

myButton.push({
    x:170,
    y:180,
    Width:60,
    Height:40
});

var updateButton = function(b){
// Check for Collision
    if( (mouseX > b[0].x) && 
        (mouseX < b[0].x + b[0].Width) &&
        (mouseY > b[0].y) &&
        (mouseY < b[0].y + b[0].Height)) {
            fill(255, 64, 64); // Rollover color
            if (mouseIsPressed){
                buttonClicked = 1;
                fill(0, 255, 0); // Pressed color
                b[0].x = 173; b[0].y = 183;
            } 
            else{ b[0].x = 170; b[0].y = 180; }
            }
        else{ fill(255, 0, 0); // Idle color
        } 
};

var drawButton = function(b){
    rect(b[0].x, b[0].y, b[0].Width, b[0].Height);
    fill(255, 255, 255);
    text("Start", b[0].x + 18, b[0].y + 25);
};

// Begin Game Loop
draw = function(){
    background(0); // Clear the Screen Black
    buttonClicked = 0; // Reset Button
    myButton[0].x = 170; myButton[0].y = 180;
// What is drawn is determined by the String gameState
switch( gameState ) {
  case "Intro": // In case gameState = "Intro"
    fill(255, 0, 0);
    text("Welcome to", 160, 60); 
    text("The Name of the Game", 128, 89); 
    
    updateButton(myButton);
    drawButton(myButton);

    if(buttonClicked){
        gameState = "Main";
// Reset last key pressed if game uses keyboard commands
        keyCode = 0; 
    }
    break; // End of Case Statement

 case "Main": 
    fill(255, 0, 0);
    text("Game Code Goes Here", 132, 100);
    text("Press the Enter Key to end Game", 106, 154);
        if(keyCode === 10){
            gameState = false; // default to Game Over
    }
    break;

    default:
    fill(255, 0, 0);
    text("Game Over", 172, 103);
        updateButton(myButton);
    drawButton(myButton);
        if(buttonClicked){
        gameState = 'Main';
        keyCode = 0; // Reset if game uses keyboard commands
    }
    break;
    
}
}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. <br>
All code is owned by its respective author and made available under 
an MIT license:<br>
http://opensource.org/licenses/mit-license.php */


}};