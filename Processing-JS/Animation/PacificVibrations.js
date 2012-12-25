var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var wiggleSpeed = 40; 
var wiggleWidth = 35; 
var wiggleFrequency = 2;
frameRate(8);

translate(200,200);
scale(0.5,0.5);

var x, y; 

var lineThickness = 24;
var greyValue = 0; // Gradient Opacity Value

draw = function(){
//background(255, 255, 0); // Bottom Gradient Color

strokeWeight(lineThickness);

// Starting from the Bottom and going Up
for(var i = 36; i >= -412; i = i - lineThickness){
 stroke(255, 0, 0, greyValue); // Top Gradient Color 
 // Use Variable from For Loop to change each line's Position
 line(-400, i, 400, i); 
 greyValue = greyValue + 4; 
}

pushMatrix();
for(var reps = 12; reps > 0; reps--){
strokeWeight(1);

x = 0;
y = 10; 

    for (var j = 0.0; j < 45; j++){
    fill(150, 174, 230);
    stroke(255, 170, 0);
    x = wiggleWidth * sin( y * wiggleFrequency + (frameCount * wiggleSpeed)); 
noFill();
    ellipse(y-260+x, x+10, 16+y, y/6); 
        y +=7;
    }
  //  stroke(x*2, 0, x*2, y/3);
   // strokeWeight(10);
    
rotate(17);
   // ellipse(y-260, x, x*5, y*4); 
   // rotate(1);
}
 popMatrix(); 
 noStroke();
fill(0, 0, 255, 180);
rect(-410,40,820,800);
};


/* Animations by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

