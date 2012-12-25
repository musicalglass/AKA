#define asc_a 97
#define asc_b 98
#define asc_c 99
#define asc_d 100
#define asc_e 101
#define asc_f 102
#define asc_g 103
#define asc_h 104
#define asc_i 105
#define asc_j 106
#define asc_k 107
#define asc_l 108
#define asc_m 109
#define asc_n 110
#define asc_o 111
#define asc_p 112
#define asc_q 113
#define asc_r 114
#define asc_s 115
#define asc_t 116
#define asc_u 117
#define asc_v 118
#define asc_w 119
#define asc_x 120
#define asc_y 121
#define asc_z 122

var LetterPressedAscii = 1;
 STRING* KeyboardInput = " ";
 
#define ascii skill1
#define previous skill2
#define eliminated skill3


// PANELS //

FONT* gamefont = "Arial #16b"; // Arial, size 10, bold 
PANEL* debugPanel =
{
  
  	digits(0,0,3.3,*,1,testVar); 
  	digits(0,10,3.3,*,1,testVar1); 
  	digits(0,20,3.3,*,1,testVar2); 
  	digits(0,30,3.3,*,1,testVar3); 
  	digits(0,40,3.3,*,1,testVar4);

}

STRING* sourceString = "test";

TEXT* test_txt =
{
	font = gamefont;
	layer = 1;
	pos_x = 10;
	pos_y = 80;
	
	string (sourceString);
	flags = VISIBLE;
}

char* test_str1 = "test";

TEXT* test_txt1 =
{
	font = gamefont;
	layer = 1;
	pos_x = 10;
	pos_y = 100;
	
	string (KeyboardInput);
	flags = VISIBLE;
}

// INIT //

function game_init()
{
 warn_level     = 2;	
 tex_share      = 1;	// map entities share their textures
 sky_color.red = 10;  //remove these 3 lines if you use a sky or skycube
 sky_color.green = 10;
 sky_color.blue = 10;
 return;
} // end game_init()

// DEFINES //

STRING* level_str = "main.wmb";
var	level_state = 0;


//// state of the level


// VARIABLES //
var deleteA = 0;

var testVar = 0; // FOR TESTING
var testVar1 = 0; // FOR TESTING
var testVar2 = 0; // FOR TESTING
var testVar3 = 0; // FOR TESTING
var testVar4 = 0; // FOR TESTING
 
 // levels //
 
 var currentLevel = 1;
var   temp;
 


//camera //

var camera_dist = 550; //starting distance from camera to player..used for zoom
var camera_dist_min = 200; //minimum distance allowed..used for zoom
var camera_dist_max = 1000;  //max distance allowed...used for zoom
var orbit_camera_dist =0; //current distance from player
var orbit_camera_pan =0;	//current pan of camera
var orbit_camera_tilt = 4;	//current tilt of camera
var char_eye_height = 50; //Z offset from entities origin..good for calculating eye height
VECTOR* cam_centre = {x=0;y=0;z=20;} 
VECTOR* cam_pos = {x=0;y=0;z=0;} 
var mouse_sensitivity_i = 8;  //pan sensitivity
var mouse_sensitivity_zoom_i = 20;  //sensitivity for zooming
var mouse_invert_pan_i = 1;  //invert for pan -  range: -1 or 1
var mouse_invert_tilt_i = 1; //invert for tilt - range: -1 or 1
var object_rotate_i = 250; //sensitivity for left click entity panning
var orbit_min_tilt = 10; //minimum angle for camera tilt
var orbit_max_tilt = 45; //max angle for cam tilt
var move_at_edges = 1; //range 0 or 1; 1 = view will within boundaries if cursor touches edges of screen; 0 = no movement
var min_bounds_x = -1500; //minimum X level boundary
var max_bounds_x = 1500;  //maximum X level boundary
var min_bounds_y = -1500; //min Y level boundary
var max_bounds_y = 1500;  //max Y level boundary
var smoothing = 0; //gradually move to mouse_to_level target if > 0....range: 0-1; 0 turns off


var screenSizeX = 1024;	//temporarily hardcoded until I can figure out why this isn't working in playerinput
var screenSizeY = 768;


void CheckAscii();
