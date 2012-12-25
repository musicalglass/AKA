var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var myPossesion = true; 
var mySubject = "This "; 
var myPredicate = ""; 
var myObject = "mine!"; 
/*<Description> Concatenate a String and Print it to the Screen. </Description>*/ 

var myString = ""; 
if(myPossesion){ myPredicate = "is "; } 
else{ myPredicate = "is not "; } 

fill(0); 
textSize(24); 
myString = mySubject + myPredicate + myObject; 
text(myString,100,100); 

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

