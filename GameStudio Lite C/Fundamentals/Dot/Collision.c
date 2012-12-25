// Collision.c
// Detect when Dot is inside boundaries of square

#include <acknex.h>
#include <default.c>

//mouse_pointer = 0; 
//mouse_mode = 0;

STRING* detect_top = "Lower than top = false" ;
STRING* detect_bottom = "Higher than bottom = false" ;
STRING* detect_right = "Lower than right side = false" ;
STRING* detect_left = "Higher than left side = false" ;
STRING* collision_detect = "Collision detected = false" ;

PANEL* Collision_Panel = // Show paddle's position
{
	layer = 3;
  	digits( 50,50,3,Arial#24,1,detect_top ) ; 
  	digits( 50,70,3,Arial#24,1,detect_bottom ) ; 
  	digits( 50,90,3,Arial#24,1,detect_right ) ; 
  	digits( 50,110,3,Arial#24,1,detect_left ) ; 

  	digits( 50,140,3,Arial#24,1,collision_detect ) ; 
  	
  	flags = VISIBLE ;
}

PANEL* My_Dot = 
{
	bmap = "Dot.pcx" ;
	layer = 2 ;
	pos_x = 50 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	

PANEL* My_Box = 
{
	bmap = "Box.pcx" ;
	layer = 2 ;
	pos_x = 350 ;
	pos_y = 300 ;
	flags = VISIBLE ;
}	


function main()
{
   video_mode = 7 ; // Screen Resolution 800 X 600
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Move Dot Using Mouse" ) ;
	
   
	while ( 1 )
	{
      vec_set(screen_color, vector( 55, 55, 55 )) ; 

      My_Dot.pos_x = mouse_cursor.x  ; // Update Dot Position
      My_Dot.pos_y = mouse_cursor.y  ;
      
      if ( My_Dot.pos_x < My_Box.pos_x ) { detect_right = "Lower than right side = true" ; }
//      else { detect_right = "Lower than right side = false" ; } 
         
		wait ( 1 ) ; 

	}
}
