var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


translate(205,192);

scale(0.8,0.8);

fill(157, 92, 255);

background(0);

//Nested For Loops
for(var hexaflexaY = 0; hexaflexaY < 200; hexaflexaY = hexaflexaY + 30){ 
    // Revolve 6 Triangles
    for(var triangles = 0; triangles < 6; triangles++){   
        triangle(0,hexaflexaY,0,48 + hexaflexaY,40,26); 
        rotate(60); // Rotate around 0,0
    } 

}


/* Graphix by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */






}};

