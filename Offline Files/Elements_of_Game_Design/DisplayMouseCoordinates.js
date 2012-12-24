		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


//<Description> Display mouse position using Computer Science coordinates, where +Y is Down. </Description>

// Begin Game Loop
draw = function() {
    // Clear the Screen White
    background(255); 
    
    // draw the background grid
stroke(128, 255, 255);
for (var i= 0; i < 400 ; i = i + 10) {
    line(i, 0, i, 400);
    line(0, i, 400, i);
}
    
    fill(0, 0, 0); // Set the Text color to Black
    text("Mouse Position X =", 15, 30); text(mouseX, 125, 30); 
    text("Mouse Position Y =", 15, 50); text(mouseY, 125, 50); 
    
    stroke(0); // color black
    // Create a Cursor icon
    // Draw a Point at Mouse Position(X, Y)
    point(mouseX, mouseY); 
    // Draw 4 Lines around Mouse Position
    line(mouseX, mouseY - 14, mouseX, mouseY - 7); 
    line(mouseX, mouseY + 7, mouseX, mouseY + 14); 
    line(mouseX - 14, mouseY, mouseX - 7, mouseY );     
    line(mouseX + 7, mouseY, mouseX + 14, mouseY ); 

}; // End Game Loop

// Tutorials in plain English by Dillinger 2012


		}};