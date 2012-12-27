var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


setup= function() {
 size(screen.width, screen.height);
}

draw= function() {
 line(0, 0, screen.width, screen.height);
}


}};