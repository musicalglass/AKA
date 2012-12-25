var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);

/*<Description> Move individual Circles when Mouse is dragged. </Description> */

var dragCircles = [];

var randomX;
var randomY;
// When function is called, "push" a new Array entry
var createCircle = function(){
    randomX = random(10, 390) ;
    randomY = random(10, 390) ;
    dragCircles.push({
        x:randomX,
        y:randomY,
        mouseOver: false,
        circleSize: 30
    });
};

var drawDraggableCircles = function(){
// Cycle through the Array and draw a Circle for each entry
    for (var i = 0; i < dragCircles.length; i++){
if(dist(dragCircles[i].x, dragCircles[i].y, mouseX, mouseY) < dragCircles[i].circleSize ){
            fill (255, 0, 0); }
        else{ noFill(); }

        ellipse(dragCircles[i].x, dragCircles[i].y, 12, 12);
    }
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
    }
};

createCircle();
createCircle();

// Begin Game Loop
draw = function(){
background(255, 255, 255); // Clear the Screen White

drawDraggableCircles();

}; // end Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

