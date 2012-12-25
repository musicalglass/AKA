//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	EGGZ
//
// Art and Programming by Marion Gothier
//
// http://mariongothier.blogspot.com
//
//	Sound by Michel Marchant Roman (www.mich3d.com), SlykMrByches, 
// gelo_papas, Betty Hermann und Christian Frisch (www.ostnordost.net),
// downloaded from www.freesound.org and used under the Creative Commons Sampling Plus 1.0 license 
// (http://creativecommons.org/licenses/sampling+/1.0/ )
//
//
// EGGZ was written in 24 hours as an experiment to see whether one can write 
// a reasonably fun game in one day. It is also a tutorial of sorts, with extensive comments in the code.
// 
// This work is distributed under the Academic Free License ("AFL") v. 3.0
// (http://www.opensource.org/licenses/afl-3.0.php). You are free to share, copy,
// transmit, and adapt this work as long as you credit me with my full name and 
// the link above. Please note that the sound used is licensed separately as
// described above.
//  
///////////////////////////////////////////////////////////////////////////////////////////////////////////////


#include <acknex.h>
#include <default.c>

#include "definitions.c";
#include "gameManager.c";
#include "Shoot.c";


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