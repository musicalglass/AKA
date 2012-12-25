// Dot.c
// Draw a Dot in the Center of the Screen

#include <acknex.h>
#include <default.c>

PANEL* My_Dot = 
{
	bmap = "Dot.pcx" ;
	pos_x = 394 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	

function main()
{
   video_mode = 7 ; // Set Screen Resolution to 800 X 600
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Draw a Dot" ) ;

}
