#include <acknex.h>
#include <default.c>

#include "global_defines.c"

var LetterPressedAscii = 1 ; 
var oneShot = 1 ; 

PANEL* debugPanel =
{
	digits(35, 24, "oneShot = %0.f", Arial#20b, 1, oneShot);
	digits(35, 36, "myLetter = %0.f", Arial#20b, 1, myLetter);

	flags = VISIBLE;
}


void fireOnce() 
{
	oneShot = 1 ;
} 

action updateLetter()
{
	my.pan = 180 ; 
	my.turn = counter ; // Assign a queue number to each letter

	counter++ ; // Keep track of how many letters created so far
	
	while ( me ) // Continue Loop as long as Letter exists in the game
	{
		if ( !key_any ) 
		{
			oneShot = 1 ;
		}
		
		if ( key_space && ( my.turn == currentEntHandle ) && oneShot )
		{
			ent_remove( me ) ; 
	 		currentEntHandle++ ; // Advance the queue number to the next letter
	 		oneShot = 0 ;
		}
		else
		my.x -= 1 * time_step ; // Advance the letter's position

	wait(1);
	} // end While Loop
	
} // end Action updateLetter

void createLetters()
{	
	random_seed( 0 ) ; // Initialize the random number
	str_cpy( sourceString,"dfjk" ) ; // Load sequence of letters into sourceString
	str_cpy( myLetter, sourceString  ) ; // Copy the whole sourceString to myLetter 

	while ( counter != numberOfLetters)
	{
	// Update randomFromString to a Random Number between 1 and 4 
	randomFromString = integer( random(4) ) + 1 ;	

	
	str_cpy( myLetter,sourceString ) ; // Copy the whole sourceString to myLetter
	
			if ( randomFromString <= 4 ) 
		{
			// Subtract Random number from the total in String
			truncateEnd = str_len( myLetter ) - randomFromString ; 
			str_trunc( myLetter, truncateEnd ) ; // Trim the difference from the end of String
		}

		if ( randomFromString >= 1 ) 
		{
			// All the numbers up until the Random number, then leave one
			clipBeginning = randomFromString - 1 ; 
			// Trim the beginning of the String. There should now be only 1 Letter in myLetter
			str_clip( myLetter, clipBeginning ) ; 
		}

str_cat( modelsString,myLetter ) ; // Append Letter to the end of Path "Models/"
str_cat( modelsString,".mdl" ) ; // Append file type extension to end of Path

// Some IF statements to deal with Semicolons and such

ent_create( modelsString, vector(200,0,0), updateLetter ) ; 
str_cpy( modelsString,"Models/" ) ; // Reset the Path for the next letter 
	
	wait(400);
	}
}


function sceneManager() 
{
	createLetters() ; 
	
	while(1) // While game is running,... 
	{
		// ..keep checking for keyboard input
		LetterPressedAscii = inchar( KeyboardInput ) ; // Convert input into ASCII and store in myVariable
	wait(1);		
	}  
}


function main()
{
video_set( 1024, 768, 32, 2 ) ; 

level_state = 0 ; 

game_init() ; 
 	
sceneManager() ; 


 // MAIN GAME LOOP //
 
	while(1)
	{
		if( level_state == 0 )
		{
			// pause the game
			freeze_mode = 1 ; 
		}
		else
		{
			freeze_mode = 0;
		}
	
	wait(1);
	}
}
