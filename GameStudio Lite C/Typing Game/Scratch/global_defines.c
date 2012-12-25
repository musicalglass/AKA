// Variables //

var LetterPressedAscii = 1 ; 
var oneShot = 1 ; 
var counter = 0 ; 
var numberOfLetters = 30 ; 
var level_state = 0 ; 
var letterQueue = 0 ; 
var elapsedTime = 0 ; // To store your reaction time
var tillNextLetter = 600 ; // Amount of time till next letter is created
var myLevel = 1 ; 

var randomFromString = 0 ;  // Empty variable for storing random number

STRING* sourceString = "" ; // String to store sequence of letters
STRING* KeyboardInput = "" ; // Empty String to store keyboard input
STRING* myLetter = "" ; // temp
STRING* modelsString = "Models/" ; 


// INIT //

function game_init()
{
level_load("") ; // Load an empty level
wait(1);

level_state = 1 ; 
 warn_level     = 0 ; 
 sky_color.red = 10 ; //remove these 3 lines if you use a sky or skycube
 sky_color.green = 10 ; 
 sky_color.blue = 10 ; 
} // end game_init()


// Panels //

PANEL* debugPanel =
{
	digits(35, 24, "randomFromString = %0.f", Arial#20b, 1, randomFromString);
	digits(35, 36, "elapsedTime = %0.f", Arial#20b, 1, elapsedTime);

	flags = VISIBLE;
}

PANEL* splashText =
{
	digits(35, 24, "First we'l start with the F & J keys", Arial#20b, 1, 0);
	digits(35, 36, "Pess any key", Arial#20b, 1, 0);


}

// Defines //
#define turn skill1
#define ascii skill2
