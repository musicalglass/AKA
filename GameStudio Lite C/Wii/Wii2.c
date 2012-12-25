#include <acknex.h>
#include <default.c>

//#define WII_DEBUG	//define before including ackwii.h to enable debugging
#include "ackwii.h"


/* assigned to '1' button */
void toggleIR (var handle, WIIMOTE* buffer)
{
	/* note: IR sensor requires a sensor bar or adequate replacement */
	wiimote_ir(handle, 1 - buffer->status.ir);		
}

/* assigned to '2' button */
void toggleVibration (var handle, WIIMOTE* buffer)
{
	wiimote_vibration(handle, 1 - buffer->status.vibration);		
}

WIIMOTE buffer;	//needs to be declared globally
WIIMOTE buffer2;	//needs to be declared globally

var curbuf = 0;
void toggle_buffer()
{
	#ifdef WII_DEBUG
		if (curbuf == 0)
		wiimote_debug(&buffer);
		else
		wiimote_debug(&buffer2);
	#endif
	curbuf = 1-curbuf;
}

void main ()
{
	on_a = toggle_buffer;
	video_mode = 7; 
	screen_color.blue = 150;
	fps_max = 100;
	
	var wii_handle;
	var wii_handle2;
	/* clear buffer before using!! */
	zero(buffer);
	zero(buffer2);

	/* assign functions to Wiimote buttons */
	buffer.event.on_1 = toggleIR;
	buffer.event.on_2 = toggleVibration;
	on_esc = NULL;
	
	wait(-1);
	
	/* check if any Wiimote is found */
	if (wiimote_getdevices() > 0)
	{
		/* connect first device */
		wii_handle = wiimote_connect(0);
		wii_handle2 = wiimote_connect(1);
		if(wii_handle != NULL && wii_handle2 != NULL)
		{
			/*
			debug mode: show buffer in panel and assign log function to B button
			of Wiimote. Use F12 to toggle visibility of panel
			*/
			#ifdef WII_DEBUG
				wiimote_debug(&buffer);
			#endif
			
			/* 
			a value close to 1 results in very soft angle smoothing
			drawback: smoothing delivers the resulting angle delayed
			*/
			wiimote_smoothfac(wii_handle, 0.9);
			while (key_esc != 1)
			{
				/* update buffer with data coming from Wiimote */
				wiimote_status(wii_handle, &buffer);
				wiimote_status(wii_handle2, &buffer2);
				wait(1);
			}
			/*
			IMPORTANT: this function must be called before closing the engine window.
			Otherwise engine will crash! Also wait a few ticks to ensure that DLL is
			not running anymore.
			*/
			if ( key_esc )
			{
				wiimote_disconnect(wii_handle);
				wiimote_disconnect(wii_handle2);
				wait(2);	
			}
			
		}
	}	
	sys_exit("");
}
