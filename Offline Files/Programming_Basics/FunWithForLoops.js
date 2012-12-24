var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Different things that can be done Using For Loops. <Description>*/

//background(50, 0, 70); 
stroke(0, 0, 0, 128);
strokeWeight(3);  

/* Draw Red Triangle at Original Coordinates
Triangle's top corner is at 0,0 */
fill(255, 0, 0); // Color Red
triangle(0, 0, 0, 48, 40, 26); // Draw 1 Triangle

/* Translate World Center from 0,0 to Screen Center 
and Draw Orange Hexaflexagon */
fill(255, 127, 0); // Color Orange
translate(106,108); 
for(var triangles = 0; triangles < 6; triangles++){   
  triangle(0,0,0,48,40,26); 
  rotate(60); // Rotate around 0,0
} 
resetMatrix();  // Set Matrix back to 0,0

//Draw Vertical Row of Yellow Hexaflexagons
fill(255, 255, 0); // Color Yellow
translate(30,67); // Translate World Center
scale(0.3,0.3);

for(var i = 0; i < 10; i++){ 
  // Revolve 6 Triangles to Draw Hexaflexagon
  for(triangles = 0; triangles < 6; triangles++){   
      triangle(0,0,0,48,40,26); 
      rotate(60); // Rotate around 0,0
  } 
  translate(0,110); 
}
resetMatrix(); // Set Matrix back to 0,0

//Draw Green Hexaflexagon Sequence
fill(0, 255, 0); // Color Green
scale(0.4,0.4);
//Translate World Center
translate(55,70); 

for(var hexX = 1; hexX <= 6; hexX++){ 
  pushMatrix();
  translate(hexX*140,0);
  // Revolve 6 Triangles
  for(var triangles = 0; triangles < hexX; triangles++){   
      triangle(0,0,0,48,40,26); 
      rotate(60); // Rotate around 0,0
  } 
  popMatrix();
}
resetMatrix();  // Set Matrix back to 0,0

//Draw Magenta HexaflexaCircle
fill(255, 0, 255); // Color Magenta
//Translate World Center
translate(250,250); 
scale(0.25,0.25);

for(var i = 0; i < 24; i++){
  rotate(15); // Rotate around Offset
  pushMatrix();
  translate(0,493); 
for(triangles = 0; triangles < 6; triangles++){   
      triangle(0,0,0,48,40,26); 
      rotate(60); // Rotate around 0,0
  } 
popMatrix();
}
resetMatrix();

var conditionalOffset; 

translate(180,180); 
scale(0.2,0.2);
var colorCycle = 0;
for(var i = 0; i < 8; i++){ 
  for(var j = 0; j < 10; j++){ 
fill(i*50, random(0,255), j*36); // Color Random
pushMatrix();
/* Conditional Variable ;)
if(j is even number) conditionalOffset = 0 : otherwise 43 */
conditionalOffset = ( j % 2) ? 0 : 43; 
  translate(conditionalOffset,0); 
  // Revolve 6 Triangles to Draw Hexaflexagon
  for(triangles = 0; triangles < 6; triangles++){   
      triangle(0,0,0,48,40,26); 
      rotate(60); // Rotate around 0,0
  } 
  popMatrix();
translate(0,77); 
//colorCycle+=2;
}
translate(90,-770);  
}


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

