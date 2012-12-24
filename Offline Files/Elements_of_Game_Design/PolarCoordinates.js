		var sketchProc=function(processingInstance){ with (processingInstance){

size(400, 400); 
frameRate(30);


/*<Description> Using Sin & Cos to calculate correct distance to move in X and Y based on Rotation. </Description>*/

var CAR_SPEED = 2;
var CAR_ROTATION_SPEED = 1;

var car_Rotation = 0;
var car_Position_X = 187;
var car_Position_Y = 202;

var car_X_Scale;
var car_Y_Scale;
var car_Velocity_X;
var car_Velocity_Y;

var updateCar = function(){
if (car_Rotation > 360){ car_Rotation -= 360; }
if (car_Rotation < 0){ car_Rotation += 360; }

// Amount to move in X and Y to correct Radial Coordinates
car_X_Scale = cos(car_Rotation);
car_Y_Scale = sin(car_Rotation);

// Now that we've Scaled X and Y, calculate distance per frame
car_Velocity_X = (CAR_SPEED * car_X_Scale);
car_Velocity_Y = (CAR_SPEED * car_Y_Scale);

// Move the car the correct distance in Cartesian Coordinates
car_Position_X += car_Velocity_X;
car_Position_Y += car_Velocity_Y;

// Optional - Keep Sprite onscreen
if(car_Position_X > 410){ car_Position_X = -10; }
if(car_Position_X < -10){ car_Position_X = 410; }
if(car_Position_Y > 410){ car_Position_Y = -10; }
if(car_Position_Y < -10){ car_Position_Y = 410; }
};

var drawCar = function(){
// Move Matrix 0,0 to Sprite Center
translate(car_Position_X, car_Position_Y); 
rotate(car_Rotation); // Rotate Matrix
scale(0.5, 0.5); // Resize Sprite to taste

// Draw Sprite
fill (255, 166, 0); // Car Color
rect(-40, -25, 80, 50); // Car Body
fill (0, 0, 0); // Black Wheels
rect(-36, 25, 29, 21);
rect(-36, -46, 29, 21);
rect(8, 25, 29, 21);
rect(8, -46, 29, 21);
resetMatrix();

};

// Use Arrow keys to control rotation
keyPressed = function(){
if(keyCode === LEFT) {
car_Rotation -= CAR_ROTATION_SPEED;}
if (keyCode === RIGHT) {
car_Rotation += CAR_ROTATION_SPEED;} 
};

// Begin Game Loop
draw = function () {
background(255); // Set Background color

text("Click inside Game window to activate Keyboard control", 40, 24);

text("Use Right and Left Arrow keys to steer car", 70, 43);

updateCar();
drawCar();

}; // End Game Loop
/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */

		}};