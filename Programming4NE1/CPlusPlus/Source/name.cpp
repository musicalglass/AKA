#include <stdio.h>

int main ( void ) 
{ 

/* Local Declarations */
char UserName[ 24 ] ;

/* Statements */
printf ( "What is your name? " ) ;
fgets ( UserName, sizeof ( UserName ), stdin ) ;
printf ( "Hello, " ) ;
printf ( "%s", UserName ) ;
return 0 ;
}	/* main */