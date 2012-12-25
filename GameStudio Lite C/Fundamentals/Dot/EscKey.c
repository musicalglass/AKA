// EscKey.c
// Draw a Dot in the Center of the Screen

#include <acknex.h>

var Game_Running = 1 ;


PANEL* My_Dot = 
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
   
	wait ( 1 ) ;
	
	video_window( NULL, NULL, 0, "Draw a Dot" ) ;
	
   
	while ( Game_Running )
	{
      if ( key_esc ) { Game_Running = 0 ; }

	}
	
	sys_exit(NULL) ;
}
