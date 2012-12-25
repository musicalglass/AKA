// PaddleMoveKeys.c
// Move the paddle using arrow keys

#include <acknex.h>
#include <default.c>


PANEL* background_pan = // the background panel
{
	bmap = "Background.pcx";
	layer = 1;
	flags = VISIBLE;
}

PANEL* debugPanel = // Show paddle's position
{
	layer = 3;
  	digits( 50,50,3,Arial#24,1,My_Paddle.pos_x ); 
  	flags = VISIBLE ;
}

PANEL* My_Paddle = {
	bmap = "my_paddle.pcx";
	layer = 2;
	pos_x = 375;
	pos_y = 500;
	flags = VISIBLE;
}

function update_paddle()
{
      if ( key_cul ) My_Paddle.pos_x-- ; // If Left Arrow key is pressed, subtract 1 from the X Position
      if ( key_cur ) My_Paddle.pos_x++ ; // If Right Arrow key is pressed, add 1 to the X Position
      
      if ( My_Paddle.pos_x < 34 ) My_Paddle.pos_x = 34 ;  // If it goes too far left, set it back
      if ( My_Paddle.pos_x > 670 ) My_Paddle.pos_x = 670 ; // If it goes too far right, set it back
}


function main()
{
	
   video_mode = 7 ; 
   
	wait (1) ;
	
	video_window( NULL, NULL, 0, "Move Paddle with Arrow Keys" ) ; 
	
   
	while ( 1 ) 
	{
		update_paddle() ; 
     
     wait ( 1 ) ; 
   }

}
