// FireProjectile.c 
// Spawn a new entity at your current position

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

// Initialize starting Position of Earth model
var pos_X = 0 ; 
var pos_Y = 30 ;
var pos_Z = -10 ;


action update_Earth() // Move the Player using Arrow Keys
{
	while (1)
	{
      // If Left Arrow Key is pressed, add 2 to the Y Position
      if ( key_cul ) my.y += 2 * time_step ; 
      // If Right Arrow Key is pressed, subtract 2 from the Y Position
      if ( key_cur ) my.y -= 2 * time_step ; 
      
       // Write current position to global variables 
      pos_X = my.x ; pos_Y = my.y ; pos_Z = my.z ;
      
	wait (1);
	}
}

action update_Projectile() // Move the Projectile
{
	while( me ) // As long as the bullet exists...
	{
		my.z += 0.2 ; // move the Projectile a little each tick
			
			if ( my.z > 60 ) // Once it reaches the designated altitude...
			{
				ptr_remove( me ) ; // .. self destruct
			} 

	wait(1) ;
	}	
}	
	
void create_Projectile() // This Function creates a bullet Entity
{
	// Spawn Projectile 10 units in front of Player
	you = ent_create ("Cube.mdl", vector ( 0, pos_Y, pos_Z + 10 ), update_Projectile);
	your.scale_x = .2 ; your.scale_y = .2 ; your.scale_z = .2 ; // Scale it down to bullet size
}
	
void main()
{
	level_load("") ; // Load empty level

	// Position the camera at x = -100, y = 0, z = 22 ( Back and Up a bit )
	camera.x = -100 ; 
	camera.z = 22 ; 
	
	// Create the earth.mdl , Position XYZ, Action update_Earth
	ent_create("earth.mdl", vector(pos_X, pos_Y, pos_Z), update_Earth);
 
   
   while (1) // While the game is running...
	{
		if ( key_space )	
		{
			create_Projectile(); // Call the Fuction to create new bullet entity
			wait(60); // Fire repeat rate
		}

	wait(1);
	}

}
