// HelloLevel.c
// Display a Level with a 3D Model

#include <acknex.h>
#include <default.c>

void main()
{	
	level_load("grid.hmp"); // Load the level named grid.hmp

	ent_create("earth.mdl", NULL, NULL) ; // Load the 3D Model named earth.mdl 

	camera.x = -50 ; // Back the Camera up a bit so we can see the Model
//	camera.z = 2 ;
}
