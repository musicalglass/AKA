var gameState = 1 ; 

BMAP* SplashScreen = "Images/SplashScreen.pcx" ; 
BMAP* Space = "Images/SpaceBackground.pcx" ; 
BMAP* GameOver = "Images/GameOver.pcx" ; 

PANEL* Background = 
{
	bmap = SplashScreen ; 
	flags = VISIBLE ; 
}

void main()
{
	video_mode = 7 ; 
	
	while(1) 
	{
		wait(1) ;
		
		if ( key_1 ) gameState = 1 ; 
		if ( key_2 ) gameState = 2 ; 
		if ( key_3 ) gameState = 3 ; 
		
		switch ( gameState ) 
		{
			case 1:
			Background.bmap = SplashScreen ; 
			break ; 
			
			case 2:
			Background.bmap = Space ; 
			break ; 
			
			case 3:
			Background.bmap = GameOver ; 
			break ; 
		}
 
	}
}