var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


this.colorMode(HSB);
background(0);
strokeWeight(1);
translate(200,69);
scale(0.1,0.22);

var incrementY = 0;
for(var j = 0; j < 120; j+=20){
    translate(0,200);
    for(var i = 0; i < 360; i++){
        rotate(1);
        stroke(i % 360 * 255 / 360, 255, 255);
        line(24, incrementY, 180, 0);
        incrementY++;
    }
}

/* A Spin-Off of Chis Hohmann's HSB Color Mode:
http://www.khanacademy.org/cs/hsb-color-mode/1060898352
Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

