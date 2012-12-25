
#include <acknex.h>
#include <default.c>

//		PANELS	//

// Panels are 2D game elements that can display images, text, clickable buttons, etc.

FONT* gamefont = "Technical#16b"; 			// define a font for later use: Technical, size 16, bold 			
FONT* counterfont = "Eurostile#40b"; 		// define a font for later use: Eurostile, size 40, bold

BMAP* scoreBmp = "Scoreboard.tga"; 						// loads a bitmap (the image with the eggcarton and the splattered egg) for later use

PANEL* scorePanel =										// defines the scoring panel used during gameplay:
{	
	bmap = scoreBmp;										// makes the bitmap we just defined the background image for the panel
	digits(45,8,3,counterfont,1,enemiesBlasted); 			// displays the variable eggsLost which counts eggs that hit the ground 
}

BMAP* gameOverBmp = "gameOver.bmp";							// loads the gameOver bitmap for later use

BMAP* quitButtonOn = "quitButtonPressed.bmp"; 			// A button can have up to three images: On (for when the button is clicked)
BMAP* quitButtonOff = "quitButton.bmp";					// Off, for the button's normal appearance, and Over, for when the mouse hovers over it
BMAP* quitButtonOver = "quitButton.bmp"; 					// I'm using the same image here for Off and Over.

BMAP* restartButtonOn = "restartButtonPressed.bmp"; 	// The button images only get defined here, and the names I am giving them are arbitrary.
BMAP* restartButtonOff = "restartButton.bmp";			// They are actually assigned to a button in the panel definition below.
BMAP* restartButtonOver = "restartButton.bmp"; 

// Display Earth's Position Variables onscreen
PANEL* debugPanel =
{
	digits(35, 10, "X = %0.f", *, 1, pos_X ) ;
	digits(35, 20, "Y = %0.f", *, 1, pos_Y ) ;
	digits(35, 30, "Z = %0.f", *, 1, pos_Z ) ;
}

PANEL* gameOverPanel =											// defines the gameOver panel used at the end of the game:
{
	bmap = gameOverBmp; 											// defines the gameOver bitmap as the background image
  	digits(30,130, "You blasted %0.f Cubes!", counterfont, 1, enemiesBlasted ) ;		// displays the eggsShipped variable as the final score
  	
  	button(240,250,quitButtonOn,quitButtonOff,quitButtonOver,exitGame,NULL,NULL);					// this is where the buttons are defined:
  	button(40,250,restartButtonOn,restartButtonOff,restartButtonOver,restartGame,NULL,NULL);	// position, images, and functionality
}


BMAP* gameStartBmp = "gameStart.bmp";
BMAP* startButtonOn = "startButtonPressed.bmp"; 
BMAP* startButtonOff = "startButton.bmp";
BMAP* startButtonOver = "startButton.bmp";

BMAP* rulesButtonOn = "rulesButtonPressed.bmp"; 
BMAP* rulesButtonOff = "rulesButton.bmp";
BMAP* rulesButtonOver = "rulesButton.bmp";

