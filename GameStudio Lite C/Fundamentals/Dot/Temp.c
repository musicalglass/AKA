// DotMoveKeysDebug.c
// Make Dot move using Mouse
// Debug Panel displays Variables for Dot's X & Y coordinates

#include <acknex.h>
#include <default.c>

var Dot_Speed = 10 ;

mouse_pointer = 0; 
mouse_mode = 0;


PANEL* My_Dot = 
{
	bmap = "Dot.pcx" ;
	layer = 11 ;
	pos_x = 394 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	


PANEL* debugPanel =
{
  	digits( 0,0,3.3,*,1,mouse_cursor.x ); 
  	digits( 0,10,3.3,*,1,mouse_cursor.y ); 
  	digits( 0,20,3.3,*,1,My_Dot.pos_x ); 
  	digits( 0,30,3.3,*,1,My_Dot.pos_y );
}


function update_ball()
{
//	if ( key_cuu ) My_Dot.pos_y = My_Dot.pos_y - Dot_Speed * time_step ;
//   if ( key_cud ) My_Dot.pos_y = My_Dot.pos_y + Dot_Speed * time_step ;
//
//   if ( key_cul ) My_Dot.pos_x = My_Dot.pos_x - Dot_Speed * time_step ;
//   if ( key_cur ) My_Dot.pos_x = My_Dot.pos_x + Dot_Speed * time_step ;

//vec_set(    vector(My_Dot.pos_x,My_Dot.pos_y,0), vector(mouse_cursor.x,mouse_cursor.y,0));

My_Dot.pos_x = mouse_cursor.x ;
My_Dot.pos_y = mouse_cursor.y ;

}

function main()
{
//	 display debug panel
	debugPanel.pos_x = 10;
	debugPanel.pos_y = 200;
	debugPanel.flags |= VISIBLE;
	
   video_mode = 7 ; // Set Screen Resolution to 800 x 600
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Move Dot Using Arrow Keys" ) ;
	
   
	while ( 1 )
	{
//      if ( key_esc ) { Game_Running = 0 ; }
      
      vec_set(screen_color, vector( 55, 55, 55 )) ; // Clear Screen to Dark Grey

      update_ball() ; // Call the Function to update Dot Position
      
		wait (1) ;

	}
	
//	sys_exit(NULL) ;
}
