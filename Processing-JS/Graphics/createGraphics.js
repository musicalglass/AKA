var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/* This is Object Oriented Programming. 
Don't get intimidated by the 
objectName.doSomethingToObject structure. */

//Create Graphic OBJECT size 100,100
var myImage = this.createGraphics(100, 100);

//Begin filling Object with stuff
myImage.beginDraw(); 

//Same commands you know. 
//Only now you are referencing myObject.sameOldFunctions();
myImage.background(102);
myImage.stroke(255);
myImage.line(10, 10, 90, 90);

//Stop filling Object with stuff
myImage.endDraw();

//Draw the reusable image as many times as you like ;)
image(myImage, 100, 100);

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

