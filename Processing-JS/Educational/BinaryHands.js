var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


//A Clean, Well Lit Place to Store Numbers
var myDecimal = 0; 
// Convert to Binary
var myNumb;
// and store them in an Array
var binaryArray = [10];

// Begin Game Loop
draw = function () {
background(255); // Set color(greyscale)

//text(frameCount, 133, 23);
if(frameCount > 45){
    myDecimal++;
    frameCount = 0;
}

if(myDecimal > 1023){
    myDecimal = 0;
}
 
myNumb = binary(myDecimal, 10);
// Draw Blue lines
stroke(127, 255, 255, 100);
strokeWeight(2);
for(var i = 55; i < 400; i = i + 17){
    line(0,i,400,i);
}
stroke(255, 0, 0, 50); // red
line(64,0,64,400); // line
stroke(0); // red

strokeWeight(3);
line(53,127,198,123); // line
line(190,64,216,62); // = 
line(191,74,217,72); 

stroke(0, 0, 0, 64);
strokeWeight(2);
fill(109, 112, 128,100);
ellipse(40,40,14,14); // Paper Holes
ellipse(40,289,14,14);

var customFont = createFont("cursive", 18); //
fill(0); 
textFont(customFont, 17); // Set Custom Font
text(+myDecimal +" numbers delivered",206,41);
textFont(customFont, 18);
text("( " + myNumb + " )",244,67);

if (myNumb >= 1000000000){ // = 512
    binaryArray[0] = 1;
    myNumb -= 1000000000;
}else{ binaryArray[0] = 0; }
if (myNumb >= 100000000){
    binaryArray[1] = 1; // = 256
    myNumb -= 100000000; 
}else{ binaryArray[1] = 0; }
if (myNumb >= 10000000){ // = 128
    binaryArray[2] = 1;
    myNumb -= 10000000; 
}else{ binaryArray[2] = 0; }
if (myNumb >= 1000000){ // = 64
    binaryArray[3] = 1;
    myNumb -= 1000000; 
}else{ binaryArray[3] = 0; }

if (myNumb >= 100000){ // 32
    binaryArray[4] = 1;
    myNumb -= 100000; 
}else{ binaryArray[4] = 0; }

if (myNumb >= 10000){ // 16
    binaryArray[5] = 1;
    myNumb -= 10000; 
}else{ binaryArray[5] = 0; }

if (myNumb >= 1000){ // 8
    binaryArray[6] = 1; 
    myNumb -= 1000; 
}else{ binaryArray[6] = 0; }

if (myNumb >= 100){ // 4
    binaryArray[7] = 1; 
    myNumb -= 100; 
}else{ binaryArray[7] = 0; }

if (myNumb > 1){ // 2
    binaryArray[8] = 1;
    myNumb -= 10; 
}else{ binaryArray[8] = 0; }

if (myNumb > 0){ // 1
    binaryArray[9] = 1;
}else{ binaryArray[9] = 0; }

strokeWeight(1);
stroke(130, 120, 145);
fill(130, 120, 145);

rect(235,226,100,100,43); // Right Hand
rect(65,226,100,100,43); // Left Hand

strokeWeight(22);

if(binaryArray[9]){
    line(334,273,375,245); // Right Thumb Up
    textSize(26);
    fill(0);
    text("1",365,258);
    textSize(24);
    text("+ 1",139,118);
}else{ line(334,281,324,251); } // Right Thumb Down

if(binaryArray[8]){
    line(318,231,328,177); // Index Right Up
    textSize(26);
    fill(0);
    text("2",319,192);
    textSize(24);
    text("+ 2",136,96);
}else{ line(318,231,326,255); } // Right Index Down

if(binaryArray[7]){
    line(293,224,295,158); // Right Middle Up
    textSize(26);
    fill(0);
    text("4",286,173);
    textSize(24);
    text("+ 4",135,75);
}else{ line(293,224,295,229); } // Right Middle Down

if(binaryArray[6]){
    line(269,224,256,167);  // Right 4th Up
    textSize(26);
    fill(0);
    text("8",248,180);
    textSize(24);
    text("+ 8",136,52);
}else{ line(269,224,275,237);  } // Right 4th Down

textSize(20);
if(binaryArray[5]){
    line(250,240,227,195);// Right 5th Up
    fill(0);
    textSize(20);
    text("16",218,204);
    textSize(24);
    text("+ 16",125,30);
}else{ line(250,240,253,275);  } // Right 5th Down

if(binaryArray[4]){
    line(150,240,173,195);// Left 5th Up
    fill(0);
    textSize(20);
    text("32",161,203);
    textSize(24);
    text("+ 32",64,120);
}else{ line(150,240,147,275);  } // Left 5th Down

if(binaryArray[3]){
    line(132,224,144,167);  // Left 4th Up
    fill(0);
    textSize(20);
    text("64",132,177);
    textSize(24);
    text("+ 64",64,98);
}else{ line(131,224,125,237);  } // Left 4th Down

if(binaryArray[2]){
    line(107,224,105,158); //Left Middle Up
    fill(0);
    textSize(20);
    text("128",90,166);
    textSize(24);
    text("+ 128",53,76);
}else{ line(107,224,105,229); } // Left Middle Down

if(binaryArray[1]){
    line(82,231,72,177); // Left Index Up
    fill(0);
    textSize(20);
    text("256",54,184);
    textSize(24);
    text("+ 256",50,53);
}else{ line(82,231,74,255); } // Left Index Down

if(binaryArray[0]){
    line(66,273,25,245); // Right Thumb Up
    fill(0);
    textSize(20);
    text("512",11,253);
    textSize(24);
    text("512",72,30);
}else{ line(66,281,75,251); } // Right Thumb Down

noStroke();
fill(131, 121, 145);
// Right Wrist
quad(257, 323, 315, 320, 322, 400, 256, 400);

// Left Wrist
quad(143, 323, 85, 320, 78, 400, 144, 400);
}; // End Game Loop


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

