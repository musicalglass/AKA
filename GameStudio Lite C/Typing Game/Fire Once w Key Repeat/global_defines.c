// Variables //

var LetterPressedAscii = 1 ; 
var counter = 0 ; 
var numberOfLetters = 10 ; 
var level_state = 0 ; 
var currentEntHandle = 0 ;

var randomFromString = 0 ;  // Empty variable for storing random number
var truncateEnd = 0 ; 
var clipBeginning = 0 ; 

STRING* sourceString = "" ; // String to store sequence of letters
STRING* KeyboardInput = "" ; // Empty String to store keyboard input
STRING* myLetter = "" ; // temp
STRING* modelsString = "Models/" ; 


// INIT //

function game_init()
{
level_load("") ; // Load an empty level
wait(1);

//camera.x = -40 ; 
//camera.z = 160 ; 

level_state = 1 ; 
 warn_level     = 0 ; 
//tex_share      = 1 ; // map entities share their textures
 sky_color.red = 10 ; //remove these 3 lines if you use a sky or skycube
 sky_color.green = 10 ; 
 sky_color.blue = 10 ; 
 
// return;
} // end game_init()


// Defines //
#define turn skill4
