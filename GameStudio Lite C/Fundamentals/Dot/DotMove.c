// DotMove.c
// Make Dot move in increments each time the screen is refreshed

#include <acknex.h>
#include <default.c>

PANEL* My_Dot = 
{
	bmap = "Dot.pcx" ;
	pos_x = 50 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	

function main()
{
   video_mode = 7 ; 
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Move Dot Over Time" ) ; 
	
   
	while ( 1 ) // Everything in the While Loop will keep repeating until the Esc key is pressed
	{
		
      vec_set(screen_color, vector( 55, 55, 55 )) ; // Clear the Screen Dark Grey

      My_Dot.pos_x = My_Dot.pos_x + 20  ; // Update Dot Position
      
		wait ( 500 ) ; // Pause a bit before repeating While Loop

	}
	
}
