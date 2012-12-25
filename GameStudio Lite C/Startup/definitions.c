/////////////////////////////////////////////////////////////////////////////////////////////
//
//	This is where I define and initialize variables and constants, panels, sounds, and 
//	other assorted items that get used throughout the game. Keeping these things on one page
// helps you stay organized.
// Note that this page only defines and initializes items. They will not show up in your game until
// a function calls or modifies them.
//
//////////////////////////////////////////////////////////////////////////////////////////////


//		PANELS	//

// Panels are 2D game elements that can display images, text, clickable buttons, etc.

FONT* gamefont = "Technical#16b"; 			// define a font for later use: Technical, size 16, bold 			
FONT* counterfont = "Eurostile#40b"; 		// define a font for later use: Eurostile, size 40, bold


PANEL* debugPanel =								// this is a handy panel that I use to track the values of variables
{														// for debugging purposes. It is invisible in the final game.
  
  	digits(0,0,3.3,gamefont,1,testVar); 	// displays the value of the variable testVar. See the documentation for details on the digit function.
  	digits(0,10,3.3,gamefont,1,testVar1); 
  	digits(0,20,3.3,gamefont,1,testVar2); 
  	digits(0,30,3.3,gamefont,1,testVar3); 
  	digits(0,40,3.3,gamefont,1,testVar4);

}


BMAP* counterBmp = "images/counter.bmp"; 						// loads a bitmap (the image with the eggcarton and the splattered egg) for later use

PANEL* counterPanel =										// defines the scoring panel used during gameplay:
{	
	bmap = counterBmp;										// makes the bitmap we just defined the background image for the panel
	
	digits(110,40,3,counterfont,1,eggsLost); 			// displays the variable eggsLost which counts eggs that hit the ground 
  	digits(310,40,3,counterfont,1,cartonsShipped); 	// displays the variable cartonsShipped which counts cartons you sent off
}


BMAP* gameOverBmp = "images/gameOver.bmp";							// loads the gameOver bitmap for later use

BMAP* quitButtonOn = "images/quitButtonPressed.bmp"; 			// A button can have up to three images: On (for when the button is clicked)
BMAP* quitButtonOff = "images/quitButton.bmp";					// Off, for the button's normal appearance, and Over, for when the mouse hovers over it
BMAP* quitButtonOver = "images/quitButton.bmp"; 					// I'm using the same image here for Off and Over.

BMAP* restartButtonOn = "images/restartButtonPressed.bmp"; 	// The button images only get defined here, and the names I am giving them are arbitrary.
BMAP* restartButtonOff = "images/restartButton.bmp";			// They are actually assigned to a button in the panel definition below.
BMAP* restartButtonOver = "images/restartButton.bmp"; 

PANEL* gameOverPanel =											// defines the gameOver panel used at the end of the game:
{
	bmap = gameOverBmp; 											// defines the gameOver bitmap as the background image
  	digits(220,130,3,counterfont,1,totalEnemiesWhooped); 		// displays the eggsShipped variable as the final score
  	
  	button(240,250,quitButtonOn,quitButtonOff,quitButtonOver,exitGame,NULL,NULL);					// this is where the buttons are defined:
  	button(40,250,restartButtonOn,restartButtonOff,restartButtonOver,restartGame,NULL,NULL);	// position, images, and functionality
}


BMAP* gameStartBmp = "images/gameStart.bmp";
BMAP* startButtonOn = "images/startButtonPressed.bmp"; 
BMAP* startButtonOff = "images/startButton.bmp";
BMAP* startButtonOver = "images/startButton.bmp";

BMAP* rulesButtonOn = "images/rulesButtonPressed.bmp"; 
BMAP* rulesButtonOff = "images/rulesButton.bmp";
BMAP* rulesButtonOver = "images/rulesButton.bmp";

PANEL* gameStartPanel =
{
	bmap = gameStartBmp; 
	button(520,470,rulesButtonOn,rulesButtonOff,rulesButtonOver,displayRules,NULL,NULL);
 	button(520,535,startButtonOn,startButtonOff,startButtonOver,restartGame,NULL,NULL);
}

BMAP* gameRulesBmp = "images/Rules.bmp";

PANEL* gameRulesPanel =
{
	bmap = gameRulesBmp; 
 	button(520,535,startButtonOn,startButtonOff,startButtonOver,restartGame,NULL,NULL);
}

//		VARIABLES	//

// test variables - used in the debug panel

var testVar  = 0; // FOR TESTING. 	To use, assign the value of the variable you want to track to one of the teasVar variables
var testVar1 = 0; // FOR TESTING		and unhide the debug panel by changing the line "debugPanel.flags &= ~VISIBLE;"
var testVar2 = 0; // FOR TESTING		to "debugPanel.flags |= VISIBLE;" in the function initializeGame().
var testVar3 = 0; // FOR TESTING
var testVar4 = 0; // FOR TESTING

					// tracks how many eggs have been shipped (cartonsShipped * 6) for the final score
var gameState = 0;						// tracks which part of the game we are in (start, playing, end)

//var backgroundSoundHandle = 0;		// tracks the background sound so we can stop it.

var numberOfEnemies = 0 ; 

VECTOR* temp = {x =0; y=0; z=0;}		// all-purpose vector pointer


//		DEFINES	//							// These are simply assignments of values and generically named variables to 
												// meaningful names. This makes the code easier to understand.
												
#define gameStart 0						// defines a constant variable "gameStart" and assigns it the value 0
#define gamePlay 1						// defines a constant variable "gamePlay" and assigns it the value 1
#define gameEnd 2							// defines a constant variable "gameEnd" and assigns it the value 2

//#define animPercentage 	skill21		// "skills" are variables that Gamestudio automatically creates for each game entity.
//#define animCycle 		skill22		// Each entity has 100 of these variables, generically named skill1, skill2, etc.
//#define eggLaid 			skill23		// I am renaming some of these variables here to make my code easier to read.
//#define velocity 			skill24
//#define state				skill25
//#define geoState			skill26


////	SOUNDS	//

//SOUND* plopSound  = "plop.wav";					// defines a pointer to a sound file which we can use to play the sound later.
//SOUND* splatSound = "splat.wav";
//SOUND* chickenSound = "chicken.wav";
//SOUND* backgroundSound = "background.wav";
//SOUND* whooshSound = "whoosh2.wav";


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

