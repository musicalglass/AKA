var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//<Description> Play Midi </Description>

background(0); 
mousePressed = function(){ 
midiBridge.sendMidiEvent(midiBridge.NOTE_ON, 1, noteNumbers[87], 100);
background(255);  
};
mouseReleased = function(){ 
midiBridge.sendMidiEvent(midiBridge.NOTE_OFF, 1, noteNumbers[87], 0);
background(0);  
};


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

