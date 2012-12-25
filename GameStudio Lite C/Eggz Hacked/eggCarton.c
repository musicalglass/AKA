
///////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	This page contains all the functions that define the behaviour of the eggcarton in the game:
//
// While the carton contains less than 6 eggs, it just sits there and plays a short animation that keeps its lid open.
//
// If the carton contains 6 eggs it becomes clickable. When clicked on its lid closes and it moves to the right out of 
//	the frame, then pops back to its original position empty.
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////


void eventCartonClicked()							// This function defines what happens when the player clicks on an eggcarton:
{
	if (eggsInCarton == 6)							// Check to see if there are six eggs in the carton. If not, we skip the rest of the function.
	{
		my.state = 1;									// set the carton's "state" variable to 1. This determines the carton's behaviour in its main function below.
		my.animPercentage = 0;						// reset the animation variable to 0 so we will start the lid closing animation at the start
		cartonsShipped += 1;							// increase the cartons shipped variable which is displayed on the counter panel
		eggsShipped = cartonsShipped * 6;		// increase the eggsShipped variable for the final score
		snd_play(whooshSound, 100, 0);			// start the whoosh sound		
	}

}

void eggcarton()										// This function defines the carton's behaviour
{
	my.emask |= ENABLE_CLICK;						// make the carton clickable
	my.event = eventCartonClicked;				// defines which function should be called if the carton is clicked on
	
	my.state = 0;										// initializes the egg's "state" variable to 0
	my.material = greyMat;							// make the carton grey
		
	while(1)												// start the carton's looping function. The following commands will be executed every tick in the game.
	{
		
		
		switch (my.state)												// depending on the value of the carton's state variable the carton will do one of three things:
		{
			case 0:															// 1. sit there open and wait for eggs
			
				my.animPercentage += 2 * time_step;					// step forward through the animation	
				if (my.animPercentage > 100) 							// if done start a new cycle
				{
					my.animPercentage -= 100;	
				}
				ent_animate(me,"open",my.animPercentage,ANM_CYCLE);	// play the "open" animation
				break;
				
			case 1:															// 2. play the close lid animation
					
					if (my.animPercentage < 100) 						// we only want to play this animation once so we test whether we have played it to the end first
					{
						my.animPercentage += 30 * time_step;		// if not step through the animation
							
					}
					else														// if we have finished the close lid animation
					{
						my.state = 2;										// set the state variable to 2
					}
				ent_animate(me,"close",my.animPercentage,NULL);	// play the close lid animation
				break;
				
			case 2:															// 3. Move the carton to the right and then pop it back empty
			
				eggsInCarton = 0;											// reset eggsInCarton makes the eggs invisible
				if (my.y < 700)											// move to the right (in y)) until you are at y = 700
				{
					my.y += 60 * time_step;
				}
				else															// then pop back
				{
					my.y = 268;
					my.state = 0;
				}
				
				break;
				
		}

		wait(1);											// wait for the other entities to get updated so we don't crash the game.
	}
}





