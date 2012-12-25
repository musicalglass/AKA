


void letter()
{
	
	my.x = 2000;
	
	while(1)
	{
		my.frame = my.ascii - 96;
		my.scale_x = .5;
		my.scale_y = .5;

	
		if (my.eliminated == 0) 
		{
			my.x -= 100 * time_step;   // Move letter toward the camera in X   
	
		
			if (my.previous != 0)	// if not first letter in sequence
			{
				you = ptr_for_handle(my.previous);
			
				if ((LetterPressedAscii == my.ascii) && (your.eliminated == 1))
				{
					set(my, INVISIBLE);
					LetterPressedAscii = 0;

					my.eliminated = 1;
	
				}
			}
			
			else	if (LetterPressedAscii == my.ascii)	// if first letter in sequence
				{
					set(my, INVISIBLE);
					
					LetterPressedAscii = 0;	
					my.eliminated = 1;
				}
		}

testVar1 = LetterPressedAscii;
	
		wait(1);
	}
}




void createLetters()
{	
	var letterAscii;
	var letterY;
	var letterZ;
	var entHandle = 0;

	//str_cpy(sourceString,"qwertyuiopasdfghjklzxcvbnm^");
	
		str_cpy(sourceString,"dillinger^");
				letterAscii = str_to_asc(sourceString); 
				str_clip(sourceString,1);
		
		while (letterAscii != 94)
		{


			switch (letterAscii)	//temp code to be replaced with something elegant later
			{
				case asc_a:
					letterY = 270;
					letterZ = 230;
					break;
				
				case asc_b:
					letterY = 0;
					letterZ = 160;
					break;
					
				case asc_c:
					letterY = 120;
					letterZ = 160;
					break;
					
				case asc_d:
					letterY = 150;
					letterZ = 230;
					break;
					
				case asc_e:
					letterY = 146;
					letterZ = 298;
					break;
					
				case asc_f:
					letterY = 92;
					letterZ = 230;
					break;
					
				case asc_g:
					letterY = -30;
					letterZ = 230;
					break;
					
				case asc_h:
					letterY = 30;
					letterZ = 230;
					break;
					
				case asc_i:
					letterY = -156;
					letterZ = 298;
					break;
		
				case asc_j:
					letterY = -90;
					letterZ = 230;
					break;
					
				case asc_k:
					letterY = -150;
					letterZ = 230;
					break;

				case asc_l:
					letterY = -210;
					letterZ = 230;
					break;

				case asc_m:
					letterY = -124;
					letterZ = 159;
					break;

				case asc_n:
					letterY = -56;
					letterZ = 160;
					break;

				case asc_o:
					letterY = -210;
					letterZ = 300;
					break;

				case asc_p:
					letterY = -266;
					letterZ = 300;
					break;

				case asc_q:
					letterY = 270;
					letterZ = 300;
					break;

				case asc_r:
					letterY = 84;
					letterZ = 300;
					break;

				case asc_s:
					letterY = 212;
					letterZ = 230;
					break;

				case asc_t:
					letterY = 28;
					letterZ = 298;
					break;

				case asc_u:
					letterY = -100;
					letterZ = 300;
					break;

				case asc_v:
					letterY = 60;
					letterZ = 160;
					break;

				case asc_w:
					letterY = 206;
					letterZ = 300;
					break;

				case asc_x:
					letterY = 180;
					letterZ = 160;
					break;

				case asc_y:
					letterY = -40;
					letterZ = 300;
					break;

				case asc_z:
					letterY = 242;
					letterZ = 160;
					break;

			}
			

		me = ent_create("Letters+26.tga", vector(0,letterY,letterZ), letter);	// create a new letter entity and start its function
		my.ascii = letterAscii;		// stores the letter's ascii value
		my.previous = entHandle;		// stores the previous letter's handle
		my.eliminated = 0;
		reset(my,INVISIBLE);
		entHandle = handle(me);		// save the current letter's handle so it can be assigned to the next letter
		
		
			letterAscii = str_to_asc(sourceString); 
			str_clip(sourceString,1);
	
			wait(800);
		}
		

	}
