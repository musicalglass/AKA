var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


var mySpeed = 4;
var score = 0;
var munchies = [];
var munchNum = 6;
var randomX;
var randomY;
var myDudeX = 200;
var myDudeY = 200;
var startGame = "false";

var createMunchies = function(){
    randomX = round( random(20, 380) );
    randomY = round( random(20, 380) );
    munchies.push({
        x:randomX,
        y:randomY
    });
};

var updateMunchies = function(b){
    for (var i = b.length - 1; i >= 0; i = i - 1){
        if(myDudeX > b[i].x - 8 && 
        myDudeX < b[i].x + 8 && 
        myDudeY > b[i].y - 8 && 
        myDudeY < b[i].y + 8){
            score++;
            munchNum--;
            b.splice(i, 1);
        }
    }
};

var drawMunchies = function(b){
    strokeWeight (2);
    stroke (255, 255, 0);
    fill (255, 0, 0);    
    for (var i = b.length - 1; i >= 0; i = i - 1){
        ellipse(b[i].x, b[i].y, 12, 12);
    }
};

mousePressed = function(){
    for (var i = 1; i <= munchNum; i++) {
    createMunchies();
    startGame = "true";
    }
};

keyPressed = function(){
   if(keyCode === LEFT) {
      myDudeX = myDudeX - mySpeed;}
    if (keyCode === RIGHT) {
      myDudeX = myDudeX + mySpeed;} 
   if(keyCode === UP) {
      myDudeY = myDudeY - mySpeed;}
    if (keyCode === DOWN) {
      myDudeY = myDudeY + mySpeed;} 
};

var drawDude = function(){
    strokeWeight (3);
    stroke (0, 0, 0);
    fill (0, 255, 0);    
    ellipse(myDudeX, myDudeY, 16, 17);
};

// Begin Game Loop
draw = function(){
    background(0); // Clear the Screen Black

// Draw Player
if(munchNum !== 0) {
    drawDude();
}
    updateMunchies(munchies);
    drawMunchies(munchies);

// Use Fantasy Font
var f = createFont("fantasy", 18);
// Set Font Size
textFont(f, 28);

fill (0, 47, 255); // Blue
if (startGame === "false"){
    text("Use Arrow keys to Gobble Dots", 30, 107);
    text("Click Screen to Begin", 80, 172);
}
else{
   fill(255, 0, 0);
text("Score:", 18, 40); text(score, 100, 40); 
}

textFont(f, 52);
if(munchNum === 0) {
    text("Game Over", 96, 200);
    }
}; // End Game Loop

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */


}};

