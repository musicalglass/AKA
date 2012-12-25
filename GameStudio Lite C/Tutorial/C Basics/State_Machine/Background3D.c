var gameState = 1 ; 

BMAP* SplashScreen = "Images/SplashScreen.pcx" ; 
//BMAP* Space = "Images/SpaceBackground.pcx" ; 
//BMAP* GameOver = "Images/GameOver.pcx" ; 

//PANEL* Background = 
//{
//	bmap = SplashScreen ; 
//	layer = 0 ; 
//	flags = VISIBLE ; 
//}

//SKY clouds
//{
//  type = <skyblue+2.pcx>; 
//  layer = 3;	
//  scale_x = 0.25;	
//  speed_u = 1.5;
//  speed_v = -1.0;
//  tilt = -10;	
//  flags = dome,visible;
//} 

ENTITY* Background =
{
  type = "Images/SplashScreen.tga" ;	// Picture for the scenemap
// 	layer = 0 ;		// cover Sky-Entities on lower layers
// 	scale_x = 0.25; // field of view of 90 degrees(360 * 0.25 = 90)
// 	tilt = -10;		// 10 degrees down
// 	flags = OVERLAY; 
 	flags = SKY | SCENE | VISIBLE;	
} 

void main()
{
	video_mode = 7 ; 
	level_load( "" ) ; 
	wait(1) ;
	ent_create ( "Models/earth.mdl", NULL, NULL ) ; 
//	your.layer = 1 ; 
	vec_set (sky_color, vector(0,0,0) ) ;
	
	while(1) 
	{
		wait(1) ;
		
		if ( key_1 ) gameState = 1 ; 
		if ( key_2 ) gameState = 2 ; 
		if ( key_3 ) gameState = 3 ; 
		
		switch ( gameState ) 
		{
			case 1:
			Background.type = "Images/SplashScreen.tga" ; 
			Background.flags = VISIBLE ; 
			break ; 
			
			case 2:
			Background.flags &= ~VISIBLE ; 
			break ; 
			
			case 3:
			Background.type = "Images/GameOver.pcx" ; 
			Background.flags = VISIBLE ; 
			break ; 
		}
 
	}
}