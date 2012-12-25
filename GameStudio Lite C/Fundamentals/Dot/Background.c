// Background.c
// Add a background and make Dot rebound off background walls

#include <acknex.h>
#include <default.c>

var Move_Right = 1 ;
var Move_Down = 1 ;

FONT* digital_font = "digital.pcx"; 
var left_score = 0;
var right_score = 0;

PANEL* background_pan = // the background panel
{
	bmap = "Background.pcx";
	layer = 1;
//	digits(330, 40, 2, digital_font, 1, left_score); 
//	digits(395, 40, 2, digital_font, 1, right_score); 
	flags = VISIBLE;
}

PANEL* debugPanel = // Create a Text Panel to display Variables to the screen
{
		layer = 3;
  	digits( 10,10,3,*,1,My_Dot.pos_x ); 
  	digits( 10,20,3,*,1,My_Dot.pos_y ); 
  	flags = VISIBLE ;
}

PANEL* My_Dot = 
{
	bmap = "Dot.pcx" ;
	layer = 2 ;
	pos_x = 396 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	

function update_ball_position()
{
      if ( Move_Right ) { My_Dot.pos_x++ ; } // Update Dot Position Right
        else { My_Dot.pos_x-- ; } // Update Dot Position Left
        
      if ( Move_Down ) { My_Dot.pos_y++ ; } // Update Dot Position Down
        else { My_Dot.pos_y-- ; } // Update Dot Position Up	
}

function update_boundaries()
{
         if ( My_Dot.pos_x > 770 ) { Move_Right = 0 ; } // If Dot goes into the right endzone, set the X Direction negative
      	if ( My_Dot.pos_x < 30 ) { Move_Right = 1 ; }  // If Dot goes into the left endzone, set the X Direction to positive
      	if ( My_Dot.pos_y > 570 ) { Move_Down = 0 ; } // If Dot hits the bottom boundary, set the Y Direction to negative
      	if ( My_Dot.pos_y < 30 ) { Move_Down = 1 ; }  // If Dot hits the top boundary, set the Y Direction to positive
}

function main()
{
	
   video_mode = 7 ; // Screen Resolution 800 X 600
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Background" ) ; 
	
   
	while ( 1 ) 
	{
      
		update_ball_position() ; 
		
		update_boundaries() ; 
		      
     wait ( 2 ) ; 
   }

}
