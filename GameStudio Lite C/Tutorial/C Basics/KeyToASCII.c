// KeyToASCII.c
// Display the ASCII value of key pressed

var myASCII ; 

PANEL* debugPanel =
{
	digits(200,160,"Press any key.",Arial#34b,1,NULL ) ; 
  	digits(200,200,"ASCII value = %0.f",Arial#32b,1,myASCII ) ; 
  	flags = VISIBLE;

}

STRING* inputString ; // Empty String to store keyboard input


function main()
{
	while(1) 
	{
		myASCII = inchar( inputString ) ; // Convert input into ASCII and store in myVariable
		wait(1);
	}	
}
