// coin.c

#include <acknex.h>
#include <default.c>

var My_Coin = 1 ;

function random_Toss() 
{
	My_Coin = integer(random(2) + 1) ; 
}

action flip_coin()
{
	my.ambient = 100 ; 
	
	while(1) 
	{
//		on_space = random_Toss ; 
//		my.frame = My_Coin ; 
		
		if ( key_1 ) my.frame = 1 ; 
		if ( key_2 ) my.frame = 2 ; 
		
		wait (1) ; 
	}

}

function main()
{
	random_seed(0); 
	//	vec_set( sky_color,vector( 1,1,1 ) ) ;	// almost black sky
	level_load("") ; // load empty level
	ent_create( "quarter+2.tga", vector( 200,0,0 ), flip_coin ) ; 
}
