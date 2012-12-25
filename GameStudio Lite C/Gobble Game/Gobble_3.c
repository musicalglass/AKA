// Gobble Game
// Gobble_3.c

#include <acknex.h>
#include <default.c>

var chicken_speed = 20 ;

var score_var = 0 ;

SOUND* plop = "plop.wav";


FONT* arial_font = "Arial#72b"; // truetype font 

PANEL* debugPanel =								// Score
{	
  	digits(0,0,3.0,arial_font,1,score_var); 	
}

PANEL* GameOverPanel =
{	
  	
digits(0,0,"Game Over",arial_font,0,0);   // 
  		
}

void level1_referee()
{
	while (1)
	{
		if ( score_var == 6 )
		{
			GameOverPanel.flags |= VISIBLE;	
		}
		wait (1) ;
	}
}

void reset_camera()
   	{
	   	camera.x = 800; 	
			camera.y =  0; 
			camera.z = 500; 					
			camera.pan = 180; 
			camera.tilt = -30 ;	
		}
		
void gobble_event()
{
	set(you, INVISIBLE ) ;
	set(you, FLAG2 ) ;
	score_var++;
//	ent_playsound ( you, plop, 100) ;
snd_play(plop,100,0);
}


void update_chicken()
{
	
		my.emask |= ( ENABLE_ENTITY ); // make entity sensitive for block and entity collision
  		my.event = gobble_event;

	 while ( 1 )
	{

      if ( key_cud ) c_move(player,vector(-chicken_speed * time_step,0,0),vector(0,0,0), IGNORE_WORLD | IGNORE_FLAG2 )  ; // If Up Arrow Key is pressed, subtract 1 from the Y Position
      if ( key_space ) c_move(my,vector(chicken_speed * time_step,0,0),vector(0,0,0), IGNORE_WORLD | IGNORE_FLAG2 ) ; // If Down Arrow Key is pressed, add 1 to the Y Position

      if ( key_cul ) my.pan += chicken_speed * time_step ; // If Left Arrow Key is pressed, subtract 1 from the X Position
      if ( key_cur ) my.pan -= chicken_speed * time_step ; // If Right Arrow Key is pressed, add 1 to the X Position
      
		wait (1) ;

	}  
}


function main()
{
	
   video_mode = 7 ;
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "GobbleGame" ) ;
	
		// display debug panel
	debugPanel.pos_x = 10;
	debugPanel.pos_y = 10;
	debugPanel.flags |= VISIBLE;
	
			// display GameOver panel
	GameOverPanel.pos_x = 250 ;
	GameOverPanel.pos_y = 100 ;
	GameOverPanel.flags &= ~VISIBLE;
	
   level_load("Stage.wmb");
   
   wait ( 2 ) ;
   
   player = ent_create("chicken.mdl",vector(0,0,0),update_chicken) ;

   
   reset_camera();	
		
	while ( 1 )
	{

		wait (1) ;

	}
	
}
