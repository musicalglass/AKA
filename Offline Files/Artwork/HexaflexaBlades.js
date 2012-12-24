var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


translate(205,192);

scale(0.68,0.6);

fill(157, 92, 255);

background(0);

for(var hexX = 1; hexX <= 300; hexX += 30){ 
    // Revolve 6 Triangles
    for(var triangles = 1; triangles <= 42; triangles++){   
        triangle(triangles,0,hexX,48,hexX+40,26); 
        rotate(60); // Rotate around 0,0
    } 
}


/* Graphix by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */






}};

