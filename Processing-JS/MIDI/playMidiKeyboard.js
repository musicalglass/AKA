var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


if(mouseClicked){
	midiBridge.sendMidiEvent(midiBridge.NOTE_ON, 1, noteNumbers[87], 100);
}

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and 
made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

