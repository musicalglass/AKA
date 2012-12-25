function init_cameras()  
{ 
 while(player == NULL) {wait(1);}
 set(camera,VISIBLE);
}

function position_camera() //from player action in heromove
{
 while(player == NULL) { wait(1); }

 if(is(camera,VISIBLE) ) //&& (toggle2 == 0))
 { 
 
   set(camera, PASSABLE); // make the camera passable - edited temporarily
   camera.genius = NULL;

	//set the camera focus point to the centre of the player model at eye height:
	vec_set(cam_centre.x,vector(0,0,160));


	//calculate x,y,z position of the camera:
	orbit_camera_dist = fcos(orbit_camera_tilt, camera_dist);
	cam_pos.x = cam_centre.x - fcos(orbit_camera_pan, orbit_camera_dist);
	cam_pos.y = cam_centre.y - fsin(orbit_camera_pan, orbit_camera_dist);
	cam_pos.z = cam_centre.z + fsin(orbit_camera_tilt, camera_dist);

	//Now set the pan, roll and tilt of the camera
	camera.pan = orbit_camera_pan;
	camera.roll = 0; //no roll
	camera.tilt = -orbit_camera_tilt;

   
   camera_dist -= mickey.z;	// 
	camera_dist = clamp(camera_dist, camera_dist_min, camera_dist_max); //limit
	
	cam_pos.x = clamp(cam_pos.x, min_bounds_x, max_bounds_x); //level limit in X...camera will not move outside this range within level
   cam_pos.y = clamp(cam_pos.y, min_bounds_y, max_bounds_y); //level limit in Y...camera will not move outside this range within level
      

     vec_set(camera.x,cam_pos.x); //no smoothing...insta-snap

   return;
 }
}