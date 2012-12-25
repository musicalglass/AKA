var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var cubeX = 0;
var cubeY = 0;
var animateCube = 0;

// Click the screen to Animate Cube
mousePressed = function(){
    animateCube += 1;
};

// Begin Game Loop
draw = function (){
background(0); // Set color(greyscale)

noStroke();
fill(204, 0, 255);
triangle(150, 115 + cubeY, 200, 80 + cubeY, 250, 115 + cubeY);
triangle(150, 115 + cubeY / 1.5, 200, 145 + cubeY / 1.5, 250, 115 + cubeY / 1.5);
fill(226, 130, 250);
triangle(150 - cubeX, 115, 200 - cubeX, 145, 150 - cubeX, 186);
triangle(200 - cubeX / 1.5, 216, 200 - cubeX / 1.5, 144, 150 - cubeX / 1.5, 185);
fill(130, 0, 163);
triangle(200 + cubeX / 1.5, 216, 200 + cubeX / 1.5, 144, 250 + cubeX / 1.5, 185);
triangle(250 + cubeX, 115, 200 + cubeX, 145, 250 + cubeX, 186);

if(animateCube > 0 && animateCube < 50){
    cubeX++;
    cubeY--;
    animateCube++;
}
fill(200);
    textSize(24);
if (animateCube === 50){
    text("Almost everything in the 3D \nWorld is constructed entirely \nof shaded Triangles!",45,290);
}
if (animateCube === 0){
    text("Click on the cube to\nunderstand how 3D works",45,310);
}
if (animateCube === 51){
    text("Because Triangles were used \nto simulate 3D, video card \nmanufacturers built them \ninto the hardware.",45,274);
}
if (animateCube === 52){
    text("So now a computer can draw \nthem extremely fast.",45,285);
}
if (animateCube === 53){
    text("When you draw a Rectangle \nyou are actually drawing \n2 adjacent Triangles.",45,285);
}
if (animateCube === 54){
    text("Your program sends the \ncoordinates to your Video \ncard (the hardware that \nspeaks to your monitor)",65,265);
}
if (animateCube === 55){
    text("Which scales it to the right \nresolution for you to see \non your monitor :)",58,280);
}
if (animateCube === 56){
    text("That's how most 3D is done for\nnow. In the future, we may find \nbetter ways to simulate 3D.",34,278);
}
if (animateCube === 57){
    text("Maybe here at Khan University ;)",28,316);
}
if (animateCube === 58){
    text("Now you know all about the \nState of the Art in 3D :)",55,298);
}
if (animateCube === 59){
    cubeX = 0;
    cubeY = 0;
    animateCube = 0;
}


};


/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

