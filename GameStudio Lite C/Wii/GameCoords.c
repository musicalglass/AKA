#include <acknex.h>
#include <default.c>
#include <ackwii.h>

// Camera_Vars.c 
// Show Camera's Position Variables Onscreen

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

var pos_X = 100 ; // Global Variables for displaying 3D Position onscreen
var pos_Y = -30 ;
var pos_Z = 20 ;


WIIMOTE buffer; // defines a new buffer

var wii_handle = 0 ; // wiimote_handle(var)

var wii_R_On = 0 ; // wiimote_connected(var)
var howManyR_Wii = 0 ; // wiimote_getdevices()


//		buffer.buttons.butA ; 
//		buffer.buttons.butB ; 
//		buffer.buttons.butX ; 
//		buffer.buttons.butY ; 
//		buffer.buttons.butC ; 
//		buffer.buttons.butZ ; 
//		buffer.buttons.but1 ; 
//		buffer.buttons.but2 ; 
//		buffer.buttons.butL ; 
//		buffer.buttons.butR ; 
//		buffer.buttons.butZL ; 
//		buffer.buttons.butZR ; 
//		buffer.buttons.butPlus ; 
//		buffer.buttons.butMinus ; 
//		buffer.buttons.butHome ; 
//		buffer.buttons.butGreen ; 
//		buffer.buttons.butRed ; 
//		buffer.buttons.butYellow ; 
//		buffer.buttons.butBlue ; 
//		buffer.buttons.butOrange ; 
//		buffer.buttons.butAny;

