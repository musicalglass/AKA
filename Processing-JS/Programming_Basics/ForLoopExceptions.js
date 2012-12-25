var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//<Description> Using Break and Continue commands to isolate conditions within a For Loop. </Description>

//This For Loop would normally increment the value by 1 until it reaches 20, no problemo
for (var i = 0 ; i <= 20; i++){

 // If this value is in the batch...
 if (i === 10){ 
     break; // forget the whole thing
 }

// If this For Loop Variable is divisable by 2...
 if (i % 2 === 0){
     continue; // skip this one
 }

var lineHeight = 14; // Distance between lines of text
var offsetY = 80; // Distance from top of page
fill(0); // color(greyscale)

//Print the value of i ( unless otherwise specified )
 text(i, 100 , i * lineHeight + offsetY);
}

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

