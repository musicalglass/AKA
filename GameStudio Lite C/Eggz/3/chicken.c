///////////////////////////////////////////////////////////////////////////////////////////////
//
//	This page contains all the functions that define the behaviour of the chickens in the game:
//
//	Chickens randomly play one of three animations: a breathe loop, a breathe loop with a blink,
//	or the lay egg animation.
//	If they choose the lay egg animation, a sound is played and an egg is created about halfway through
// the animation.
//  
///////////////////////////////////////////////////////////////////////////////////////////////


void chicken()												
{
	my.animPercentage = integer(random(100));		
	
	while(1)													
	{
	
		// cycle through the animation
	
		my.animPercentage += 2 * time_step;			


		if (my.animPercentage > 100) 					
		{														
			
			my.animPercentage -= 100;					
			my.eggLaid = 0;								
				
//																
			my.animCycle = integer(random(3));		
			
			if (my.animCycle == 2)						
			{
				snd_play(chickenSound, 100, 0);		
			}
		}
		
		switch (my.animCycle)														
		{
			case 0:																		
				ent_animate(me,"breathe",my.animPercentage,ANM_CYCLE);
				break;
				
			case 1:																		
				ent_animate(me,"blink",my.animPercentage,ANM_CYCLE);
				break;
				
			case 2:																		
				if ((my.animPercentage > 70) && (my.eggLaid == 0))			
				{
					
					ent_create ("egg.mdl", vector (my.x - 30, my.y, my.z - 50), egg);		
					my.eggLaid = 1;																			
				}
				ent_animate(me,"layEgg",my.animPercentage,ANM_CYCLE);		
				break;
		}
		
		wait(1);												
	}
}