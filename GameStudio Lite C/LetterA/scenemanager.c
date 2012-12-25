


action scenemanager() 
{
	wait(1);
	
	if (player == NULL) { player = me; } 
	
	set(my,PASSABLE);
	set(my,INVISIBLE);
	set(my,UNTOUCHABLE);
		
	init_cameras();
	position_camera();
	wait(1);
	createLetters();
	
	while(1) 
	{
		on_anykey = CheckAscii;
		testVar2 = LetterPressedAscii;
	   wait(1);		
	}  
}

void CheckAscii()
{
//	inkey(KeyboardInput);
//	LetterPressedAscii = str_to_asc(KeyboardInput);
	

				if ( key_a) {
					LetterPressedAscii = 97;
					}
				
				if ( key_b) {
					LetterPressedAscii = 98;
					}
					
				if ( key_c) {
					LetterPressedAscii = 99;
					}
					
				if ( key_d) {
					LetterPressedAscii = 100;
					}
					
				if ( key_e) {
					LetterPressedAscii = 101;
					}
					
				if ( key_f) {
					LetterPressedAscii = 102;
					}
					
				if ( key_g) {
					LetterPressedAscii = 103;
					}
					
				if ( key_h) {
					LetterPressedAscii = 104;
					}
					
				if ( key_i) {
					LetterPressedAscii = 105;
					}
		
				if ( key_j) {
					LetterPressedAscii = 106;
					}
					
				if ( key_k) {
					LetterPressedAscii = 107;
					}

				if ( key_l) {
					LetterPressedAscii = 108;
					}

				if ( key_m) {
					LetterPressedAscii = 109;
					}

				if ( key_n) {
					LetterPressedAscii = 110;
					}

				if ( key_o) {
					LetterPressedAscii = 111;
					}

				if ( key_p) {
					LetterPressedAscii = 112;
					}

				if ( key_q) {
					LetterPressedAscii = 113;
					}

				if ( key_r) {
					LetterPressedAscii = 114;
					}

				if ( key_s) {
					LetterPressedAscii = 115;
					}

				if ( key_t) {
					LetterPressedAscii = 116;
					}

				if ( key_u) {
					LetterPressedAscii = 117;
					}

				if ( key_v) {
					LetterPressedAscii = 118;
					}

				if ( key_w) {
					LetterPressedAscii = 119;
					}

				if ( key_x) {
					LetterPressedAscii = 120;
					}

				if ( key_y) {
					LetterPressedAscii = 121;
					}

				if ( key_z) {
					LetterPressedAscii = 122;
					}

	testVar = LetterPressedAscii;
	
}