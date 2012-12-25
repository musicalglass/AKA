// Make a Cube
// Cube.c

#include <acknex.h>
#include <default.c>

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

void reset_camera()
   	{
	   	camera.x = 800; 	
			camera.y =  0; 
			camera.z = 500; 					
			camera.pan = 180; 
			camera.tilt = -20 ;	
		}



function main()
{
	
   video_mode = 7 ;
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Cube" ) ;
	
   level_load("");
   
   wait ( 2 ) ;
   
   Dude = ent_create("Cube.mdl",vector(0,0,0),NULL) ;
   Dude.material= greyMat;
   Dude.pan = -60;
   
   reset_camera();	
		
	while ( 1 )
{  
	wait (1) ;

	}
	
}
