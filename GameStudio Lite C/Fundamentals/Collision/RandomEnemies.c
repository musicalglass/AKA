// Move Entity using Arrow keys
// EarthMove.c 

fps_max = 60;

// Initialize starting Position of Earth model
var pos_X = 40 ; 
var pos_Y = 30 ;
var pos_Z = 50 ;

var numberOfEnemies = 0 ;
var maxNumEnemies = 1 ;

var elapsedTime = 0 ;

random_seed( 0 ); // Initialize the random number


ENTITY* Dude;

MATERIAL* greyMat=
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

// Display Earth's Position Variables onscreen
PANEL* panDisplay =
{
	digits(35, 10, "X = %0.f", *, 1, pos_X ) ;
	digits(35, 20, "Y = %0.f", *, 1, pos_Y ) ;
	digits(35, 30, "Z = %0.f", *, 1, pos_Z ) ;

	flags = VISIBLE;
}

void collide_event()
{
   wait(1);	 
	if(you)
	{
		ptr_remove(you);
		numberOfEnemies-- ; 

//		snd_play(plop,100,0);
	}

}
	
	action update_earth()
{
		
	wait(1); c_setminmax(me);
	
	my.emask |= ( ENABLE_ENTITY ); // make entity sensitive for block and entity collision
  	my.event = collide_event;
  	
  	my.scale_x = .5 ; my.scale_y = .5 ; my.scale_z = .5 ; 
  	
	while (1)
	{
		greyMat.ambient_red = 50;
		greyMat.ambient_green = 0 ;
		greyMat.ambient_blue = 50 ; 
		
		// If Up Arrow Key is pressed, subtract 2 from the Z Position, and check for collision
		if ( key_cuu ) c_move(me,vector(0,0,0),vector(0,0,2 * time_step), NULL ) ; 
		// If Down Arrow Key is pressed, add 2 to the Z Position, and check for collision
      if ( key_cud ) c_move(me,vector(0,0,0),vector(0,0,-2 * time_step), NULL ) ; 
      // If Left Arrow Key is pressed, subtract 2 from the Y Position, and check for collision
      if ( key_cul ) c_move(me,vector(0,0,0),vector(0,2 * time_step,0), NULL ) ; 
      // If Right Arrow Key is pressed, add 2 to the Y Position, and check for collision
      if ( key_cur ) c_move(me,vector(0,0,0),vector(0,-2 * time_step,0), NULL ) ; 
      // If Page Up Key is pressed, subtract 2 from the X Position, and check for collision
      if ( key_pgup ) c_move(me,vector(0,0,0),vector(2 * time_step,0,0), NULL ) ; 
      // If Page Down Key is pressed, add 2 to the X Position, and check for collision
      if ( key_pgdn ) c_move(me,vector(0,0,0),vector(-2 * time_step,0,0), NULL ) ; 
      
      pos_Z = my.z ; pos_Y = my.y ; pos_X = my.x ; // Write to screen display Variables
      
		wait (1);
	}
}

void main()
{
	level_load(""); // Load empty level 
	
	vec_set(camera.x,vector(-84, 0, 22)); // place the camera at x = -84, y = 0, z = 22
	
	
	// Create the "earth.mdl", Position XYZ, Action update_earth
	ent_create("earth.mdl", vector(pos_X, pos_Y, pos_Z), update_earth);
 
   
   while (1)
	{
		if(numberOfEnemies != maxNumEnemies) // As long as we haven't reached the Max num enemies (1)
		elapsedTime++; // Increment elapsed time every click
		
		if ( elapsedTime >= 200 )	
		{
			Dude = ent_create ("Cube.mdl", vector ( 40, random(100)-60, random(100)-30), NULL);
			c_setminmax(Dude);
			Dude.material= greyMat;
			Dude.scale_x = .5 ; Dude.scale_y = .5 ; Dude.scale_z = .5 ; 
			numberOfEnemies++;
			elapsedTime = 0 ; 
		}
		wait(1);
	}
 
}
