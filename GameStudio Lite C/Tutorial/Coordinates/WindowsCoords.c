// Coordinates.c
// Show 2D X & Y Coordinate for Windows Programming

#include <acknex.h>
#include <default.c>

var mouse_x = 0 ; 
var mouse_y = 0 ; 

PANEL* backgroundPanel = 
{
	bmap = "windows_coords.tga" ;
	layer = 1 ;

	flags = VISIBLE ;
}	


PANEL* textPanel = // Text Panel to display Mouse Position Variables to the screen
{
	layer = 2 ; 
	digits( 190, 130, "Microsoft Windows", Arial#30b, 1, 0 ) ; 
	digits( 180, 160, "2D Coordinate System", Arial#30b, 1, 0 ) ; 
	
  	digits( 260, 200, "X = %0.f", Arial#28b, 1, mouse_x ) ; 
	digits( 260, 230, "Y = %0.f", Arial#28b, 1, mouse_y ) ; 
	red = 1 ; green = 1 ; blue = 1 ; // Change Text color to black

  	flags = VISIBLE ;
}


function main()
{
   video_mode = 6 ; // Set Screen size to 640 X 480
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Microsoft Windows Coordinate System" ) ;
	
	while(1)
	{
		mouse_x = mouse_cursor.x ; 
		mouse_y = mouse_cursor.y ; 
		
		if ( mouse_x > 640 ) mouse_x = 640 ; 
		if ( mouse_x < 0 ) mouse_x = 0 ; 
		
		if ( mouse_y > 480 ) mouse_y = 480 ; 
		if ( mouse_y < 0 ) mouse_y = 0 ; 
		
		wait (1) ;
	}
}
