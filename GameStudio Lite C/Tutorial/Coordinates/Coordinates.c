// Camera_Vars.c 
// Show Camera's Position Variables Onscreen

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

var pos_X = 30 ; // Global Variables for displaying 3D Position onscreen
var pos_Y = 20 ;
var pos_Z = -100 ;


PANEL* panDisplay =
{
	digits( 200, 20, "Traditional 3D Coordinate System", Arial#32b, 1, 0 ) ; 
	digits( 180, 60, "X = %0.f", Arial#28b, 1, pos_X ) ; 
	digits( 180, 82, "Y = %0.f", Arial#28b, 1, pos_Y ) ; 
	digits( 180, 102, "Z = %0.f", Arial#28b, 1, pos_Z ) ; 
	red = 1 ; green = 1 ; blue = 1 ; // Change Text color to black
	
	flags = VISIBLE;
}

void reset_camera()
{
	camera.x = 0 ; 
	camera.y = 0 ; 
	camera.z = 0 ; 					
	camera.pan = 90 ; 
	camera.tilt =  -90 ;	
}

action update_Earth()
{
	while (1)
	{
      if ( key_pgdn ) my.z += 2 * time_step ; // Page Up Key moves away from you
      if ( key_pgup ) my.z -= 2 * time_step ; // Page Down Key moves toward you
      
      if ( key_cuu ) my.y += 2 * time_step ; // Arrow Keys move Up, Down, Left & Right 
      if ( key_cud ) my.y -= 2 * time_step ; 
      if ( key_cur ) my.x += 2 * time_step ; 
      if ( key_cul ) my.x -= 2 * time_step ; 
      
	pos_Z = my.z ; pos_Y = my.y ; pos_X = my.x ;  // Write current Position to screen display variables
	wait(1);
	}
}

void main()
{
	// Load empty Level
	level_load("") ; 
	
	reset_camera() ; 
	
	you = ent_create("3D_coords.tga", vector(0,0,-700), NULL); // Create background
	your.tilt = 90 ; your.pan = -90 ; // Rotate to face Camera
	your.scale_x = 1.27 ; your.scale_y = 1.27 ; your.scale_z = 1.27 ; // Scale it up a bit to fit screen
	your.ambient = 100 ; // Self illuminated. Unaffected by shadows
	
	you = ent_create("alphaGrid.tga", vector( -.01,-9.35,-34 ), NULL) ; // Create transparent grid
	your.scale_x = .049 ; your.scale_y = .049 ; // Scale to screen width
	
	ent_create("earth.mdl", vector( pos_X, pos_Y, pos_Z ), update_Earth) ; // Create Earth Model
}
