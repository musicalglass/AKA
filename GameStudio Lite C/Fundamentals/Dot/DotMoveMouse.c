// DotMoveMouse.c
// Make Dot move using the Mouse

#include <acknex.h>
#include <default.c>

//mouse_pointer = 0; 
//mouse_mode = 0;

PANEL* My_Dot = 
{
	bmap = "Dot.pcx" ;
	layer = 2 ;
	pos_x = 50 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	

function main()
{
   video_mode = 7 ; // Screen Resolution 800 X 600
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Move Dot Using Mouse" ) ;
	
   
	while ( 1 )
	{
      vec_set(screen_color, vector( 55, 55, 55 )) ; // Clear the Screen Dark Grey

      My_Dot.pos_x = mouse_cursor.x  ; // Update Dot Position
      My_Dot.pos_y = mouse_cursor.y  ;
      
		wait ( 1 ) ; // Pause a bit before repeating While Loop

	}
}
