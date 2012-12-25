// DotMoveKeysFunction.c
// Use a Function to Update Dot Position

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


function update_dot()
{
		if ( key_cuu ) my_dot.pos_y-- ; 
      if ( key_cud ) my_dot.pos_y++ ; 

      if ( key_cul ) my_dot.pos_x-- ; 
      if ( key_cur ) my_dot.pos_x++ ; 
}

function main()
{
	
   video_mode = 7 ;
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Move Dot Using Arrow Keys" ) ;
	
   
	while ( 1 )
	{
      vec_set( screen_color, vector( 55, 55, 55 ) ) ;

      update_dot() ; // Call the Function to update Dot Position
      
		wait ( 1 ) ;

	}
	
}
