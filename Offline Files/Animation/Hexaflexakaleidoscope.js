var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var angle = 0;
var radius = 70;
var centerX = 200;
var centerY = 200;

translate(200,200);
scale(0.8,0.8);

// fill(255, 255, 0);
noFill();
stroke(64, 0, 255);

draw = function() {
background(0);
// calculate coordinates of the Triangles using sin and cosine
var x = sin(angle) * radius;
var y = cos(angle) * radius;

// Nested For Loops ;)
    for(var hexX = 1; hexX <= 300; hexX += 30){ 
    angle = angle + 0.1;
    
        for(var triangles = 1; triangles <= 44; triangles++){ 
            triangle(x*4,0,hexX,24,triangles,y*2); 
            rotate(60); // Rotate around 0,0
        } 
    }
};


// Thanks to Vi Hart and Jessica Liu. You are inspirational!

/* Animations by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

