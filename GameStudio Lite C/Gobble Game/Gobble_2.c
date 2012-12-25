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
		
void gobble_event()
{
	set(you, INVISIBLE ) ;
	set(you, FLAG2 ) ;
}


void update_chicken()
{
	
		my.emask |= ( ENABLE_ENTITY ); // make entity sensitive for block and entity collision
  		my.event = gobble_event;

	 while ( 1 )
	{

      if ( key_cuu ) c_move(player,vector(0,0,0),vector(-chicken_speed * time_step,0,0), IGNORE_WORLD | IGNORE_FLAG2 )  ; // If Up Arrow Key is pressed, subtract 1 from the Y Position
      if ( key_cud ) c_move(my,vector(0,0,0),vector(chicken_speed * time_step,0,0), IGNORE_WORLD | IGNORE_FLAG2 ) ; // If Down Arrow Key is pressed, add 1 to the Y Position

      if ( key_cul ) c_move(my,vector(0,0,0),vector(0,-chicken_speed * time_step,0), IGNORE_WORLD | IGNORE_FLAG2 )  ; // If Left Arrow Key is pressed, subtract 1 from the X Position
      if ( key_cur ) c_move(my,vector(0,0,0),vector(0,chicken_speed * time_step,0), IGNORE_WORLD | IGNORE_FLAG2 )  ; // If Right Arrow Key is pressed, add 1 to the X Position
      
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
   
   player = ent_create("chicken.mdl",vector(0,0,0),update_chicken) ;

   
   reset_camera();	
		
	while ( 1 )
	{

		wait (1) ;

	}
	
}
