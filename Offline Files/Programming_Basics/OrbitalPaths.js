var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Create Elliptical Orbits using Sin & Cos. </Description>*/

//how far around the orbit the moon is, in radians
var angle = 0;

// how big the orbit is
var radius = 70;

// the Sun's center
var centerX = 235;
var centerY = 200;

var starField = [];

var randomX;
var randomY;

var createStars = function(){
    randomX = random(1, 399);
    randomY = random(1, 399);
    
    starField.push({
        x:randomX,
        y:randomY
    });
};

var drawStars = function(b){
    strokeWeight(2);
    stroke(255, 255, 255);  
    for (var i = 0; i < b.length; i++){
        point(b[i].x, b[i].y);
    }
};

for(var i = 0; i < 80; i++){
    createStars();
}

draw = function() {
    background(0, 0, 0);
    // calculate coordinates of the orbit using sin and cosine
    var x = sin(angle) * radius;
    var y = cos(angle) * radius;
    
    drawStars(starField);
    
    noStroke();
    fill(230, 255, 130);
    
    // move the moon forward along it's orbit
    angle = angle + 0.1;
    
    // Draw the planets
    ellipse(centerX,  centerY, 60, 60);
    fill(186, 3, 252);
    ellipse(x + centerX, y + centerY, 30, 30);
    fill(0, 255, 0);
    ellipse(x + x / 0.6 + centerX, y + centerY, 40, 40);
};


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

