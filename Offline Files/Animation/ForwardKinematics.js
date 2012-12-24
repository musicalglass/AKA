var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);

/*<Description> Create a Rotational Heirarchy. </Description>*/

//Declare operatorVariables
var leftLegRotate = 48;
var leftShinRotate = -29;

translate(200,200); // Set 0,0 to screen Center

//Begin Game Loop
draw = function(){
background(255); // Set color(greyscale)

pushMatrix(); 

//Pelvis
fill(255);
strokeWeight(4); 
ellipse(0,0,60,52);

popMatrix();

strokeWeight(20); 

//Leg Left
pushMatrix(); 

translate(0,12);
rotate(leftLegRotate);
//draw a line
line(0, 0, 0, 60);

//Shin Left
translate(0,60);
rotate(leftShinRotate);
line(0, 0, 0, 54);

popMatrix();

};


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