PANEL* panButtons =
{
	digits( 60, 10, "Wii Buttons", Arial#28b, 1, 0 ) ; 
	
	digits( 60, 40, "WiiMote Handle = %0.f", Arial#18b, 1, wii_handle ) ; 
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
	digits( 60, 400, "Green button = %0.f", Arial#18b, 1, buffer.buttons.butGreen ) ; 
	digits( 60, 420, "Red button = %0.f", Arial#18b, 1, buffer.buttons.butRed ) ; 
	digits( 60, 440, "Yellow button = %0.f", Arial#18b, 1, buffer.buttons.butYellow ) ; 
	digits( 60, 460, "Orange button = %0.f", Arial#18b, 1, buffer.buttons.butOrange ) ; 
	digits( 60, 480, "Any button = %0.f", Arial#18b, 1, buffer.buttons.butAny ) ; 
	
	red = 1 ; green = 1 ; blue = 1 ; // Change Text color to black
	flags = VISIBLE;
}

//		buffer.STICK.joy_x ; 
//		buffer.STICK.joy_y ; 

//		buffer.IR.ir_x ; 
//		buffer.IR.ir_y ; 
//		buffer.IR.size ; 
		
//		buffer.IRPTR.ir_x ; 
//		buffer.IRPTR.ir_y ; 
		
//		buffer.SHOULDER.l ; 
//		buffer.SHOULDER.r ; 
		
//		buffer.BOARD.topright ; 
//		buffer.BOARD.botright ; 
//		buffer.BOARD.topleft ;   
//		buffer.BOARD.botleft ; 
//		buffer.BOARD.weight ; 

//		buffer.DPAD.up ; 
//		buffer.DPAD.down ; 
//		buffer.DPAD.left ; 
//		buffer.DPAD.right ; 

//		buffer.STATUS.ir ; 
//		buffer.STATUS.nunchuk ; 
//		buffer.STATUS.classic ; 
//		buffer.STATUS.guitar ; 
//		buffer.STATUS.balanceboard ; 
//		buffer.STATUS.battery ; 
//		buffer.STATUS.batteryraw ; 
//		buffer.STATUS.vibration ; 
//		buffer.STATUS.index ; 


//		buffer.WIIMOTE.angle1 ; // estimated orientation of Wiimote (can be inaccurate)  range: -180° to +180°
//		buffer.WIIMOTE.angle2 ; // estimated orientation of Nunchuk (can be inaccurate)  range: -180° to +180°
//		buffer.WIIMOTE.accel1 ; // acceleration of Wiimote
//		buffer.WIIMOTE.accel2 ; // acceleration of Nunchuk
//		buffer.WIIMOTE.stick1 ; // either Nunchuk or Guitar analog stick or Classic Controller left analog stick
//		buffer.WIIMOTE.stick2 ; // classic controller right analog stick
//		buffer.WIIMOTE.board ; // balance board data
//		buffer.WIIMOTE.ir[4] ; // IR sensor data (up to 4 IR dots can be detected)
//		buffer.WIIMOTE.pointer ; // IR pointer data
//		buffer.WIIMOTE.shoulder ; // shoulder button data of classic controller, whammy bar (left shoulder) of guitar
										 // button data of Wiimote and expansion device. Classic Controller, Guitar and 
//		buffer.WIIMOTE.buttons ; // Balance Board buttons are mapped to Wiimote buttons with the same caption
//		buffer.WIIMOTE.dpad ; // directional pad data of either Wiimote, Classic Controller or Guitar
//		buffer.WIIMOTE.status ; // status variables and flags of Wiimote/expansion device
//		buffer.WIIMOTE.event ; // on_xxx events for assigning functions to Wiimote/expansion device buttons


PANEL* panMoVars =
{
	digits( 300, 10, "More Wii Vars", Arial#28b, 1, 0 ) ; 
	
	digits( 300, 40, "Joy X = %0.f", Arial#18b, 1, buffer.stick1.joy_x ) ; 
	digits( 300, 60, "Joy Y = %0.f", Arial#18b, 1, buffer.stick1.joy_y ) ; 
//	digits( 300, 80, "IR X = %0.f", Arial#18b, 1, buffer.IR.ir_x ) ; 
//	digits( 300, 100, "IR Y = %0.f", Arial#18b, 1, buffer.IR.ir_y ) ; 
//	digits( 300, 120, "IR Size = %0.f", Arial#18b, 1, buffer.IR.ir_size ) ; 
//	digits( 300, 140, "IRPTR X = %0.f", Arial#18b, 1, buffer.IRPTR.ir_x ) ; 
//	digits( 300, 160, "IRPTR Y = %0.f", Arial#18b, 1, buffer.IRPTR.ir_y ) ; 
//	digits( 300, 180, "SHOULDER L = %0.f", Arial#18b, 1, buffer.SHOULDER.l ) ; 300
//	digits( 300, 200, "SHOULDER R = %0.f", Arial#18b, 1, buffer.SHOULDER.r ) ; 
//	digits( 300, 220, "BOARD topright = %0.f", Arial#18b, 1, buffer.BOARD.topright ) ; 
//	digits( 300, 240, "BOARD botright = %0.f", Arial#18b, 1, buffer.BOARD.botright ) ; 
//	digits( 300, 260, "BOARD topleft = %0.f", Arial#18b, 1, buffer.BOARD.topleft ) ; 
//	digits( 300, 280, "BOARD botleft = %0.f", Arial#18b, 1, buffer.BOARD.botleft ) ; 
//	digits( 300, 300, "BOARD weight = %0.f", Arial#18b, 1, buffer.BOARD.weight  ) ; 
//	digits( 300, 320, "DPAD Up = %0.f", Arial#18b, 1, buffer.DPAD.up ) ; 
//	digits( 300, 340, "DPAD Down = %0.f", Arial#18b, 1, buffer.DPAD.down ) ; 
//	digits( 300, 360, "DPAD Left = %0.f", Arial#18b, 1, buffer.DPAD.left ) ; 
//	digits( 300, 380, "DPAD Right = %0.f", Arial#18b, 1, buffer.DPAD.right ) ; 
//	digits( 300, 400, "STATUS.ir = %0.f", Arial#18b, 1, buffer.STATUS.ir ) ; 
//	digits( 300, 420, "STATUS.nunchuk = %0.f", Arial#18b, 1, buffer.STATUS.nunchuk ) ; 
//	digits( 300, 440, "STATUS.classic = %0.f", Arial#18b, 1, buffer.STATUS.classic ) ; 
//	digits( 300, 460, "STATUS.balanceboard = %0.f", Arial#18b, 1, buffer.STATUS.balanceboard ) ; 
//	digits( 300, 480, "STATUS.guitar = %0.f", Arial#18b, 1, buffer.STATUS.guitarguitar ) ; 
//	digits( 300, 500, "STATUS.battery = %0.f", Arial#18b, 1, buffer.STATUS.battery ) ; 
//	digits( 300, 520, "STATUS.batteryraw = %0.f", Arial#18b, 1, buffer.STATUS.batteryraw ) ; 
//	digits( 300, 540, "STATUS.vibration = %0.f", Arial#18b, 1, buffer.STATUS.vibration ) ; 
//	digits( 300, 560, "STATUS.index = %0.f", Arial#18b, 1, buffer.STATUS.index ) ; 
	
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
	while (wii_handle)
	{
		my.y = -buffer.stick1.joy_x / 4 ; 
		my.z = buffer.stick1.joy_y / 5 ; 
//		if ( key_pgdn ) my.x -= 2 * time_step ; // Page Up Key moves away from you
//		if ( key_pgup ) my.x += 2 * time_step ; // Page Down Key moves toward you
//		
//		if ( key_cud ) my.z -= 2 * time_step ; // Arrow Keys move Up, Down, Left & Right 
//		if ( key_cuu ) my.z += 2 * time_step ; 
//		if ( key_cur ) my.y -= 2 * time_step ; 
//		if ( key_cul ) my.y += 2 * time_step ; 
		
		pos_Z = my.z ; pos_Y = my.y ; pos_X = my.x ;  // Write current Position to screen display variables
		wait(1);
	}
}

void main()
{
	video_mode = 8 ; 

	level_load( "" ) ; // Load empty Level
	wait(1);
	
	sky_color.red = 255 ; 
	sky_color.green = 255 ; 
	sky_color.blue = 255 ; 
	
	reset_camera() ; 

	wii_handle = wiimote_handle(0) ; 
	wait(2);
	
	if (!wii_handle) printf("No WiiMote connected!") ; 
	
	
//	you = ent_create("gameCoords.tga", vector( 700,0,0), NULL); // Create background
//	your.scale_x = 1.27 ; your.scale_y = 1.27 ; your.scale_z = 1.27 ; // Scale it up a bit to fit screen
//	your.ambient = 100 ; // Self illuminated. Unaffected by shadows
	
	you = ent_create("alphaGrid.tga", vector( 34,-.01,-9.35 ), NULL) ; // Create transparent grid
	your.scale_x = .049 ; your.scale_y = .049 ; // Scale to screen width
	your.tilt = 90 ; your.pan = 0 ; // Rotate to face Camera
	
	ent_create("earth.mdl", vector( pos_X, pos_Y, pos_Z ), update_Earth) ; // Create Earth Model


	while( wii_handle ) 
	{ 
		wait(1);
		wiimote_status( wii_handle, buffer ) ; // Copy all the Wiimote Variables to a Struct named "buffer" 
		
		howManyR_Wii = wiimote_getdevices() ; // Return the number of Wiimotes online
	
		wii_R_On = wiimote_connected( wii_handle ) ; // Are Wii Connected? Query by Handle Name
	
	}
}
