// SpriteMove.c
// Make Sprite Move 

#include <acknex.h>
#include <default.c>


PANEL* Sprite = 
{
	bmap = "Dot.pcx" ;
//	layer = 2 ;
	pos_x = 0 ;
	pos_y = 294 ;
	flags = VISIBLE ;
}	


//PANEL* debugPanel = // Create a Text Panel to display Variables to the screen
//{
//	layer = 3;
//  	digits( 10,10,3,*,1, Sprite.pos_x ); 
//  	digits( 10,20,3,*,1, Sprite.pos_y ); 
//  	flags = VISIBLE ;
//}


//function update_dot_position()
//{
//	if ( key_cuu ) Sprite.pos_y-- ;
//   if ( key_cud ) Sprite.pos_y++ ;
//
//   if ( key_cul ) Sprite.pos_x-- ;
//   if ( key_cur ) Sprite.pos_x++ ;
//}

function main()
{
   video_mode = 7 ; 
	wait (1) ;
	video_window( NULL, NULL, 0, "Make Sprite Move" ) ;

   
	while ( 1 )
	{
//	vec_set( screen_color, vector( 55, 55, 55 ) ) ; 

//      update_dot_position() ; 
      
      Sprite.pos_x = Sprite.pos_x + 40 ;
      
		wait ( 500 ) ;

	}
	
}
