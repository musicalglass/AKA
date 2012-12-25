var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> A simple program that converts a Decimal Number to it's Binary equivalent. </Description>*/

var myDecimal = 2; // Set the Decimal Value to Convert

background(0);
fill(150, 0, 255);
// Set Font Attributes
textFont(createFont("fantasy", 18), 36); 

// Print Variable
text("Variable: " + myDecimal, 50, 95); 
// Convert the same Variable to binary (Number, Digits)
text("Binary: " + binary(myDecimal, 10), 50, 134); 


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

