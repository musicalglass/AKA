
#include <acknex.h>
#include <default.c>;

#include "global_defines.c";
#include "Letter.c";
#include "cam.c";
#include "scenemanager.c";



function main()
{
	 
video_set(1024, 768, 32, 2); // don't use mode, it's broken

level_state = 0; 
   // display debug panel
	debugPanel.pos_x = 10;
	debugPanel.pos_y = 10;
	debugPanel.flags |= VISIBLE;
 	

level_load("main.wmb");
wait(2);
level_state = 1;


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