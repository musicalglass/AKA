
#include <acknex.h>
#include <default.c>

#include "definitions.c";
#include "egg.c";
#include "chicken.c";
#include "eggCarton.c";
#include "gameManager.c";


///////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Main Game Function														
//																				
// This initializes the game (sets basic parameters such as video settings) and then starts the main game loop.
//
//	The main game loop is a function that loops as long as the game is running. It serves as the games main control
//	mechanism - during each loop of this function each object in the game is updated. The game engine does this
// updating automatically as long as main() is running.
//	
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

void main()
{

	// initialize game
	
	video_set(1024, 768, 32, 2); 			
	warn_level     = 2;	
 	tex_share      = 1;						
 	mouse_mode = 4;
 	mouse_range = 100000;
 	shadow_stencil = 2;
 	random_seed(0); 
 	
	level_load("eggz.wmb");					// load the level
	wait(2);										// wait two ticks for the level to finish loading
	
	
	
// position the camera
	
		camera.x = 800; 	
		camera.y =  0; 
		camera.z = 500; 					
		camera.pan = 180; 
		camera.tilt = -20 ;
	
		
 	// MAIN GAME LOOP //
 
	while(1)							// start the loop. 
	{	
	
		wait(1);	
	
	}									
	
}