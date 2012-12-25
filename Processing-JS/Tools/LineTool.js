var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Draggable Line with copyable code snippet. </Description>*/

var countClicks = 0;
var startPointX, startPointY;
var endPointX, endPointY;
var dragCircles = [];

// When function is called, "push" a new Array entry
var createCircle = function(){
    dragCircles.push({
        x:mouseX,
        y:mouseY,
        mouseOver: false,
        circleSize: 30,
        lineEnd: ""
    });
};

mousePressed = function(){
    if(countClicks === 0){
        startPointX = mouseX;
        startPointY = mouseY;
        createCircle();
        dragCircles[0].lineEnd = "start";
    }
    if(countClicks === 1){
        endPointX = mouseX;
        endPointY = mouseY;
        createCircle();
        dragCircles[1].lineEnd = "end";
    }
countClicks++;
};


var drawDraggableCircles = function(){
noStroke();
// Cycle through the Array and draw a Circle for each entry
for (var i = 0; i < dragCircles.length; i++){
    if(dist(dragCircles[i].x, dragCircles[i].y, mouseX, mouseY) < dragCircles[i].circleSize ){
        fill(128, 0, 255, 80); }
        else{ noFill(); }

        ellipse(dragCircles[i].x, dragCircles[i].y, 12, 12);
    }
    fill(0);
};

mouseDragged = function(){
    // Cycle through the Array
    for (var i = 0; i < dragCircles.length; i++){
        // If Radius Collision Detected...
        if (dist(dragCircles[i].x, dragCircles[i].y, 
            mouseX, mouseY) < dragCircles[i].circleSize ){
            // Move Circle to current Mouse Position
            dragCircles[i].x = mouseX;
            dragCircles[i].y = mouseY;
        }
        startPointX = dragCircles[0].x; 
        startPointY = dragCircles[0].y; 
        endPointX = dragCircles[1].x; 
        endPointY = dragCircles[1].y; 
    }

    if(countClicks > 2){
    var s = "Copy text here :)\n\n line(" + startPointX + ", " + startPointY + ", "+ endPointX + ", " + endPointY + "); \n\n";

    println(s);

    }
};

var displayText = function(){
textSize(12);

// Display Numbers
// Y Axis
text(" Y", 5, 50); 
text("100", 5, 100); 
text("150", 5, 150); 
text("200", 5, 200); 
text("250", 5, 250); 
text("300", 5, 300); 
text("350", 5, 350); 

// X Axis
text("X", 50, 15); 
text("100", 100, 15); 
text("150", 150, 15); 
text("200", 200, 15); 
text("250", 250, 15); 
text("300", 300, 15); 

text("350", 350, 15); 
};

// Begin Game Loop
draw = function(){
background(255); 

// draw the background grid
stroke(128, 255, 255);
for (var i = 0; i < 400 ; i = i + 10){
    line(i, 0, i, 400);
    line(0, i, 400, i);
}

displayText(); 
    if(countClicks === 0){
        fill(0);
        textSize(24);
        text("Click the Canvas in 2 different \nplaces to draw a line", 50, 59); 
    }
    if(countClicks === 2){
        fill(0);
        textSize(24);
        text("Drag the endpoints to move \nline to desired Position", 50, 46);
    }
    if(countClicks > 1){
        stroke(0);
        line(startPointX, startPointY, endPointX, endPointY); 
    }

    drawDraggableCircles();

}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */





}};

