// DotRandom.c
// Move Dot randomly about the screen

#include <acknex.h>
#include <default.c>

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
   video_mode = 7 ; 
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Random Dots" ) ; 
	
   
	while ( 1 ) 
	{
      //vec_set(screen_color, vector( 55, 55, 55 )) ; 

      My_Dot.pos_x = rand()%785  ; // Update Dot Position to a Random Number between 0 and 785
      My_Dot.pos_y = rand()%585  ; 
      
		wait ( 200 ) ; // Pause a bit before repeating While Loop

	}

}