PANEL* gameStartPanel =
{
	bmap = gameStartBmp; 
	button(520,470,rulesButtonOn,rulesButtonOff,rulesButtonOver,displayRules,NULL,NULL);
 	button(520,535,startButtonOn,startButtonOff,startButtonOver,restartGame,NULL,NULL);
 	digits(380,200,"Sitting Ducks",Arial#48b,1,NULL); 			// displays the variable eggsLost which counts eggs that hit the ground 
  	digits(390,250,"A game of sportsmanship",Arial#24b,1,NULL); 	// displays the variable cartonsShipped which counts cartons you sent off
}

BMAP* gameRulesBmp = "Rules.bmp";

PANEL* gameRulesPanel =
{
	bmap = gameRulesBmp; 
 	button(300,580,startButtonOn,startButtonOff,startButtonOver,restartGame,NULL,NULL);
}

//		VARIABLES	//

var gameState = 0;

// Initialize starting Position of Earth model
var pos_X = 0 ; 
var pos_Y = 30 ;
var pos_Z = -10 ;

var enemiesBlasted = 0 ;
var goalEnemiesBlasted = 10 ; 
var numberOfEnemies = 0 ;
var maxNumEnemies = 1 ;

var elapsedTime = 0 ;


//		DEFINES	//							// These are simply assignments of values and generically named variables to 
												// meaningful names. This makes the code easier to understand.
												
#define gameStart 0						// defines a constant variable "gameStart" and assigns it the value 0
#define gamePlay 1						// defines a constant variable "gamePlay" and assigns it the value 1
#define gameEnd 2							// defines a constant variable "gameEnd" and assigns it the value 2


////	SOUNDS	//

//SOUND* plopSound  = "plop.wav";					// defines a pointer to a sound file which we can use to play the sound later.
//SOUND* splatSound = "splat.wav";
//SOUND* backgroundSound = "background.wav";


//		MATERIALS	//						// Materials define color and surface properties of the objects they are assigned to.
//												// I am defining one grey material here for the eggcarton to demonstrate how they are used.

//MATERIAL* greyMat=
//	{
//	ambient_red = 50;
//	ambient_green = 50 ;
//	ambient_blue = 50 ;
//	diffuse_red = 100 ;
//	diffuse_green = 100 ;
//	diffuse_blue = 100 ;
//	specular_red = 0 ;
//	specular_green = 0 ;
//	specular_blue = 0 ;
//	emissive_red = 0;
//	emissive_green = 0 ;
//	emissive_blue = 0;
//	power =50;
//}

function remove_Projectile() // this function runs when the bullet collides with something
{
		wait (1); // wait a frame to be sure (don't trigger engine warnings)
		ent_remove (you); // and then blow thine enemy to smithereens
		enemiesBlasted++ ;  // enter the victory in your battle journal
		numberOfEnemies-- ; // keep track of how many enemies there are
		ent_remove (me); // then promptly commit suicide
}

function move_Projectile()
{
       var bullet_speed = 0; // this var will store the speed of the bullet

       my.emask |= (ENABLE_BLOCK | ENABLE_ENTITY);

       my.event = remove_Projectile; // when it collides with something, its event function (remove_Projectile) will run


       while (me) // this loop will run for as long as the bullet exists (it isn't "null")
       {
       	bullet_speed = 4 * time_step ; // or up / down on the z axis
        	c_move (me, vector(0, 0, bullet_speed), nullvector, IGNORE_YOU | IGNORE_FLAG2); // move the bullet ignoring its creator (the player)

			if (my.z > 75) // Once it gets to Max Distance, like offscreen.... 
				{
					wait(1) ; 
					ent_remove (me) ; // ...ditch it
				}
				
       	wait (1);
       }

}
	
void fire_projectile()
{

	// Spawn the Projectile slightly in front of the Player
	you = ent_create ("Cube.mdl", vector ( 0, player.y, player.z + 7 ), move_Projectile);
	your.scale_x = .2 ; your.scale_y = .2 ; your.scale_z = .2 ;
	set(you,FLAG2) ; // I am a bullet
	c_setminmax(you) ; // Set the collision zone to the model's size
}

void create_Enemy()
{
	if(numberOfEnemies != maxNumEnemies) // As long as we haven't reached the Max num enemies (1)
		elapsedTime++; // Increment elapsed time every click
		
		if ( elapsedTime >= 40 )	// Wait a bit before spawning new enemy
		{
			random_seed( 0 ); // Initialize the random number thingy
			// Create enemy in random Postion somewhere above our hero
			you = ent_create ("Cube.mdl", vector ( 0, random(80)-40, random(50)+10 ), NULL) ; 
			your.scale_x = .5 ; your.scale_y = .5 ; your.scale_z = .5 ; 
			c_setminmax( you ) ; // Wrap collision zone to models's size
			
			numberOfEnemies++ ; // Keep track of how many enemies thou must vanquish at one time
			elapsedTime = 0 ; // Reset the timer for next time
		}
}

action update_Player()
{ 
       player = my; // I'm the player
       set(my,PASSABLE); 

       while (1)
       {
        	// Move Left or Right using Arrow Keys
        	c_move ( my, vector( 0, 2 * ( key_cul - key_cur ) * time_step, 0 ), NULL, GLIDE );
        	
        	// Prevent sprite from going offscreen
        	if ( my.y > 67 ) my.y = 67 ; 
        	if ( my.y < -67 ) my.y = -67 ; 

        	wait (1);
       }

}


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
 	fps_max = 60;

	// 	PANELS	//

	// debug panel 
	debugPanel.pos_x = 10;
	debugPanel.pos_y = 10;
	debugPanel.flags &= ~VISIBLE;
	
	// score panel
	scorePanel.pos_x = 10; //(screen_size.x - bmap_width(scoreBmp));
	scorePanel.pos_y = (screen_size.y - bmap_height(scoreBmp)) - 10;
	vec_set(scorePanel.blue,vector(0,0,0)); 
	scorePanel.flags &= ~VISIBLE;
	
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
//	snd_stop(backgroundSoundHandle);		// stop the looping background sound
	wait(25);									// immediately exiting when the button is clicked felt too harsh so I put in a delay
	sys_exit("bye bye..."); 				// quit the game
}


void restartGame()							// resets all game variables, loads the level, positions the camera, and displays the scoring UI
{
	wait(2);									// immediately starting when the button is clicked felt too harsh so I put in a delay
	
	enemiesBlasted = 0 ;
	numberOfEnemies = 0 ;
	elapsedTime = 0 ;

	level_load("");					// load the level
	
	wait(2);										// wait two ticks for the level to finish loading
	
	// Create the "earth.mdl", Position XYZ, Action update_Player
	ent_create("earth.mdl", vector(pos_X, pos_Y, pos_Z), update_Player);
	
	vec_set(camera.x,vector(-84, 0, 22));	// position the camera
	

	gameState = gamePlay;					// set the gameState variable which unfreezes the game
	scorePanel.flags |= VISIBLE;		// set up the UI for gameplay
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

		if ( gameState == gamePlay )						// are we playing? if yes:
		{
			if ( enemiesBlasted == goalEnemiesBlasted )							// if number of enemies killed == Max
			{
				scorePanel.flags &= ~VISIBLE;		// switch to the gameOver UI
				gameOverPanel.flags |= VISIBLE;
				gameState = gameEnd;						// set the gameState variable to freeze the game
			} 
			
			if ( key_space )	
		{
			fire_projectile() ; 
			wait(60) ; // Repeat Rate
		}
		
		create_Enemy() ; 
		}
	
	wait(1);										 		// wait for the other entities to get updated so we don't crash the game.
	}
	
}


void main()
{

	// initialize game
	
	initializeGame();				// this function is in gameManager.c; look there for details on what it does
	gameManager();					// this function is in gameManager.c; look there for details on what it does
		
 	// MAIN GAME LOOP //
 
	while(1)							// start the loop. 
	{	
	
		switch (gameState)		// This freezes the game while we are in start and end mode, and unfreezes it
		{								// when we enter play mode.
			case gameStart:		// Which mode we are in is determined by the variable gameState which I defined
				freeze_mode = 1;	// in definitions.c. 
				break;				// It's value is set in the functions restartGame() and gameManager().
				
			case gamePlay:
				freeze_mode = 0;
				break;
				
			case gameEnd:
				freeze_mode = 1;
				break;
		}
	
		wait(1);						// This has to be included in every while(1) loop to make the loop pause and wait
	}									// for the rest of the game to get updated. Not including it will make your game crash.
	
}