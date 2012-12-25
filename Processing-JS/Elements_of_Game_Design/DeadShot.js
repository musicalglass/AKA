var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//Never Miss! A Winner every time ;)
var score = 0;

strokeWeight(66);
stroke(255, 0, 0);
fill(26, 26, 26);
textSize(24);

// Each time mouse is clicked...
mouseClicked = function(){ 
    score++; // Increment the score by 1
};

draw = function() {
    background(255); 

    ellipse(mouseX, mouseY, 15, 15);
    text("Score: " + score, 40, 40);
}; 


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

