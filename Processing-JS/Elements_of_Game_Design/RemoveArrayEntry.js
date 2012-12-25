		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


//<Description> Remove a single entry from an Array using splice() </Description>

var arraySize = 10; // Set the size of our Array

// Create an empty Array of whateverSize
var myArray = [arraySize]; 

// Populate Array with corresponding numbers
// Cycle through each Array entry...
for (var i = 0; i <= arraySize; i++){ 
    myArray[i] = i; // write the For Loop Variable into each
}

fill(0); // Set Text color
// Distance in pixels to next new line of Text
var lineWidth = 14; 

// Print the values onscreen
for (var i = 0; i <= arraySize; i++){ 
// Print each on new line, starting 100 pixels down
    text(myArray[i], 100, i * lineWidth + 100); 
}

// Remove entry from Array
// Any number you like
var slotToRemove = 2;
// You are Terminated!!
myArray.splice(slotToRemove, 1);

// Print the new values to the screen
for (var i = 0; i <= arraySize; i++) { 
    text(myArray[i], 230, i * lineWidth + 100); 
}

/* Tutorials in plain English by Dillinger &copy; 2012. <br>
All code is owned by its respective author and made available under 
an MIT license:<br>
http://opensource.org/licenses/mit-license.php */



		}};