var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//Using Modified Sin from rainbow in Nyan Cat 

var wiggleSpeed = 8; 
var wiggleWidth = 16; 
var wiggleFrequency = 4;
translate(200,100);

draw = function(){
background(0);

var x = 0;    var y = 0; 

for (var i = 0; i < 56; i++){
    fill(226, 42, 247);
    stroke(255, 0, 0);
    
x = wiggleWidth * sin( y * wiggleFrequency + (frameCount * wiggleSpeed));
        ellipse(x, y, 20, 20); // Body
        stroke(0); // Eyeball colors
        fill(255);
        ellipse(x + 5, y-1, 10, 8); // Eyes
        ellipse(x - 5, y-1, 10, 8);
        ellipse(x + 5, y, 2, 2); // Pupils
        ellipse(x - 5, y , 2, 2);
        arc(x, y+5, 14, 8, 1, 180); // Smile
        y += 2;
    }
};


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

