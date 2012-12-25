var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/* Still like to get around to making it so you can scale the wheel size. */

var rot = 4;
var x = 400;

draw = function() {
    
    translate(x, 200);
    scale(0.5,0.5);
    
    background(255);
  
    rotate(rot);
    stroke(0, 0, 0);
    fill(97, 64, 35);
    ellipse(0, 0, 200, 200);
    fill(255);
    ellipse(0, 0, 160, 160);
    
    stroke(97, 64, 35);
    strokeWeight(5);
    line(0, 0, 0, -80);
    line(0, 0, 0 + 80, 0);
    line(0, 0, 0, 80);
    line(0, 0, 0 - 80, 0);
    line(0, 0, 0 + 56.5, -56.5);
    line(0, 0, 0 + 56.5, 56.5);
    line(0, 0, 0 - 56.5, 56.5);
    line(0, 0, 0 - 56.5, -56.5);
    resetMatrix();
    line(0, 253, 400, 253); 
    var framesPerSecond = 30 ; 
    var rotateDegrees = 360; 
    x --;
   rot = x / (2.8 * PI) * (rotateDegrees / framesPerSecond); 
    if (x < -50){ x = 450; }
};



/* Animations by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

