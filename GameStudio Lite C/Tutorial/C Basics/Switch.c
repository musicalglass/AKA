var gameState = 1 ; 

void main()
{
	
	while(1) 
	{
		if ( key_1 ) gameState = 1 ; 
		if ( key_2 ) gameState = 2 ; 
		if ( key_3 ) gameState = 3 ; 
		
		switch ( gameState ) 
		{
			case 1:
			vec_set ( screen_color, vector( 255, 100, 100 ) ) ; 
			break ; 
			
			case 2:
			vec_set ( screen_color, vector( 0, 255, 128 ) ) ; 
			break ; 
			
			case 3:
			vec_set ( screen_color, vector( 128, 0, 256 ) ) ; 
			break ; 
			
		}
		
	wait(1) ; 
	}
}