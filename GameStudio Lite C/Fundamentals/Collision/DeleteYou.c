// DeleteYou.c 
// Create an Entity, and Terminate it!

fps_max = 60 ; // Define the Frame Rate so game runs the same on different speed computers

	
action update_Earth() // Actions for earth.mdl
{
	wait(1) ; 
 
	while ( me ) // As long as I exist, continue to do this:
	{
		if ( key_space ) ent_remove ( me ) ; // If Spacebar is detected, I M toast
      
	wait (1) ; 
	}
}


void main()
{
	level_load("") ; // Load empty level 
	
	// Position the camera at x = -100, y = 0, z = 22 ( Back and Up a bit )
	camera.x = -100 ;  camera.z = 22 ; 
	
	// Create the Earth Model , Position XYZ, Action update_Earth
	ent_create( "earth.mdl", vector( 0, 10, 40 ), update_Earth ) ; 
}
