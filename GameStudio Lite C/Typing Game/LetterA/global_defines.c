// VARIABLES //

var level_state = 0 ; 
var LetterPressedAscii = 1 ; 

STRING* sourceString = "" ; // String to store sequence of letters
STRING* KeyboardInput = "" ; // Empty String to store keyboard input
STRING* myFontString = "" ; 

// DEFINES //

#define ascii skill1
#define previous skill2
#define eliminated skill3


// PANELS //

FONT* gamefont = "Arial #16b"; // Arial, size 16, bold 

PANEL* debugPanel =
{
  	digits(240,80,myFontString,Arial_48.bmp,1,0 ) ; // Display .bmp font
//  	digits(200,200,"ASCII value = %s",Arial#32b,1,myFontString ) ; // 
flags = VISIBLE;
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
