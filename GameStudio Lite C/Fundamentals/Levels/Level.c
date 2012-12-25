// Levels

#include <acknex.h>
#include <default.c>


void reset_camera()
   	{
	   	camera.x = 800; 	
			camera.y =  0; 
			camera.z = 500; 					
			camera.pan = 180; 
			camera.tilt = -20 ;	
		}

void loadLevel2()
{
level_load("Level_02.wmb");
reset_camera();
}	

void loadLevel1()
{
level_load("Level_01.wmb");
reset_camera();
}	

function main()
{
	
   video_mode = 7 ; // Set Screen Resolution to 800 x 600
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Load Levels using Number Keys" ) ;
	
   level_load("Level_01.wmb");
   
   reset_camera();	
		
	while ( 1 )
	{
      
      on_2 = loadLevel2;
      on_1 = loadLevel1;
		wait (1) ;

	}
	
}
