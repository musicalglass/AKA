// Make a Cube
// Cube.c

#include <acknex.h>
#include <default.c>




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

void reset_camera()
   	{
	   	camera.x = 800; 	
			camera.y =  0; 
			camera.z = 500; 					
			camera.pan = 180; 
			camera.tilt = -20 ;	
		}
		
		
void move_arrows()
{
	
      if ( key_cuu ) my.z += 2  ; // If Up Arrow Key is pressed, subtract 1 from the Y Position
      if ( key_cud ) my.z -= 2  ; // If Down Arrow Key is pressed, add 1 to the Y Position

      if ( key_cul ) my.y -= 2  ; // If Left Arrow Key is pressed, subtract 1 from the X Position
      if ( key_cur ) my.y += 2  ; // If Right Arrow Key is pressed, add 1 to the X Position

}


void update_cube()
{
	 while ( 1 )
	{
	move_arrows();
      my.pan  += 1;
		wait (1) ;

	}  
}


function main()
{
	
   video_mode = 7 ;
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Cube" ) ;
	
   level_load("Level_01.wmb");
   
   wait ( 2 ) ;
   
   me = ent_create("Cube.mdl",vector(0,0,0),update_cube) ;
   my.material= purpleMat;
   
   me = ent_create("Cube.mdl",vector(0,0,200),update_cube) ;
   my.material= purpleMat;

   
   reset_camera();	
		
	while ( 1 )
	{

		wait (1) ;

	}
	
}
