/////////////////////////////////////////////////////////////////////////////////
//
//	This file contains general game functions that have to do with initial settings, UI, and gameplay flow.
//
//
/////////////////////////////////////////////////////////////////////////////////



void initializeGame()							// sets general settings for the game at startup and sets up positions and visibility status for UI panels
{
	//	SETTINGS	//
	
	video_set(1024, 768, 32, 2); 				// there is an alternative way of doing this called video_mode. Don't use it, it's buggy.
	warn_level     = 2;	
 	tex_share      = 1;							// map entities share their textures
 	mouse_mode = 4;
 	mouse_range = 100000;
 	shadow_stencil = 2;
 	random_seed(0); 

	// 	PANELS	//

	// debug panel 
	debugPanel.pos_x = 10;
	debugPanel.pos_y = 10;
	debugPanel.flags &= ~VISIBLE;
	
	// counter panel
	counterPanel.pos_x = 10; //(screen_size.x - bmap_width(counterBmp));
	counterPanel.pos_y = (screen_size.y - bmap_height(counterBmp)) - 10;
	vec_set(counterPanel.blue,vector(0,0,0)); 
	counterPanel.flags &= ~VISIBLE;
	
	// gameOver panel
	gameOverPanel.pos_x = (screen_size.x/2 - bmap_width(gameOverBmp)/2);
	gameOverPanel.pos_y = (screen_size.y/2 - bmap_height(gameOverBmp)/2);
	vec_set(gameOverPanel.blue,vector(0,0,0)); 
	gameOverPanel.flags &= ~VISIBLE;

	// gameStart panel
	gameStartPanel.pos_x = (screen_size.x/2 - bmap_width(gameStartBmp)/2);
	gameStartPanel.pos_y = (screen_size.y/2 - bmap_height(gameStartBmp)/2);
	vec_set(gameStartPanel.blue,vector(0,0,0)); 
	gameStartPanel.flags |= VISIBLE;
	
	// gameRules panel
	gameRulesPanel.pos_x = (screen_size.x/2 - bmap_width(gameRulesBmp)/2);
	gameRulesPanel.pos_y = (screen_size.y/2 - bmap_height(gameRulesBmp)/2);
	vec_set(gameRulesPanel.blue,vector(0,0,0)); 
	gameRulesPanel.flags &= ~VISIBLE;
}



void exitGame()								// gets called by the quit button on the gameOver panel. Ends the game and shuts down the engine.
{
	//snd_stop(backgroundSoundHandle);		// stop the looping background sound
	wait(25);									// immediately exiting when the button is clicked felt too harsh so I put in a delay
	sys_exit("bye bye..."); 				// quit the game
}

void restartGame()							// resets all game variables, loads the level, positions the camera, and displays the scoring UI
{
	wait(25);									// immediately starting when the button is clicked felt too harsh so I put in a delay
	var numberOfEnemies = 0 ;
   var maxNumEnemies = 1 ;
   var totalEnemiesWhooped = 0 ; 

	var elapsedTime = 0 ;

	level_load(" ");					// load the level
	wait(2);										// wait two ticks for the level to finish loading
	
	//backgroundSoundHandle = snd_loop(backgroundSound, 70, 0);		// start the background sound looping
	
//													// position the camera
	vec_set( camera.x,vector(-84, 0, 22) ) ; 
	

	gameState = gamePlay;					// set the gameState variable which unfreezes the game
	counterPanel.flags |= VISIBLE;		// set up the UI for gameplay
	gameOverPanel.flags &= ~VISIBLE;
	gameStartPanel.flags &= ~VISIBLE;
	gameRulesPanel.flags &= ~VISIBLE;
	
}

void displayRules()
{
	gameStartPanel.flags &= ~VISIBLE;
	gameRulesPanel.flags |= VISIBLE;
}

void gameManager()										// this game manager is a little feeble, with only one task to keep track of: Ending the game if you've lost 12 eggs.
{																// More complicated games would have a lot more functionality here.
		
	while(1)													// start the manager's looping function. The following commands will be executed every tick in the game.													
	{
			
		if (gameState == gamePlay)						// are we playing? if yes:
		{
			if (totalEnemiesWhooped == 10)							// did the player miss 12 eggs yet? if yes:
			{
				counterPanel.flags &= ~VISIBLE;		// switch to the gameOver UI
				gameOverPanel.flags |= VISIBLE;
				gameState = gameEnd;						// set the gameState variable to freeze the game
			} 
		}
	
	wait(1);										 		// wait for the other entities to get updated so we don't crash the game.
	}
	
}






