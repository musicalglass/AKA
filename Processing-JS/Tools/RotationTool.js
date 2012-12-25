var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);

//<Description> A Layout tool for Rotation. </Description>

var myButton=[];
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
        else{ fill(255, 0, 0); } // Idle color
};

var drawButton = function(b){
    rect(b[0].x, b[0].y, b[0].Width, b[0].Height);
    fill(255, 255, 255);
    text("OK", b[0].x + 21, b[0].y + 25);
};

 // Begin Game Loop
draw = function(){
    background(0); // Clear the Screen Black

    updateButton(myButton);
    drawButton(myButton);

    if(buttonClicked){
        fill(0, 255, 0); // Pressed color
        text("Button is Clicked", 154, 120);
    }
}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

