// VARIABLES //

var level_state = 0 ; 
var LetterPressedAscii = 1 ; 

STRING* sourceString = "" ; // String to store sequence of letters
STRING* KeyboardInput = "" ; // Empty String to store keyboard input

// DEFINES //

#define ascii skill1
#define previous skill2
#define eliminated skill3


// PANELS //

FONT* gamefont = "Arial #16b"; // Arial, size 16, bold 

PANEL* debugPanel =
{
  	digits(0,0,"X = %0.f",*,1,camera.x ) ; 
  	digits(0,10,"Y = %0.f",*,1,camera.y ) ; 
  	digits(0,20,"Z = %0.f",*,1,camera.z ) ; 
  	digits(0,30,"pan = %0.f",*,1,camera.pan ) ; 
  	digits(0,40,"tilt = %0.f",*,1,camera.tilt ) ;
  	digits(0,50,"roll = %0.f",*,1,camera.roll ) ;
  	//	flags = VISIBLE;
}


// INIT //

function game_init()
{
level_load("") ; // Load an empty level
wait(1);

camera.x = -1000 ; 
camera.z = 160 ; 

level_state = 1 ; 
 warn_level     = 0 ; 
tex_share      = 1 ; // map entities share their textures
 sky_color.red = 10 ; //remove these 3 lines if you use a sky or skycube
 sky_color.green = 10 ; 
 sky_color.blue = 10 ; 
 
// return;
} // end game_init()
