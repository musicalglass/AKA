
///////////////////////////////////////////////////////////////////////////////////////////////
//
//	This page contains all the functions that define the functionality of the eggs in the game:
//
//	Falling eggs accelerate downwards until either clicked on or until they hit the ground.
//	If clicked on, the egg is deleted, and an egg appears in the egg carton.
//	If the egg hits the ground, it morphs into the splattered shape and ceases to be clickable.
// 
// Eggs in the carton become visible one at a time as the player clicks on falling eggs. 
//
///////////////////////////////////////////////////////////////////////////////////////////////


void eventClicked()							// This function defines what happens when the player clicks on an egg:
{
	if (eggsInCarton < 6)					// check if there are less than 6 eggs in the carton. If there are 6 eggs the nothing will happen. 
	{												// 
		my.state = 1;							// change the eggs's "state" variable to signal that it is about to be deleted
		eggsInCarton += 1;					// increase the "eggsInCarton" variable. This causes the next egg in the carton to become visible (see eggIncarton()below)
		snd_play(plopSound, 70, 0);		// play a sound

		wait(1);									// wait for one tick. It is essential to do this so all functionality associated with this entity can cease
		ptr_remove(me);						// delete the egg
	}

}


void egg()												// This function defines the behaviour of the falling egg.
{
	my.emask |= ENABLE_CLICK;						// makes the egg clickable
	my.event = eventClicked;						// defines which function should be called if the egg is clicked on
	
	my.state = 0;										// initializes the egg's "state" variable to 0

	while(1)												// start the egg's looping function. The following commands will be executed every tick in the game.
	{
		
		if (my.state == 0)							// checks what the egg's state is. If it is about to be deleted the rest of the function is skipped.
		{
			if (my.z > 5)								// checks whether the egg is about to hit the ground. If no, the egg keeps falling:
			{
				my.velocity += .4 * time_step;			// increases the egg's velocity by .05, modulated by the game's framerate
				my.z -= my.velocity;					// subtracts the resulting value from the egg's current position in z (z is up in game space)
				
			}
			else if (my.geoState == 0)				// If we have hit the ground, we need to morph the egg into the splat model. We only need to do this once.
			{												// the egg's "geoState" variable keeps track of whether we have already morphed it or not. If not:

				ent_morph(me,"eggSplat.mdl");		// "morph" the egg (exchange its associated model with a different model)
				my.z = 5;								// set its position in z to 5 so it sits on the floor;
				my.x += random(30);					// jiggle its sideways position randomly, so not all eggs from one hen end up in exactly the same spot
				my.y += random(30);					// 
				my.geoState = 1;						// set the geoState variable so we don't do this again and again
				my.emask &= ~ENABLE_CLICK;			// make the splattered egg not clickable
				eggsLost += 1;							// add 1 to the eggsLost variable which keeps track of how many eggs the player has missed
				snd_play(splatSound, 100, 0);		// play a sound of an egg breaking
			}
		}
		
	wait(1);												// wait for the other entities to get updated so we don't crash the game.
	}
	
	
}


void eggIncarton()							// defines the behaviour of the eggs in the carton
{
	while(1)										// starts a looping function that is run every game tick
	{
		if (eggsInCarton < my.skill1)		// "skill1" contains the egg's number.  I assigned this number in the level editor, WED. 
		{											// If the egg's number is larger than the eggsInCarton variable, the egg is invisible.
			set(my, INVISIBLE);
		}
		else										// Otherwise (if the egg's number is equal or larger than eggsInCarton) the egg is visible.
		{
			reset(my, INVISIBLE);
		}
		wait(1);									// wait for the other entities to get updated so we don't crash the game.
	}
}
