var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


translate(205,192);
scale(0.8,0.8);

fill(255, 255, 0);
stroke(68, 0, 255);
background(0);

for(var hexX = 1; hexX <= 300; hexX += 30){ 
//translate(60,0);

    // Revolve 6 Triangles
    for(var triangles = 1; triangles <= 44; triangles++){   
        
        triangle(116,0,hexX,48,triangles+40,-18); 
        rotate(60); // Rotate around 0,0
    } 

}

// Thank you Vi Hart. You are awesome!
/* Graphix by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */






}};

