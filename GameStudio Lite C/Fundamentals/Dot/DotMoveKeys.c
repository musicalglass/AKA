// DotMoveKeys.c
// Make Dot move using Arrow Keys

#include <acknex.h>
#include <default.c>


PANEL* my_dot = 
{
	bmap = "Dot.pcx" ;
	layer = 11 ;
	pos_x = 394 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	


function main()
{
   video_mode = 7 ;
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Move Dot Using Arrow Keys" ) ;
	
   
	while ( 1 )
	{
      
      vec_set(screen_color, vector( 55, 55, 55 )) ;
      
      if ( key_cuu ) my_dot.pos_y = my_dot.pos_y - 2 ; // If Up Arrow Key is pressed, subtract 2 from the Y Position
      if ( key_cud ) my_dot.pos_y = my_dot.pos_y + 2 ; // If Down Arrow Key is pressed, add 2 to the Y Position

      if ( key_cul ) my_dot.pos_x = my_dot.pos_x - 2 ; // If Left Arrow Key is pressed, subtract 2 from the X Position
      if ( key_cur ) my_dot.pos_x = my_dot.pos_x + 2 ; // If Right Arrow Key is pressed, add 2 to the X Position
      
		wait (1) ;

	}
	
}
