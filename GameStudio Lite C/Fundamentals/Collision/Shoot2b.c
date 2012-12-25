// Fire a projectile
// Delete projectile after a certain distance
// Shoot.c 

fps_max = 60 ;  //  Define the Frame Rate so game runs the same on different speed computers

// Initialize starting Position of Earth model
var pos_X = 0 ; 
var pos_Y = 30 ;
var pos_Z = -10 ;

var numberOfEnemies = 0 ;
var maxNumEnemies = 1 ;

var elapsedTime = 0 ;


// Display Player's Position Variables onscreen
PANEL* panDisplay =
{
	digits( 35, 20, "Y = %0.f", *, 1, pos_Y ) ;
	flags = VISIBLE;
}
	
function remove_Projectile() // this function runs when the bullet collides with something
{
	wait (1); // wait a frame to be sure (don't trigger engine warnings)
	ent_remove ( you ); // and then blow thine enemy to smithereens
	numberOfEnemies-- ; // enter the victory in your battle journal
	ent_remove ( me ); // then promptly commit suicide
}

function move_Projectile()
{
	var bullet_speed = 0; // this var will store the speed of the bullet

	my.emask |= (ENABLE_BLOCK | ENABLE_ENTITY);

	my.event = remove_Projectile; // when it collides with something, its event function (remove_Projectile) will run


	while ( me ) // this loop will run for as long as the bullet exists (it isn't "null")
	{
    	bullet_speed = 4 * time_step ; // or up / down on the z axis
    	c_move( me, vector( 0, 0, bullet_speed ), nullvector, IGNORE_YOU | IGNORE_FLAG2 ) ; // move the bullet ignoring its creator (the player)

		if ( my.z > 75 ) // Once it gets to Max Distance, like offscreen.... 
		{
			wait(1) ; 
			ent_remove ( me ) ; // ...ditch it
		}

   wait (1);
	}

}
	
void fire_projectile()
{

	// Spawn the Projectile slightly in front of the Player
	you = ent_create ("Cube.mdl", vector ( 0, player.y, player.z + 7 ), move_Projectile);
	your.scale_x = .2 ; your.scale_y = .2 ; your.scale_z = .2 ;
	set(you,FLAG2) ; // I am a bullet
	c_setminmax(you) ; // Set the collision zone to the model's size
}

void create_Enemy()
{
	if(numberOfEnemies != maxNumEnemies) // As long as we haven't reached the Max num enemies 
		elapsedTime++; // Increment elapsed time every click
		
		if ( elapsedTime >= 200 )	// Wait a bit before spawning new enemy
		{
			random_seed( 0 ); // Initialize the random number thingy
			// Create enemy in random Postion somewhere above our hero
			you = ent_create ("Cube.mdl", vector ( 0, random(80)-40, random(50)+10 ), NULL) ; 
			your.scale_x = .5 ; your.scale_y = .5 ; your.scale_z = .5 ; 
			c_setminmax( you ) ; // Wrap collision zone to models's size
			
			numberOfEnemies++ ; // Keep track of how many enemies thou must vanquish at one time
			elapsedTime = 0 ; // Reset the timer for next time
		}
}

action update_Player()
{ 
       player = my; // I'm the player
       set(my,PASSABLE); 

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
			wait(60) ; // Repeat Rate
		}
		
		create_Enemy() ; 
		
		wait(1);
	}
 
}
