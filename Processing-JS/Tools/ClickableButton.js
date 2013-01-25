var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var myButton = [];

var createButton = function(bX, bY, bW, bH,bC, bL){ 
    myButton.push({
    x:bX,
    y:bY,
    width:bW,
    height:bH,
    clicked: bC,
    label: bL
    });
};

// Pass the coordinates to the create Button Function
createButton(70, 180, 100, 64, false, "Button 0"); 
createButton(200, 180, 100, 64, false, "Button 1"); 

var tempX, tempY; 
var updateButton = function(b){
for (var i = 0; i < b.length; i++){ 
fill(255, 0, 0);  // Idle color
tempX = b[i].x; tempY = b[i].y; // Store Button Position
// Check for Collision
    if( (mouseX > b[i].x) && 
        (mouseX < b[i].x + b[i].width) &&
        (mouseY > b[i].y) &&
        (mouseY < b[i].y + b[i].height)) {
            fill(255, 64, 64); // Rollover color
            if (mouseIsPressed){ 
                fill(0, 255, 0); // Pressed color 
                if(b[i].clicked === false){
                    b[i].x += 3; b[i].y += 3; 
                }
                b[i].clicked = true; 
            } 
            if(!mouseIsPressed && b[i].clicked === true){
                b[i].x -= 3; b[i].y -= 3; 
                b[i].clicked = false; 
            } 
        }
        rect(b[i].x, b[i].y, b[i].width, b[i].height, 4);
        fill(255); 
        textSize(22);
        text(b[i].label, b[i].x + 10, b[i].y + 40);
    }
};


 // Begin Game Loop
draw = function(){
background(0); // Clear the Screen Black

    updateButton(myButton);

    if(myButton[0].clicked){
        fill(0, 255, 0); // Pressed color
        text("Button 0 is Clicked", 40, 120);
    }
    if(myButton[1].clicked){
        fill(0, 255, 0); // Pressed color
        text("Button 1 is Clicked", 180, 120);
    }
}; // End Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

