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


void chicken()												// This function defines the chicken's behaviour
{
	my.animPercentage = integer(random(100));		// set the frame the animation is started on to a random value so the chickens are not in synch
	
	while(1)													// start the chicken's looping function. The following commands will be executed every tick in the game.
	{
	
		// cycle through the animation
	
		my.animPercentage += 2 * time_step;			// animPercentage determines how far through the animation we are (think of it as frame number)	
//																// It is increased here by a small amount that is multiplied by the speed the game runs at.
//																//	This ensures that the animation will run at the same speed for all players no matter how fast their computer is.

		if (my.animPercentage > 100) 					// when animPercentage reaches 100 we have played all the way through the animation. If this is the case
		{														// we need to reset some variables and choose a new animation to play:
			
			my.animPercentage -= 100;					// reset animPercentage
			my.eggLaid = 0;								// reset the eggLaid variable (this is a marker that prevents the chicken from laying more than 1 egg per animation)
				
//																// choose which animation to play next:
			my.animCycle = integer(random(3));		// generate a random number and assign it to the variable animCycle
			
			if (my.animCycle == 2)						// if animCycle is 2 the chicken will lay an egg, and 
			{
				snd_play(chickenSound, 100, 0);		// we need to start the egg laying sound now.
			}
		}
		
		switch (my.animCycle)														// this is where the animation actually gets played:
		{
			case 0:																		// if animCycle is 0 play the breathe animation
				ent_animate(me,"breathe",my.animPercentage,ANM_CYCLE);
				break;
				
			case 1:																		// if animCycle is 1 play the breathe and blink animation
				ent_animate(me,"blink",my.animPercentage,ANM_CYCLE);
				break;
				
			case 2:																		// if animCycle is 2:
				if ((my.animPercentage > 70) && (my.eggLaid == 0))			// are we more than 70% through the animation and we haven't made an egg?
				{
					
					ent_create ("egg.mdl", vector (my.x - 30, my.y, my.z - 50), egg);		// create an egg entity slightly behind and below the chicken
					my.eggLaid = 1;																		// set the eggLaid variable to 1 so we don't do this every tick from now on	
				}
				ent_animate(me,"layEgg",my.animPercentage,ANM_CYCLE);		// play the layEgg animation
				break;
		}
		
		wait(1);												// wait for the other entities to get updated so we don't crash the game.
	}
}