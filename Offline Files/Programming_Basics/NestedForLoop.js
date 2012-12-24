var sketchProc=function(processingInstance){ with (processingInstance){
size(400, 400); 
frameRate(30);


/*<Description> Use a For Loop to create a Column of Rectangles. Use a second For Loop to create Rows of Columns. </Description>
Try playing with the Numbers! :) */

// For( startValue; While True; Increment Value )
// Starting at 100; Until it reaches 300; Add 20 each loop

for (var counterX = 100; counterX <= 300; counterX += 20){
    
		for(var counterY = 100; counterY <= 300; counterY += 20){
// Use Variables from the For Loops to set Rectangle Positions
			rect( counterX, counterY, 12, 12 ) ; 
		}
        
}

/* Tutorials in plain English by Dillinger © 2012. 
All code is owned by its respective author and made available under an MIT license:
http://opensource.org/licenses/mit-license.php */



}};

