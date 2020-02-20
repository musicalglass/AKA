var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);
var angle = -11;
var radius = 2;	
var centerY = 200;
var centerX =200;
draw = function() {
  frameRate(0);
	var x = sin(angle) * radius;
	var y = cos(angle) * radius;
	fill(255,0, 0);
	stroke(0,0, 0);
	ellipse(x+centerX,y+centerY,40,40);
	angle+=-16.5;
	radius+=(0.05);
};}};
