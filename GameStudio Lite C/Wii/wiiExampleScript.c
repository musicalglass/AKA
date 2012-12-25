/******************************************

        AW Adventure Main File
                v 1.0

            Gregory Arndt
     (c) 2008 Artistry Entertainment

******************************************/

#define PRAGMA_PATH 		".";
#define PRAGMA_PATH 		"code";
#define PRAGMA_PATH 		"images";
#define PRAGMA_PATH		"maps";
#define PRAGMA_PATH		"models";
#define PRAGMA_PATH		"sounds";
#define PRAGMA_PATH		"textures";
#define PRAGMA_PLUGIN	"code\\lc_fmod_wrap.dll";
#define PRAGMA_PLUGIN	"code\\ackwii.dll";

// Acknex Includes
#include <litec.h>
#include <acknex.h>
#include <default.c>
// FMOD Wrapper Include
#include "LC_FMOD_WRAP.h";
// Wii DLL Include
//#define WII_DEBUG
#include "ackwii.h"
// AWAdventure Includes
#include "AWAdventure.h"
#include "MediaFunctions.c"
#include "PanelFunctions.c"
#include "SystemFunctions.c"


// Main Function
void main()
  { 
   var i;
   
   fps_max = 180;
   video_switch (6, 32, 2);
   video_window(NULL,NULL,112,strGameName);
	vec_set(screen_color, vector(0, 0, 0));
	mouse_pointer = 0;
	
	zero(WiiBuffer);
	
   on_close = on_esc = NextProgramState;
   on_f10 = ToggleInputCoords;
   // assign functions to Wiimote buttons
	WiiBuffer.event.on_1 = toggleIR;
	WiiBuffer.event.on_2 = toggleVibration;
	
   GetSystemInfo();
	wait(10);
	
	LoadSetup();
	wait(10);
	
	InitializeSounds();
	wait(10);
	
   WiiDevices = wiimote_getdevices();
   WiiIndex = 0;
   if (WiiDevices != NULL)
	  {
		/* connect first device */
		for (i = 0; i < 4; i++)
     	  { WiiHandle[WiiIndex+i] = wiimote_connect(WiiIndex+i); }
//		wiimote_ir(WiiHandle[WiiIndex], 1);
  	  }
	
	NextProgramState();
	
	while (1)
	  {		
		// Move Mouse
		if(WiiHandle[WiiIndex] != NULL) 
		  {
		  	wiimote_status(WiiHandle[WiiIndex], &WiiBuffer[WiiIndex]);
	  		mouse_pos.x = WiiBuffer[WiiIndex].ir[0].ir_x;
			mouse_pos.y = WiiBuffer[WiiIndex].ir[0].ir_y;
		  }
		  else {
		  		  mouse_pos.x = mouse_cursor.x;
				  mouse_pos.y = mouse_cursor.y;
				 }
		
		//Check Volume
		if (vBGMVolume != vBGMVolumeSet) UpdateBGMVolume();
		if (vSFXVolume != vSFXVolumeSet) UpdateSFXVolume();
		if (vMasterVolume != vMasterVolumeSet) UpdateMasterVolume();
		
		wait(1);
	  }	
  }
