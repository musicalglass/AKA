#include <acknex.h>
#include <default.c>

#include "global_defines.c"
#include "Letter.c"

function sceneManager() 
{
	createLetters() ; 
	
	while(1) // While game is running,... 
	{	// ..keep checking for keyboard input
		LetterPressedAscii = inchar( KeyboardInput ) ; // Convert input into ASCII and store in myVariable
	wait(1);		
	}  
}


function main()
{
video_set( 1024, 768, 32, 2 ) ; 

level_state = 0; 

game_init() ; 
 	
sceneManager() ; 

 // MAIN GAME LOOP //
 
	while(1)
	{
		if(level_state == 0)
		{
			// pause the game
			freeze_mode = 1;
		}
		else
		{
			freeze_mode = 0;
		}
	
	wait(1);
	}
}
