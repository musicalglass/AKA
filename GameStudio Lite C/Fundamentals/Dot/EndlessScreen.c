// EndlessScreen.c
// Reset Dot's Position if it goes offsceen

#include <acknex.h>
#include <default.c>


PANEL* My_Dot = 
{
	bmap = "Dot.pcx" ;
	layer = 11 ;
	pos_x = 50 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	

function main()
{
   video_mode = 7 ; 
   
	wait ( 1 ) ;
	
	video_window( NULL, NULL, 0, "Endless Screen" ) ; 
	
   
	while ( 1 ) 
	{
      vec_set( screen_color, vector( 55, 55, 55 ) ) ; // Clear the Screen Dark Grey

      My_Dot.pos_x = My_Dot.pos_x + 20 ; // Update Dot Position
      
      if ( My_Dot.pos_x > 800 ) { My_Dot.pos_x = 0 ; } // If Dot goes past the right side of screen, set it back to the left side
      
		wait ( 20 ) ; // Pause a bit before repeating While Loop

	}

}
