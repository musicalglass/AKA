// Infrared.c 
// Show Wiimote Variables onscreen

#include <acknex.h>
#include <default.c>
#include <ackwii.h>

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

var earth_X = 100 ; // Global Variables for displaying 3D Position onscreen
var earth_Y = -30 ;
var earth_Z = 20 ;

var infrared_X = NULL ; 
var infrared_Y = NULL ; 
var infrared_Size = NULL ; 

WIIMOTE buffer; // defines a new buffer

var who_wii_R = 0 ; // wiimote_handle(var)

var wii_R_On = 0 ; // wiimote_connected(var)
var howManyR_Wii = 0 ; // wiimote_getdevices()


PANEL* panButtons =
{
	digits( 60, 10, "Wii Buttons", Arial#28b, 1, 0 ) ; 
	
	digits( 60, 40, "WiiMote Handle = %0.f", Arial#18b, 1, who_wii_R ) ; 
	digits( 60, 60, "WiiMote Connected? = %0.f", Arial#18b, 1, wii_R_On ) ; 
	digits( 60, 80, "# of Wiis Online = %0.f", Arial#18b, 1, howManyR_Wii ) ; 
	digits( 60, 100, "A button = %0.f", Arial#18b, 1, buffer.buttons.butA ) ; 
	digits( 60, 120, "B button = %0.f", Arial#18b, 1, buffer.buttons.butB ) ; 
	digits( 60, 140, "X button = %0.f", Arial#18b, 1, buffer.buttons.butX ) ; 
	digits( 60, 160, "Y button = %0.f", Arial#18b, 1, buffer.buttons.butY ) ; 
	digits( 60, 180, "C button = %0.f", Arial#18b, 1, buffer.buttons.butC ) ; 
	digits( 60, 200, "Z button = %0.f", Arial#18b, 1, buffer.buttons.butZ ) ; 
	digits( 60, 220, "1 button = %0.f", Arial#18b, 1, buffer.buttons.but1 ) ; 
	digits( 60, 240, "2 button = %0.f", Arial#18b, 1, buffer.buttons.but2 ) ; 
	digits( 60, 260, "L button = %0.f", Arial#18b, 1, buffer.buttons.butL ) ; 
	digits( 60, 280, "R button = %0.f", Arial#18b, 1, buffer.buttons.butR ) ; 
	digits( 60, 300, "ZL button = %0.f", Arial#18b, 1, buffer.buttons.butZL ) ; 
	digits( 60, 320, "ZR button = %0.f", Arial#18b, 1, buffer.buttons.butZR ) ; 
	digits( 60, 340, "Plus button = %0.f", Arial#18b, 1, buffer.buttons.butPlus ) ; 
	digits( 60, 360, "Minus button = %0.f", Arial#18b, 1, buffer.buttons.butMinus ) ; 
	digits( 60, 380, "Home button = %0.f", Arial#18b, 1, buffer.buttons.butHome ) ; 
//	digits( 60, 400, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
	digits( 60, 420, "Any button = %0.f", Arial#18b, 1, buffer.buttons.butAny ) ; 
//	digits( 60, 440, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 60, 460, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 60, 480, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
	
	red = 1 ; green = 1 ; blue = 1 ; // Change Text color to black
	flags = VISIBLE;
}

//		buffer.angle1 ; // estimated orientation of Wiimote (can be inaccurate)  range: -180° to +180°
//		buffer.angle2 ; // estimated orientation of Nunchuk (can be inaccurate)  range: -180° to +180°
//		buffer.accel1 ; // acceleration of Wiimote
//		buffer.accel2 ; // acceleration of Nunchuk
//		buffer.stick1 ; // either Nunchuk or Guitar analog stick or Classic Controller left analog stick
//		buffer.stick2 ; // classic controller right analog stick
//		buffer.board ; // balance board data
//		buffer.ir[4] ; // IR sensor data (up to 4 IR dots can be detected)
//		buffer.pointer ; // IR pointer data
//		buffer.shoulder ; // shoulder button data of classic controller, whammy bar (left shoulder) of guitar
										// button data of Wiimote and expansion device. Classic Controller, Guitar and 
//		buffer.buttons ; // Balance Board buttons are mapped to Wiimote buttons with the same caption
//		buffer.dpad ; // directional pad data of either Wiimote, Classic Controller or Guitar
//		buffer.status ; // status variables and flags of Wiimote/expansion device
//		buffer.event ; // on_xxx events for assigning functions to Wiimote/expansion device buttons

PANEL* panMoVars =
{
	digits( 300, 10, "More Wii Vars", Arial#28b, 1, 0 ) ; 
	
	digits( 300, 40, "Joy X = %0.f", Arial#18b, 1, buffer.stick1.joy_x ) ; 
	digits( 300, 60, "Joy Y = %0.f", Arial#18b, 1, buffer.stick1.joy_y ) ; 
	
	digits( 300, 80, "IR X = %0.f", Arial#18b, 1, infrared_X ) ; 
	digits( 300, 100, "IR Y = %0.f", Arial#18b, 1, infrared_Y ) ; 
	digits( 300, 120, "IR Size = %0.f", Arial#18b, 1, infrared_Size ) ; 
	
	digits( 300, 140, "IRPTR X = %0.f", Arial#18b, 1, buffer.pointer.ir_x ) ; 
	digits( 300, 160, "IRPTR Y = %0.f", Arial#18b, 1, buffer.pointer.ir_y ) ; 
	
	
	digits( 300, 180, "my.x = %0.f", Arial#18b, 1, earth_X ) ; 
	digits( 300, 200, "my.y  = %0.f", Arial#18b, 1, earth_Y ) ; 
	digits( 300, 220, "my.z = %0.f", Arial#18b, 1, earth_Z ) ; 
	
	digits( 300, 240, "BOARD topright = %0.f", Arial#18b, 1, buffer.board.topright ) ; 
	digits( 300, 260, "BOARD botright = %0.f", Arial#18b, 1, buffer.board.botright ) ; 
	digits( 300, 280, "BOARD topleft = %0.f", Arial#18b, 1, buffer.board.topleft ) ; 
	digits( 300, 300, "BOARD botleft = %0.f", Arial#18b, 1, buffer.board.botleft ) ; 
	digits( 300, 320, "BOARD weight = %0.f", Arial#18b, 1, buffer.board.weight  ) ; 

	digits( 300, 340, "DPAD Up = %0.f", Arial#18b, 1, buffer.dpad.up ) ; 
	digits( 300, 360, "DPAD Down = %0.f", Arial#18b, 1, buffer.dpad.down ) ; 
	digits( 300, 380, "DPAD Left = %0.f", Arial#18b, 1, buffer.dpad.left ) ; 
	digits( 300, 400, "DPAD Right = %0.f", Arial#18b, 1, buffer.dpad.right ) ; 
	
	digits( 300, 420, "STATUS.ir = %0.f", Arial#18b, 1, buffer.status.ir ) ; 
	digits( 300, 440, "STATUS.nunchuk = %0.f", Arial#18b, 1, buffer.status.nunchuk ) ; 
//	digits( 300, 460, "STATUS.classic = %0.f", Arial#18b, 1, buffer.status.classic ) ; 
	digits( 300, 480, "STATUS.balanceboard = %0.f", Arial#18b, 1, buffer.status.balanceboard ) ; 
	digits( 300, 500, "STATUS.guitar = %0.f", Arial#18b, 1, buffer.status.guitar ) ; 
	digits( 300, 520, "STATUS.battery = %0.f", Arial#18b, 1, buffer.status.battery ) ; 
	digits( 300, 540, "STATUS.batteryraw = %0.f", Arial#18b, 1, buffer.status.batteryraw ) ; 
	digits( 300, 560, "STATUS.index = %0.f", Arial#18b, 1, buffer.status.index ) ; 
//	digits( 300, 600, "Press Spacebar for Vibration", Arial#18b, 1, 0 ) ; 
//	digits( 300, 620, "STATUS.vibration = %0.f", Arial#18b, 1, buffer.status.vibration ) ; 
	
	red = 1 ; green = 1 ; blue = 1 ; // Change Text color to black
	flags = VISIBLE;
}

PANEL* panEvenMo =
{
	digits( 500, 10, "Even More", Arial#28b, 1, 0 ) ; 

	digits( 500, 40, "WiiStick Accel X = %0.f", Arial#18b, 1, buffer.accel1.x ) ; 
	digits( 500, 60, "WiiStick Accel Y = %0.f", Arial#18b, 1, buffer.accel1.y ) ; 
	digits( 500, 80, "WiiStick Accel Z = %0.f", Arial#18b, 1, buffer.accel1.z ) ; 

	digits( 500, 100, "Nunchuck Accel X = %0.f", Arial#18b, 1, buffer.accel2.x ) ; 
	digits( 500, 120, "Nunchuck Accel Y = %0.f", Arial#18b, 1, buffer.accel2.y ) ; 
	digits( 500, 140, "Nunchuck Accel Z = %0.f", Arial#18b, 1, buffer.accel2.z ) ; 

	digits( 500, 160, "WiiStick Angle Tilt = %0.f", Arial#18b, 1, buffer.angle1.tilt ) ; 
	digits( 500, 180, "WiiStick Angle Roll = %0.f", Arial#18b, 1, buffer.angle1.roll ) ; 
	
	digits( 500, 200, "Nunchuck Angle Tilt = %0.f", Arial#18b, 1, buffer.angle2.tilt ) ; 
	digits( 500, 220, "Nunchuck Angle Roll = %0.f", Arial#18b, 1, buffer.angle2.roll ) ; 
	
	digits( 500, 240, "buffer.ir[0] = %0.f", Arial#18b, 1, buffer.ir[0] ) ; 
	digits( 500, 260, "buffer.ir[1] = %0.f", Arial#18b, 1, buffer.ir[1] ) ; 
	digits( 500, 280, "buffer.ir[2] = %0.f", Arial#18b, 1, buffer.ir[2] ) ; 
	digits( 500, 300, "buffer.ir[3] = %0.f", Arial#18b, 1, buffer.ir[3] ) ; 
	
//	digits( 500, 320, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 500, 340, "STATUS.classic = %0.f", Arial#18b, 1, buffer.status.classic ) ; 
//	digits( 500, 360, "Green button = %0.f", Arial#18b, 1, buffer.buttons.butGreen ) ; 
//	digits( 500, 380, "Red button = %0.f", Arial#18b, 1, buffer.buttons.butRed ) ; 
//	digits( 500, 400, "Yellow button = %0.f", Arial#18b, 1, buffer.buttons.butYellow ) ; 

//	digits( 500, 420, "Orange button = %0.f", Arial#18b, 1, buffer.buttons.butOrange ) ; 
//	digits( 500, 440, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 500, 460, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 500, 480, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 500, 500, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 500, 520, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 500, 540, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
//	digits( 500, 560, "NULL = %0.f", Arial#18b, 1, NULL ) ; 
	
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
	
	while ( who_wii_R ) 
	{

		infrared_X = buffer.ir[0].ir_x ; infrared_Y = buffer.ir[0].ir_y ; 
//		infrared_Size = buffer.ir[0].ir_size ; 
		
		my.y = -( buffer.pointer.ir_x - 512 ) / 5 ; 
		my.z = -( buffer.pointer.ir_y - 384 ) / 5 ; 

		earth_X = my.x ; earth_Y = my.y ; earth_Z = my.z ; // Write current Position to screen display variables
		wait(1);
	}
}

void main()
{
	video_mode = 8 ; 

	level_load( "" ) ; // Load empty Level
	wait(1);
	
	sky_color.red = 255 ; sky_color.green = 255 ; sky_color.blue = 255 ; 
	
	reset_camera() ; 

	who_wii_R = wiimote_handle(0) ; 
	wait(2);
	
	if ( !who_wii_R ) 
	{
		printf( "No WiiMote connected!" ) ; 
		sys_exit( "G'bye Y'all" ) ;
	}
	else
	{
		wiimote_ir( who_wii_R, 1 ) ; // Turn on the IR

		you = ent_create ( "alphaGrid.tga", vector( 34,-.01,-9.35 ), NULL ) ; // Create transparent grid
		your.scale_x = .049 ; your.scale_y = .049 ; // Scale to screen width
		your.tilt = 90 ; your.pan = 0 ; // Rotate to face Camera
		
		ent_create("earth.mdl", vector( earth_X, earth_Y, earth_Z ), update_Earth) ; // Create Earth Model


		while( who_wii_R ) 
		{ 
			wait(1);
			wiimote_status( who_wii_R, buffer ) ; // Copy all the Wiimote Variables to a Struct named "buffer" 
			
			howManyR_Wii = wiimote_getdevices() ; // Return the number of Wiimotes online
			
			wii_R_On = wiimote_connected( who_wii_R ) ; // Are Wii Connected? Query by Handle Name
			
			if ( key_space ) 	wiimote_vibration( who_wii_R, 1 ) ; // Turns the vibration on (1) or off (0). 
			else 	wiimote_vibration( who_wii_R, 0 ) ;

		}
	}
	
	
}
