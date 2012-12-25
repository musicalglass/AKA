//////////////////////////////////////////////////////////////////////////////
// Pong demo from AUM magazine #26
// Control the right paddle with [Up] / [Down]
// Control the left paddle with [W] / [S]
//////////////////////////////////////////////////////////////////////////////
#include <acknex.h>

FONT* digital_font = "digital.pcx"; 

var left_score = 0;
var right_score = 0;

PANEL* main_pan = // the main panel
{
	bmap = "main.pcx";
	layer = 10;
	digits(330, 40, 2, digital_font, 1, left_score); 
	digits(395, 40, 2, digital_font, 1, right_score); 
	flags = VISIBLE;
}

PANEL* left_pan = {
	bmap = "paddle.pcx";
	layer = 11;
	pos_x = 60;
	pos_y = 250;
	flags = VISIBLE;
}

PANEL* right_pan = {
	bmap = "paddle.pcx";
	layer = 11;
	pos_x = 715;
	pos_y = 250;
	flags = VISIBLE;
}

PANEL* ball_pan = {
	bmap = "ball.pcx";
	layer = 11;
	pos_x = 504;
	pos_y = 344;
	flags = VISIBLE;
}	

SOUND* beep1_wav = "beep1.wav";
SOUND* beep2_wav = "beep2.wav";
SOUND* goal_wav = "goal.ogg";

//////////////////////////////////////////////////////////////////////////////

#define COMPUTER 0
#define USER 1

VECTOR ball_speed;
var mode_left = COMPUTER;
var mode_right = COMPUTER;

TEXT* tName = { string("Computer","User"); }
STRING* sTitle = "";   // the window title

//////////////////////////////////////////////////////////////////////////////
 
function update_ball()
{
	ball_pan.pos_x += 7*ball_speed.x*time_step;
	ball_pan.pos_y += 7*ball_speed.y*time_step;
	
// check if hit a border or a paddle	
	if (ball_pan.pos_y > 555)      // lower border
	{
		ball_speed.y = -3 - random(3);
		snd_play (beep1_wav, 50, 0);
	}
	else if (ball_pan.pos_y < 32)   // upper border
	{
		ball_speed.y = 3 + random(3);
		snd_play (beep1_wav, 50, 0);
	}

	if (ball_pan.pos_x > 740) // left player scores!
	{
		snd_play (goal_wav, 70, 0);
		ball_speed.x = -3 - random(3);
		left_score += 1;    // register a goal
		ball_pan.pos_x = 740;   // prevent registering twice 
	}
	else if (ball_pan.pos_x < 40) // right player scores!
	{
		snd_play (goal_wav, 70, 0);
		ball_speed.x = 3 + random(3);
		right_score += 1; 
		ball_pan.pos_x = 40; 
	}

	if ((ball_pan.pos_y > left_pan.pos_y - 12) && (ball_pan.pos_y < left_pan.pos_y + 96) && (ball_pan.pos_x > 60) && (ball_pan.pos_x < 72))
	{
	// the left player has blocked the ball
		snd_play (beep2_wav, 70, 0);
		ball_speed.x = 3 + random(3);
		ball_speed.y = 3 - random(3);
	}
	else if ((ball_pan.pos_y > right_pan.pos_y - 12) && (ball_pan.pos_y < right_pan.pos_y + 96) && (ball_pan.pos_x > 703) && (ball_pan.pos_x < 715))
	{
	// the right player has blocked the ball
		snd_play (beep2_wav, 70, 0);
		ball_speed.x = -3 - random(3);
		ball_speed.y = 3 - random(3);
	}		
}

function update_paddle(var *paddle_pos,var paddle_mode,var key)
{
   if (COMPUTER == paddle_mode) {
		if ((ball_pan.pos_y > 100) && (ball_pan.pos_y < 490)) // the computer makes mistakes too
			*paddle_pos = ball_pan.pos_y - 42;
	}
	else if (USER == paddle_mode) {
      *paddle_pos += 30*time_step*key;   	   
		*paddle_pos = clamp(*paddle_pos,35,470);
	}
	
}

function main()
{
   video_mode = 7; // 800x600
	wait (1);
   
   randomize();
	ball_speed.x = 3 - 6 * (random(6) % 2); // -3 or 3, random ball direction at game start
	ball_speed.y = 3 - random(6); // -3...3, random vertical speed at game start
	
	while ((right_score != 15) && (left_score != 15))
	{
      if (key_esc) { sys_exit(NULL); }
      
// switch to user mode if a paddle key is pressed      
      if (key_w || key_s) mode_left = USER;
      if (key_cuu || key_cud) mode_right = USER;

// update paddles and ball, and count scores
      update_ball();
      update_paddle(left_pan.pos_y,mode_left,key_s-key_w);
      update_paddle(right_pan.pos_y,mode_right,key_cud-key_cuu);

// compose the sTitle string
      str_cpy(sTitle,"Pong Demo - ");
      str_cat(sTitle,(tName.pstring)[mode_left]);
      str_cat(sTitle," vs. ");
      str_cat(sTitle,(tName.pstring)[mode_right]);
      video_window(NULL,NULL,0,sTitle);

		wait (1);
	}
}