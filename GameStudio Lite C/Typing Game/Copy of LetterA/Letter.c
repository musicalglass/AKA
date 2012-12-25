
void letter()
{
	my.x = 2000 ;
	
	while(1)
	{
		my.frame = my.ascii - 96;
		my.scale_x = .7;
		my.scale_y = .7;

	
		if (my.eliminated == 0) // If letter still exists...
		{
			my.x -= 100 * time_step;   // Move letter toward the camera in X   
	

			if ( my.previous != 0 )	// If not first letter in sequence
			{
				you = ptr_for_handle( my.previous ) ; // point to the letter before me
			// If the letter before me is gone, and my number matches the keyboard input...
				if ( (your.eliminated == 1) && (LetterPressedAscii == my.ascii) )
				{
					set(my, INVISIBLE) ; // "delete" me
					LetterPressedAscii = 0 ; // reset the keyboard input
					my.eliminated = 1 ; // Mark me down as toast
				}
			}
			
			else	if (LetterPressedAscii == my.ascii)	// If first letter in sequence
				{ // Don't bother checking if anybody's before me, but do the rest the same
					set(my, INVISIBLE);
					LetterPressedAscii = 0;	
					my.eliminated = 1;
				}
		}

//testVar1 = LetterPressedAscii;
	
	wait(1);
	}
}


void createLetters()
{	
	var letterAscii ; // For storing ASCII value of each letter
	var letterY ; // For repositioning letters onscreen
	var letterZ ; 
	var entHandle = 0 ; // For keeping track of who's first in line
	var stringCount = 0 ; // For keeping track of how many letters to eliminate

	
	str_cpy( sourceString,"dillinger" ) ; // Load sequence of letters into sourceString

	stringCount = str_len( sourceString ) ; // Store the length of the String in stringCount
	
//	str_cpy( myString,sourceString ) ; 
//	str_trunc(myString, (str_len(myString) - 1)) ;  // now myString == 1st Letter
		
	letterAscii = str_to_asc(sourceString); 
	str_clip(sourceString,1);
		
	while ( stringCount != 0 ) // Continue until the string is empty
	{
// Assign screen position of letters so they appear in same pattern as keyboard layout QWERTY...
		switch (letterAscii)
		{
			case 97: // a
				letterY = 270 ; 
				letterZ = 230 ; 
				break ; 

			case 98: // b
				letterY = 0;
				letterZ = 160;
				break;

			case 99: // c
				letterY = 120;
				letterZ = 160;
				break;

			case 100: // d
				letterY = 150;
				letterZ = 230;
				break;
	
			case 101: // e
				letterY = 146;
				letterZ = 298;
				break;

			case 102: // f
				letterY = 92;
				letterZ = 230;
				break;
	
			case 103: // g
				letterY = -30;
				letterZ = 230;
				break;
	
			case 104: // h
				letterY = 30;
				letterZ = 230;
				break;
	
			case 105: // i
				letterY = -156;
				letterZ = 298;
				break;

			case 106: // j
				letterY = -90;
				letterZ = 230;
				break;

			case 107: // k
				letterY = -150;
				letterZ = 230;
				break;

			case 108: // l
				letterY = -210;
				letterZ = 230;
				break;

			case 109: // m
				letterY = -124;
				letterZ = 159;
				break;

			case 110: // n
				letterY = -56;
				letterZ = 160;
				break;

			case 111: // o
				letterY = -210;
				letterZ = 300;
				break;

			case 112: // p
				letterY = -266;
				letterZ = 300;
				break;

			case 113: // q
				letterY = 270;
				letterZ = 300;
				break;

			case 114: // r
				letterY = 84;
				letterZ = 300;
				break;

			case 115: // s
				letterY = 212;
				letterZ = 230;
				break;

			case 116: // t
				letterY = 28;
				letterZ = 298;
				break;

			case 117: // u
				letterY = -100;
				letterZ = 300;
				break;

			case 118: // v
				letterY = 60;
				letterZ = 160;
				break;

			case 119: // w
				letterY = 206;
				letterZ = 300;
				break;

			case 120: // x
				letterY = 180;
				letterZ = 160;
				break;

			case 121: // y
				letterY = -40;
				letterZ = 300;
				break;

			case 122: // z
				letterY = 242;
				letterZ = 160;
				break;

			}

		wait( 400 ) ; 
		me = ent_create("../Letters+26.tga", vector(0,letterY,letterZ), letter) ; // create a new letter entity and start its function
		my.ascii = letterAscii;		// stores the letter's ascii value
		my.previous = entHandle;		// inherits the previous letter's handle
		my.eliminated = 0;
		my.ambient = 100 ; 
		reset(my,INVISIBLE);
		entHandle = handle(me) ; // save the current letter's handle so it can be assigned to the next letter

		letterAscii = str_to_asc(sourceString); 
		str_clip(sourceString,1);
		}

	}
