var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var wiggleSpeed = 10; 
var wiggleWidth = 150; 
var wiggleFrequency = 2;
translate(120,188);
scale(0.9,0.9);

draw = function(){
background(0);

var x = 0;  var y = 150; 

for (var i = 0.0; i < 65; i++){
x = wiggleWidth * sin( -y * wiggleFrequency + (frameCount * wiggleSpeed));

/* Maybe could have done this with another For Loop, but the hour grows late. zzzz*/
stroke(255, 0, 0); //red
fill(0, 0, 0, 30);
ellipse(y, -y, -x, -y); 
stroke(255, 127, 0); //orange
fill(0, 0, 0, 30);
ellipse(y+60, y, -x, -y); 
stroke(255, 255, 0); //yellow
fill(0, 0, 0,30);
ellipse(y+120, -y, -x, -y); 
stroke(0, 255, 0); //green
fill(0, 0, 0,30);
ellipse(y+180, y, -x, -y); 
stroke(0, 0, 255); //blue
fill(0, 0, 0,30);
ellipse(y+240, -y, -x, -y); 
    stroke(166, 0, 255); //purple
fill(0, 0, 0,30);
ellipse(y+300, y, -x, -y); 
        y -= 5.5;
    }
    
};


/* Animations by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

