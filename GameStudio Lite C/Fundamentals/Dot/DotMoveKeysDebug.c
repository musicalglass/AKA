// DotMoveKeysDebug.c
// Make Dot move using Arrow Keys
// Debug Panel displays Variables for Dot's X & Y coordinates

#include <acknex.h>
#include <default.c>


PANEL* dot = 
{
	bmap = "Dot.pcx" ;
	layer = 2 ;
	pos_x = 394 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	


PANEL* debugPanel = // Create a Text Panel to display Variables to the screen
{
	layer = 3;
  	digits( 10,10,3.3,*,1,dot.pos_x ); 
  	digits( 10,20,3.3,*,1,dot.pos_y ); 
  	flags = VISIBLE ;
}


function update_dot_position()
{
	if ( key_cuu ) dot.pos_y-- ;
   if ( key_cud ) dot.pos_y++ ;

   if ( key_cul ) dot.pos_x-- ;
   if ( key_cur ) dot.pos_x++ ;
}

function main()
{
	//	 display debug panel
//	debugPanel.pos_x = 10 ; 
//	debugPanel.pos_y = 10 ; 
//	debugPanel.flags |= VISIBLE ; 
	
   video_mode = 7 ; 
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Move Dot Using Arrow Keys" ) ;
	
   
	while ( 1 )
	{
      
      vec_set( screen_color, vector( 55, 55, 55 ) ) ; 

      update_dot_position() ; 
      
		wait (1) ;

	}
	
}
