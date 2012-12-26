var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


if(online) {  // or "if (online === true)"
  ellipse(50, 50, 60, 60);
} else {
  line(0, 0, 100, 100);
  line(100, 0, 0, 100);
}




}};