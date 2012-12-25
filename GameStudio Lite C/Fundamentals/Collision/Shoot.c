// Fire a projectile
// Delete projectile after a certain distance
// Shoot.c 

fps_max = 60;

// Initialize starting Position of Earth model
var pos_X = 40 ; 
var pos_Y = 30 ;
var pos_Z = -10 ;

random_seed( 0 ); // Initialize the random number


// Display Player's Position Variables onscreen
PANEL* panDisplay =
{
	digits(35, 20, "Y = %0.f", *, 1, pos_Y ) ;
	flags = VISIBLE;
}

	
	action update_Player()
{	
	wait(1); 
	c_setminmax(me);
	
  	my.scale_x = .5 ; my.scale_y = .5 ; my.scale_z = .5 ; 
  	
	while (1)
	{
      // Move Left or Right using Arrow Keys
      c_move ( my, vector( 0, 2 * ( key_cul - key_cur ) * time_step, 0 ), NULL, GLIDE );      
      
      // Prevent sprite from going offscreen
      if ( my.y > 67 ) my.y = 67 ; 
      if ( my.y < -67 ) my.y = -67 ; 
      
      pos_Y = my.y ;  // Write to screen display Variables
      
      wait (1);
	}
}

	action update_Projectile()
	{
		while(me) 
		{
//			if(me) // Make sure cube exists before attempting to do anything to it
//			{
				my.z += 0.1 ; // Make cube move a little each tick
				
				if (my.z > 60) // Once it gets to Max Distance, like offscreen.... 
				{
					ent_remove(me); // ...ditch it
				} 
				
//			}
			wait(1) ;
		}
	}	
	
void fire_projectile()
{
	// Spawn the Projectile slightly in front of the Player
	you = ent_create ("Cube.mdl", vector ( 40, pos_Y, pos_Z + 7 ), update_Projectile);
	c_setminmax(you) ; // Set the collision zone to the model's size
	your.scale_x = .2 ; your.scale_y = .2 ; your.scale_z = .2 ; 
}
	
void main()
{
	video_mode = 7 ; 
	wait (1) ;
	video_window( NULL, NULL, 0, "Shoot" ) ;
	
	level_load("") ; // Load empty level
	vec_set( camera.x,vector(-84, 0, 22) ) ; // place the camera at x = -84, y = 0, z = 22
	
	// Create the "earth.mdl", Position XYZ, Action update_Player
	ent_create("earth.mdl", vector(pos_X, pos_Y, pos_Z), update_Player);
 
   while (1)
	{
		if ( key_space )	
		{
			fire_projectile() ; 
			wait(60) ; 
		}
		wait(1);
	}
 
}
