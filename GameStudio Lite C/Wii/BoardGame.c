// BoardGame.c

#include <acknex.h>
#include <default.c>
#include <ackwii.h>

var who_wii_R = NULL ; // wiimote_handle(var)
//var wii_R_On = NULL ; // wiimote_connected(var)
//var howMany_wii_R = NULL ; // wiimote_getdevices()

WIIMOTE buffer; // defines a new buffer named "buffer"

PANEL* panMoVars =
{
	digits( 50, 40, "Balance Board Weight in Kilos", Arial#28b, 1, 0 ) ; 
	
	digits( 50, 80, "STATUS.balanceboard = %0.f", Arial#18b, 1, buffer.status.balanceboard ) ; 

	digits( 50, 120, "Top Right = %0.f", Arial#18b, 1, buffer.board.topright ) ; 
	digits( 50, 140, "Bottom Right = %0.f", Arial#18b, 1, buffer.board.botright ) ; 
	digits( 50, 160, "Top Left = %0.f", Arial#18b, 1, buffer.board.topleft ) ; 
	digits( 50, 180, "Bottom Left = %0.f", Arial#18b, 1, buffer.board.botleft ) ; 
	digits( 50, 220, "Total weight = %0.f", Arial#18b, 1, buffer.board.weight  ) ; 

	red = 1 ; green = 1 ; blue = 1 ; // Change Text color to black
	flags = VISIBLE;
}


void reset_camera()
{
	camera.x = 0 ; 
	camera.y = 0 ; 
	camera.z = 0 ; 					
	camera.pan = 0 ; 
	camera.tilt =  0 ;	
}

action update_Earth()
{
	my.scale_x = .5 ; my.scale_y = .5 ; my.scale_z = .5 ; 
	
	while ( who_wii_R ) // While the Wiimote exists
	{
		// use balance board
		my.y = (( buffer.board.topleft + buffer.board.botleft ) / 1.2 )
		- (( buffer.board.topright + buffer.board.botright ) / 1.2 ) ;
		my.z = (( buffer.board.topright + buffer.board.topleft ) / 1.4 ) 
		- (( buffer.board.botright + buffer.board.botleft ) / 1.4 ) ;

		wait(1);
	}
}

void main()
{
	wait(1);
	
	//	video_mode = 8 ; 
	video_set( 1024, 768, 0, 0 ) ; 
	fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers 

	level_load( "" ) ; // Load empty Level
	wait(1);
	
	sky_color.red = 255 ; sky_color.green = 255 ; sky_color.blue = 255 ; 
	
	reset_camera() ; 
	
	who_wii_R = wiimote_handle(0) ; 
	
	
	ent_create( "earth.mdl", vector( 100, -30, 20 ), update_Earth ) ; // Create Earth Model
	
	you = ent_create( "alphaGrid.tga", vector( 34, -.01, -9.35 ), NULL ) ; // Create transparent grid floor
	your.scale_x = .049 ; your.scale_y = .049 ; // Scale to screen width
	your.tilt = 90 ; your.pan = 0 ; // Rotate to face Camera

	//	you = ent_create("gameCoords.tga", vector( 700,0,0), NULL); // Create background
	//	your.scale_x = 1.27 ; your.scale_y = 1.27 ; your.scale_z = 1.27 ; // Scale it up a bit to fit screen
	//	your.ambient = 100 ; // Self illuminated. Unaffected by shadows

	while( who_wii_R ) 
	{ 
		wiimote_status( who_wii_R, buffer ) ; // Copy all the Wiimote Variables to a Struct named "buffer" 
		
//		howMany_wii_R = wiimote_getdevices() ; // Return the number of Wiimotes online
//		wii_R_On = wiimote_connected( who_wii_R ) ; // Are Wii Connected? Query by Handle Name
		
		wait(1) ; 
	}
	
	wait(-1) ; // wait a bit
	
	if ( !buffer.status.balanceboard ) // If no board is detected
	{
		wait(-2) ; // wait a bit more...
			
		if ( !buffer.status.balanceboard ) // and check again
		{
			printf( "No Balance Board connected!" ) ; 
			//		sys_exit( "G'bye Y'all" ) ;
		}
	}
	
}
