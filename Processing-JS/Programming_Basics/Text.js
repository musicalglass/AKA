		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


/*<Description> Use the built in Keyboard Functions to update Variables. </Description>*/

// Declare a CONSTANT_VARIABLE. This never changes.
var DOT_SPEED = 4.2;
// Declare an operatorVariable. This will be updated.
var dotPositionX = 200;
var dotPositionY = 200;

// Declare a Variable
var myVariable = 42;

fill(0); // Set text color to black
// Print Text to the screen
text("hello", 35, 40);

// Print Variable to the screen
text(myVariable, 35, 56);

// Combine Text & Variables
text("My Variable = " + myVariable, 35, 84);

fill(255, 0, 0); // Change Text Color
textSize(28); // Change Text Size
text("Big Red", 204, 38);

// Define custom Font. These are the current choices:
// sans-serif, serif, monospace, fantasy, cursive
var customFont = createFont("fantasy", 18); //
// Add a 4th parameter to color to define Opacity 0 - 255
fill(0, 0, 0, 180); 
textFont(customFont, 36); // Set Custom Font
text("Custom", 203, 83); // Drop Shadow
fill(127, 0, 255);
text("Custom", 200, 80);
fill(0);
textSize(14);
textFont(createFont("sans-serif", 18),14); // Set Custom Font
text("Until one is committed, there is hesitancy, the chance \nto draw back, always ineffectiveness. Concerning all \nacts of initiative (and creation), there is one elementary \ntruth, the ignorance of which kills countless ideas and \nsplendid plans: that the moment one definitely commits \noneself, then providence moves too. A whole stream of \nevents issues from the decision, raising in one’s favour \nall manner of unforeseen incidents and meetings and \nmaterial assistance, which no man could have dreamed \nwould have come his way. \nWhatever you can do or dream you can, begin it. \nBoldness has genius, power and magic in it! \nBegin it now. \n\nWilliam Hutchison Murray", 26, 130);





		}};