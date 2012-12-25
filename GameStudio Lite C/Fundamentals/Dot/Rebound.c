// Rebound.c
// Make Dot reverse direction when it reaches the edge of screen

#include <acknex.h>
#include <default.c>

var Move_Right = 1 ;


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
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Rebound Screen" ) ; 
	
	
	while ( 1 ) 
	{
      vec_set(screen_color, vector( 55, 55, 55 )) ; 
      
         if ( My_Dot.pos_x > 800 ) { Move_Right = 0 ; } // If Dot goes past the right side of screen, set X Direction negative
      	if ( My_Dot.pos_x < 0 ) { Move_Right = 1 ; }  // If Dot goes past the left side of screen, set X Direction to positive


      if ( Move_Right )
      {
      	My_Dot.pos_x = My_Dot.pos_x + 20 ;  // Update Dot Position Right
      }
        else { My_Dot.pos_x = My_Dot.pos_x - 20 ; } // Update Dot Position Left


     wait ( 20 ) ; // Pause a bit before repeating While Loop
   }

}
