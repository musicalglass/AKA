// Move Entity using Arrow keys
// LetterModel.c 

fps_max = 60 ; //  Define the Frame Rate so game runs the same on different speed computers

// Initialize starting Position of Model
var pos_X = 0 ; 
var pos_Y = 0 ;
var pos_Z = 0 ;


// Define initial Color settings for Letter Entity
MATERIAL* purpleMat=
	{
	ambient_red = 50 ; 
	ambient_green = 0 ; 
	ambient_blue = 50 ; 
	diffuse_red = 50 ; 
	diffuse_green = 0 ; 
	diffuse_blue = 50 ; 
	specular_red = 0 ; 
	specular_green = 0 ; 
	specular_blue = 0 ; 
	emissive_red = 0 ; 
	emissive_green = 0 ; 
	emissive_blue = 0 ; 
	power = 50 ; 
}
	
action update_position()
{
	while (1)
	{
		if ( key_cuu ) my.z += 2 * time_step ; // If Up Arrow Key is pressed, subtract 2 from the Z Position
      if ( key_cud ) my.z -= 2 * time_step ; // If Down Arrow Key is pressed, add 2 to the Z Position

      if ( key_cul ) my.y += 2 * time_step ; // If Left Arrow Key is pressed, subtract 2 from the Y Position
      if ( key_cur ) my.y -= 2 * time_step ; // If Right Arrow Key is pressed, add 2 to the Y Position
      
      if ( key_pgup ) my.x += 2 * time_step ; // If Page Up Key is pressed, subtract 2 from the X Position
      if ( key_pgdn ) my.x -= 2 * time_step ; // If Page Down Key is pressed, add 2 to the X Position
      
      
      pos_Z = my.z ; pos_Y = my.y ; pos_X = my.x ; // Write to screen display Variables
      
		wait (1);
	}
}

void main()
{
	level_load(""); 
	
	// Create the "B.mdl", Position XYZ, Action update_position	
	you = ent_create("B.mdl",vector(pos_X, pos_Y, pos_Z), update_position);
   your.material = purpleMat ; // Set the starting Material to purple color
   your.material.ambient_red = 100 ; 	your.material.ambient_blue = 0 ; 

   your.pan = 180 ; 
   sky_color.red = 10 ; sky_color.green = 10 ; sky_color.blue = 10 ; 
 
	vec_set(camera.x,vector(-40, 0, 10)); // place the camera at x = -84, y = 0, z = 22
// camera.pan = 180 ; 
}
