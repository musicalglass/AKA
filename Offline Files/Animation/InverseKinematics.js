var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);

/*<Description> Allows you to create joints which can positioned by end on the chain. </Description>*/

var root = { x:200, y:150 }; 

var segmentlength = 83;

var drawArm = function(endEffectorX, endEffectorY, preferredRotation){
    var dirx = endEffectorX - root.x;
    var diry = endEffectorY - root.y;
    var len = sqrt(dirx * dirx + diry * diry);
    dirx = dirx / len;
    diry = diry / len;
    
    var poleVectorX, poleVectorY;
    var disc = segmentlength * segmentlength - len * len / 4;
    if(disc < 0){
        poleVectorX = root.x + dirx * segmentlength;
        poleVectorY = root.y + diry * segmentlength;
        endEffectorX = root.x + dirx * segmentlength * 2;
        endEffectorY = root.y + diry * segmentlength * 2;
    } else {
        poleVectorX = root.x + dirx * len / 2;
        poleVectorY = root.y + diry * len / 2;
        disc = sqrt(disc);
        if(preferredRotation < 0){
            disc =- disc; // Make it a negative number
        }
        poleVectorX -= diry * disc;
        poleVectorY += dirx * disc;
    }
    strokeWeight(14);
    line(root.x, root.y, poleVectorX, poleVectorY); // Leg
    line(poleVectorX, poleVectorY, endEffectorX, endEffectorY); // Shin

};

draw = function() {
    background(255);
    drawArm(mouseX, mouseY, -1);  
    strokeWeight(4);
    ellipse(root.x, root.y, 40, 40);
};

// Based on SPIIIDDDERR!!! by neurofuzzy101 2012


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

