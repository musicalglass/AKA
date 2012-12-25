var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//<Description> Move individual Circles when Mouse is dragged. </Description>

var centerOffset = 0;
var offsetX = 0; 
var offsetY = 0; 
offsetX += centerOffset; 
offsetY += centerOffset; 

var bezierThickness = 2;

translate(offsetX, offsetY);
rotate(0);

var dragCircles = [];

// When function is called, "push" a new Array entry
var createCircle = function(cX,cY){
    dragCircles.push({
        x:cX,
        y:cY,
        mouseOver: false,
        circleSize: 12
    });
};

var drawDraggableCircles = function(){
    strokeWeight(1);
// Cycle through the Array and draw a Circle for each entry
    for (var i = 0; i < dragCircles.length; i++){
if(dist(dragCircles[i].x, dragCircles[i].y, mouseX-offsetX, mouseY-offsetY) < dragCircles[i].circleSize/1.5 ){
            fill (128, 0, 255, 120); 
        }
        else{ 
            noFill(); 
        }
        ellipse(dragCircles[i].x, dragCircles[i].y, dragCircles[i].circleSize, dragCircles[i].circleSize);
    }
};

mouseDragged = function(){
    // Cycle through the Array
    for (var i = 0; i < dragCircles.length; i++){
        // If Radius Collision Detected...
        if (dist(dragCircles[i].x, dragCircles[i].y, 
            mouseX-offsetX, mouseY-offsetY) < dragCircles[i].circleSize/1.5 ){
            // Move Circle to current Mouse Position
            dragCircles[i].x = mouseX-offsetX;
            dragCircles[i].y = mouseY-offsetY;
        }
    }
        var s = "Copy text here :)\n\n bezier(" + dragCircles[0].x + ", " + dragCircles[0].y + ", "+ dragCircles[1].x + ", " + dragCircles[1].y + ", "+ dragCircles[2].x + ", " + dragCircles[2].y + ", "+ dragCircles[3].x + ", " + dragCircles[3].y + "); \n\n";

    println(s);
};

var displayText = function(){
textSize(12);
fill(0, 0, 0, 100);
// Display Numbers
// Y Axis
text(" Y", 5, 50); 
text("100", 5, 100); text("150", 5, 150); text("200", 5, 200); 
text("250", 5, 250); text("300", 5, 300); text("350", 5, 350); 

// X Axis
text("X", 50, 15); 
text("100", 100, 15); text("150", 150, 15); text("200", 200, 15); 
text("250", 250, 15); text("300", 300, 15); text("350", 350, 15);
stroke(0); // Restore stroke to normal
};

var drawGrid = function(){
    strokeWeight(1); // Line Thickness
    stroke(0, 0, 0, 160);
    // Draw Black Crosshair Lines at 0,0
    line(0, -400, 0, 400); // Y Axis Line
    line(-400, 0, 400, 0); // X Axis Line

    // Draw Blue Grid
    stroke(0, 100, 255, 75); // Opaque Blue
    for(var i = -400; i < 400 ; i = i + 10){
        line(i, -400, i, 400);
        line(-400, i, 400, i);
    }
};

createCircle(100, 135); createCircle(190, 194);
createCircle(190, 80); createCircle(300, 135);

// Begin Game Loop
draw = function(){
background(255); // Clear the Screen White

drawGrid();
displayText(); 

drawDraggableCircles();

noFill();
strokeWeight(bezierThickness);
bezier(dragCircles[0].x, dragCircles[0].y, dragCircles[1].x, dragCircles[1].y ,dragCircles[2].x, dragCircles[2].y, dragCircles[3].x, dragCircles[3].y);

stroke(0, 225, 255, 70); // Handle color light blue
line(dragCircles[0].x,dragCircles[0].y,dragCircles[1].x,dragCircles[1].y);
line(dragCircles[2].x,dragCircles[2].y,dragCircles[3].x,dragCircles[3].y);

}; // end Game Loop



/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */




}};

