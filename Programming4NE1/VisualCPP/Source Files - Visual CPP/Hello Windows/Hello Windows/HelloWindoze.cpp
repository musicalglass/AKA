// PROG3_2.CPP - A simple message box
#define WIN32_LEAN_AND_MEAN 
#include <windows.h>         
#include <windowsx.h>    

// main entry point for all windows programs
int WINAPI WinMain ( HINSTANCE hinstance ,
			HINSTANCE hprevinstance ,
			LPSTR lpcmdline ,
			int ncmdshow ) 
{
// call message box api
MessageBox ( NULL , "Hello WIndows!" ,
                 "My Window", MB_OK ) ; 

return( 0 ) ; 
} // end WinMain
