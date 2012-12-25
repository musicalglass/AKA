var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var counter = 0; 

fill(0); // Set text color

 // Continue looping while(evaluation is True)
while(counter < 10){
    
// Print value on new line every 14 pixels
    text(counter, 100, counter * 14); 

// Something MUST be updated within the While Loop or the program will freeze!
    counter++; 
}


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

