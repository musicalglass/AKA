var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//Inspired by Rick Griffin 1944 - 1991

background(0);
noStroke();

for (var a = 104; a > 0; a--) {
    fill(cos(a*0.618)*255, cos(a)*255, 0);
    ellipse(200, 200, a, a);
}


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and 
made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

