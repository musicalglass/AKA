// Gobble Game
// Gobble.c

#include <acknex.h>
#include <default.c>

var chicken_speed = 20 ;


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
	
      if ( key_cuu ) my.x += chicken_speed * time_step  ; // If Up Arrow Key is pressed, subtract 1 from the Y Position
      if ( key_cud ) my.x -= chicken_speed * time_step  ; // If Down Arrow Key is pressed, add 1 to the Y Position

      if ( key_cul ) my.y -= chicken_speed * time_step  ; // If Left Arrow Key is pressed, subtract 1 from the X Position
      if ( key_cur ) my.y += chicken_speed * time_step  ; // If Right Arrow Key is pressed, add 1 to the X Position

}


void update_chicken()
{
	 while ( 1 )
	{
	move_arrows();
      
		wait (1) ;

	}  
}


function main()
{
	
   video_mode = 7 ;
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Cube" ) ;
	
   level_load("Stage.wmb");
   
   wait ( 2 ) ;
   
   me = ent_create("chicken.mdl",vector(0,0,0),update_chicken) ;

   
   reset_camera();	
		
	while ( 1 )
	{

		wait (1) ;

	}
	
}
