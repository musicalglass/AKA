// BubblePop.c

#include <acknex.h>
#include <default.c>
#include <ackwii.h>

var enemiesBlasted = 0 ;
var goalEnemiesBlasted = 10 ; 
var numberOfEnemies = 0 ;
var maxNumEnemies = 1 ;

var elapsedTime = 0 ;

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

function munch_you() // this function runs when the bullet collides with something
{
		wait (1); // wait a frame to be sure (don't trigger engine warnings)
		ent_remove (you); // and then blow thine enemy to smithereens
		enemiesBlasted++ ;  // enter the victory in your battle journal
		numberOfEnemies-- ; // keep track of how many enemies there are
}

action update_Earth()
{
	var board_Y, board_Z = 0 ; 
	
	my.scale_x = .5 ; my.scale_y = .5 ; my.scale_z = .5 ; 
	
	c_setminmax(me) ; // Set the collision zone to the model's size
	my.emask |= ( ENABLE_ENTITY ) ; // Make Entity sensitive to collision
	my.event = munch_you ; // when it collides with something, its event function (munch_you) will run
	
	while ( who_wii_R ) // While the Wiimote exists
	{
		if (( buffer.board.topleft + buffer.board.botleft ) > ( buffer.board.topright + buffer.board.botright ))
		board_Y = (( buffer.board.topleft + buffer.board.botleft ) - 
		( buffer.board.topright + buffer.board.botright )) / ( buffer.board.weight / 2 ) ; 

		else if (( buffer.board.topleft + buffer.board.botleft ) < ( buffer.board.topright + buffer.board.botright ))
		board_Y = (( buffer.board.topleft + buffer.board.botleft ) 
		- ( buffer.board.topright + buffer.board.botright ) ) / ( buffer.board.weight / 2 ) ; 

		else board_Y = 0 ; 
		
		if (( buffer.board.topleft + buffer.board.topright ) > ( buffer.board.botleft + buffer.board.botright ))
		board_Z = (( buffer.board.topleft + buffer.board.topright ) 
		- ( buffer.board.botleft + buffer.board.botright )) / ( buffer.board.weight / 2 ) ; 

		else if (( buffer.board.topleft + buffer.board.topright ) < ( buffer.board.botleft + buffer.board.botright ))
		board_Z = (( buffer.board.topleft + buffer.board.topright ) 
		- ( buffer.board.botleft + buffer.board.botright ) ) / ( buffer.board.weight / 2 ) ; 

		else board_Z = 0 ; 
		
		// use balance board
//		c_move ( me, NULL, vector( 0, (( buffer.board.topleft + buffer.board.botleft ) / 4 )
//		- (( buffer.board.topright + buffer.board.botright ) / 4 ), (( buffer.board.topright + buffer.board.topleft ) / 4 ) 
//		- (( buffer.board.botright + buffer.board.botleft ) / 4 ) ), NULL ) ; 
		
		c_move ( me, vector( 0, board_Y, board_Z ), NULL, NULL ) ; 

//		my.y = (( buffer.board.topleft + buffer.board.botleft ) / 1.2 )
//		- (( buffer.board.topright + buffer.board.botright ) / 1.2 ) ;
//		my.z = (( buffer.board.topright + buffer.board.topleft ) / 1.4 ) 
//		- (( buffer.board.botright + buffer.board.botleft ) / 1.4 ) ;

		wait(1);
	}
}

void create_Enemy()
{
	if( numberOfEnemies != maxNumEnemies ) // As long as we haven't reached the Max num enemies ( 1 )
		elapsedTime++ ; // Increment elapsed time every click
		
		if ( elapsedTime >= 40 )	// Wait a bit before spawning new enemy
		{
			random_seed( 0 ); // Initialize the random number thingy
			// Create enemy in random Postion somewhere above our hero
			you = ent_create ( "Cube.mdl", vector ( 100, random(80)-40, random(60)-30 ), NULL ) ; 
			your.scale_x = .05 ; your.scale_y = .05 ; your.scale_z = .05 ; 
			c_setminmax( you ) ; // Wrap collision zone to models's size
			
			numberOfEnemies++ ; // Keep track of how many enemies thou must vanquish at one time
			elapsedTime = 0 ; // Reset the timer for next time
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
	
	
	ent_create( "earth.mdl", vector( 100, 0, 0 ), update_Earth ) ; // Create Earth Model
	
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

		create_Enemy() ;
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
