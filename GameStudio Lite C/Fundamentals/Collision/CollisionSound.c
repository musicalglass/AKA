// CollisionSound.c 
// Play a Sound when an Entity bumps into another one

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

// Define initial Color settings for Cube Entity
MATERIAL* purpleMat=
	{
	ambient_red = 50;
	ambient_green = 0 ;
	ambient_blue = 50 ;
	diffuse_red = 100 ;
	diffuse_green = 0 ;
	diffuse_blue = 100 ;
	specular_red = 0 ;
	specular_green = 0 ;
	specular_blue = 0 ;
	emissive_red = 0;
	emissive_green = 0 ;
	emissive_blue = 0;
	power =50;
}

SOUND* ouch = "ouch.wav";

void collide_event() // This event is called when Entity bumps into something
{
   purpleMat.ambient_red = 80 ; // Change some color values in the Entity's Material
	purpleMat.ambient_blue = 0 ; 
	snd_play( ouch,50,0 ) ; 
}
	
	action update_Earth() // Actions for earth.mdl
{
	wait(1) ; 
	c_setminmax( me ) ; // Wrap Collision Zone to Model's size

	my.emask |= ( ENABLE_ENTITY ) ; // make entity sensitive for block and entity collision
  	my.event = collide_event ; // Define which event will be triggered
 
	while (1) // While game is running, continue to do this:
	{
		purpleMat.ambient_red = 50 ; // Set the color back to normal while not colliding
		purpleMat.ambient_blue = 50 ; 

		// If Up Arrow Key is pressed, subtract 2 from the Z Position, and check for collision
		if ( key_cuu ) c_move(me,vector(0,0,0),vector(0,0,2 * time_step), NULL ) ; 
		// If Down Arrow Key is pressed, add 2 to the Z Position, and check for collision
      if ( key_cud ) c_move(me,vector(0,0,0),vector(0,0,-2 * time_step), NULL ) ; 
      // If Left Arrow Key is pressed, subtract 2 from the Y Position, and check for collision
      if ( key_cul ) c_move(me,vector(0,0,0),vector(0,2 * time_step,0), NULL ) ; 
      // If Right Arrow Key is pressed, add 2 to the Y Position, and check for collision
      if ( key_cur ) c_move(me,vector(0,0,0),vector(0,-2 * time_step,0), NULL ) ; 
      
	wait (1) ; 
	}
}


void main()
{
	level_load("") ; // Load empty level 
	
	// Position the camera at x = -100, y = 0, z = 22 ( Back and Up a bit )
	camera.x = -100 ; 
	camera.z = 22 ; 
	
	// Create the Earth Model , Position XYZ, Action update_Earth
	ent_create( "earth.mdl", vector( 0, 10, 40 ), update_Earth ) ; 

	
	// Create Cube Model and wrap Collision Zone to Model 
	you = ent_create("Cube.mdl",vector(0,-30,0),c_setminmax) ;
   your.material = purpleMat ; // Set the starting Material to purple color
}
