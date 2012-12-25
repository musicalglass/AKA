// CollideDestroy.c 
// Detect when an Entity bumps into another one, and Terminate it!

fps_max = 60 ; // Define the Frame Rate so game runs the same on different speed computers


void collide_event() // This event is called when Entity bumps into something
{
   ent_remove ( you ) ; 
}
	
	action update_Earth() // Actions for earth.mdl
{
	c_setminmax( me ) ; // Wrap Collision Zone to Model's size

	my.emask |= ( ENABLE_ENTITY ) ; // make entity sensitive for block and entity collision
  	my.event = collide_event ; // Define which event will be triggered
  	
  	my.scale_x = .5 ; my.scale_y = .5 ; my.scale_z = .5 ; // Scale it down to bullet size
 
	while (1) // While game is running, continue to do this:
	{
		// If Up Arrow Key is pressed, subtract 2 from the Z Position, and check for collision
		if ( key_cuu ) c_move( me, vector(0,0,0), vector(0,0,2 * time_step), NULL ) ; 
		// If Down Arrow Key is pressed, add 2 to the Z Position, and check for collision
      if ( key_cud ) c_move( me, vector(0,0,0), vector(0,0,-2 * time_step), NULL ) ; 
      // If Left Arrow Key is pressed, subtract 2 from the Y Position, and check for collision
      if ( key_cul ) c_move( me, vector(0,0,0), vector(0,2 * time_step,0), NULL ) ; 
      // If Right Arrow Key is pressed, add 2 to the Y Position, and check for collision
      if ( key_cur ) c_move( me, vector(0,0,0), vector(0,-2 * time_step,0), NULL ) ; 
      
	wait (1) ; 
	}
}


void main()
{
	level_load("") ; // Load empty level 
	
	// Position the camera at x = -100 ( Back  a bit )
	camera.x = -100 ; 
	
	// Create the Earth Model , Position XYZ, Action update_Earth
	ent_create( "earth.mdl", vector( 0, 50, 35 ), update_Earth ) ; 
	
	int i = 0 ;
	for ( i = 45; i >= -45; i = i - 15 ) 
	{
		wait ( 100 ) ;
		ent_create( "cube.mdl", vector(0,i,0), c_setminmax ) ; 
	}

}
