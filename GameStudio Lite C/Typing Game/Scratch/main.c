#include <acknex.h>
#include <default.c>

#include "global_defines.c"

action updateLetter()
{
	my.ascii = str_to_asc( myLetter ) ; 
	my.pan = 180 ; 
	my.turn = counter ; // Assign a queue number to each letter

	counter++ ; // Keep track of how many letters created so far
	
	while ( me ) // Continue Loop as long as Letter exists in the game
	{
		if ( !key_any ) 
		{
			oneShot = 1 ;
		}

		if ( ( my.ascii == LetterPressedAscii ) // If my Letter matches the keyboard input...
			&& ( my.turn == letterQueue ) // and it's my turn...
			&& oneShot ) // and I haven't already fired a shot
		{
			ent_remove( me ) ; // I be toast
			elapsedTime = timer(); // Record how long it took to delete from the time it was created
	 		letterQueue++ ; // Advance the queue number to the next letter
	 		oneShot = 0 ; // Reload for another shot
	 		LetterPressedAscii = 0 ; // Reset the keyboard for another try
		}
		else // Otherwise, if it wasn't time to get deleted...
		{
			my.x -= 1 * time_step ; // advance the letter's position
		}

	wait(1);
	} // end While Loop
	
} // end Action updateLetter

void createLetters()
{	
	random_seed( 0 ) ; // Initialize the random number
	str_cpy( sourceString,"dfjk" ) ; // Load sequence of letters into sourceString
	//ReactionTimes[ str_len( sourceString ) + 1 ] ; // An Array to store all the reaction times
	
	// Keep drawing from the list until specified total is reached
	while ( counter != numberOfLetters ) 
	{
	// Update randomFromString to a Random Number between 1 and number of letters in String 
	randomFromString = integer( random( str_len( sourceString ) ) ) + 1 ;	
	
	str_cpy( myLetter,sourceString ) ; // Copy the whole sourceString to myLetter
	
	if ( randomFromString <= 4 ) 
	{
		// Subtract Random number from the total in String
		str_trunc( myLetter, str_len( myLetter ) - randomFromString ) ; // Trim the difference from the end of String
	}

	if ( randomFromString >= 1 ) 
	{
		// All the numbers up until the Random number, then leave one.
		// Trim the beginning of the String. There should now be only 1 Letter in myLetter
		str_clip( myLetter, randomFromString - 1 ) ; 
	}

str_cat( modelsString,myLetter ) ; // Append Letter to the end of Path "Models/"
str_cat( modelsString,".mdl" ) ; // Append file type extension to end of Path

ent_create( modelsString, vector(200,0,0), updateLetter ) ; 
timer(); // Set the timer starting from the moment the model was created
str_cpy( modelsString,"Models/" ) ; // Reset the Path for the next letter 

 // wait() is set with a Variable so it can be adjusted according to your reaction time
	wait( tillNextLetter ) ;
	}
	//myLevel++;
}


function sceneManager() 
{
 
	
	while(1) // While game is running,... 
	{
		// ..keep checking for keyboard input
		LetterPressedAscii = inchar( KeyboardInput ) ; // Convert input into ASCII and store in myVariable
	wait(1);		
	}  
}

//function gameManager() 
//{
//	switch (myLevel)	
//	{
//		case 1:
//			str_cpy( sourceString,"fj" ) ; // Load sequence of letters into sourceString
//			splashText.VISIBLE = ON ;
//			break;
//	
//		case 2:
//			str_cpy( sourceString,"dfjk" ) ; // Load sequence of letters into sourceString
//			splashText.VISIBLE = ON ;
//			break;
//	
//	}
}


function main()
{
video_set( 1024, 768, 32, 2 ) ; 

level_state = 0 ; 

game_init() ; 
 	
createLetters() ;

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
