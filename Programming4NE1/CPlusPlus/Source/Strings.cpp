#include <stdio.h>
#include <string.h>

#define NAME_MAXLENGTH 20

int main ( void )
{
char name[NAME_MAXLENGTH + 1] ;

	printf ( "Please enter your name: " ) ;
	scanf ( "%20s", name ) ;

	printf ( "Hello %s, your name is %d characters long\n", name, strlen(name));
return 0 ;
}	/* main */
