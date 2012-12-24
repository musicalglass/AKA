var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var cubeX = 0;
var cubeY = 0;
var animateCube = 0;

translate(0,70);
textSize(32);
background(0);

stroke(0, 30, 255);
strokeWeight(2);

fill(204, 0, 255);
triangle(100, 60, 200, 125, 300, 60); 
fill(226, 110, 255);
triangle(200, 235, 200, 125, 300, 60);
fill(88, 0, 110);
triangle(100, 60, 200, 125, 200, 235); 

strokeWeight(4);
stroke(0, 255, 0);
fill(0, 255, 0);

strokeWeight(8);
point(100,60); 
point(200,235);

text("Vertex",70,-17); 
strokeWeight(4);
line(100,46,110,-5); 
line(100,46,96,30); 
line(100,46,110,32); 

text("Vertices",12,159); 
line(61,125,90,76); 
line(75,87,90,76); 
line(88,94,90,76); 
line(61,172,176,225); 
line(156,224,176,225); 
line(162,210,176,225); 

fill(0, 30, 255);
stroke(0, 30, 255);
text("Edge",282,6);

fill(255, 127, 0);
text("Face",166,94);

line(210,54,277,10); 
line(210,54,219,39); 
line(210,54,227,52); 

textSize(18);
text("A Vector:   var myVector = [x:200,  y:200]; ",30,290); 


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

