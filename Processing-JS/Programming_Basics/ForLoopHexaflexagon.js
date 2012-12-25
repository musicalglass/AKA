var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Draw 6 Triangles Using For Loop. </Description>*/

background(50, 0, 70); 
stroke(255, 255, 25, 128);
strokeWeight(3);  
fill(255, 0, 0);

/* Draw Triangle at Original Coordinates
Triangle's top corner is at 0,0 */
triangle(0,0,0,48,40,26); 

// Translate World Center from 0,0 to Screen Center
translate(200,200); 

for(var triangles = 0; triangles < 6; triangles++){   
    triangle(0,0,0,48,40,26); 
    rotate(60); // Rotate around 0,0
} 

// Needed if you intend to do more Transformations
// resetMatrix();  

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

