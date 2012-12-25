using System ; 

class MyStrings
{ 
	static void Main ( )
	{ 
	string[ ] strs1 = { "time" , "the" , "now" , "is" } ; 
	Array.Reverse ( strs1 ) ; 
	Array strs2 =  Array.CreateInstance (typeof ( string ) , 4 ) ; 
	strs2.SetValue ( "for" , 0 ) ; 
	strs2.SetValue ( "all" , 1 ) ; 
	strs2.SetValue ( "good" , 2 ) ; 
	strs2.SetValue ( "men" , 3 ) ; 
	Array strings = Array.CreateInstance ( typeof ( string ) , 8 ) ; 
	Array.Copy ( strs1 , strings , 4 ) ; 
	strs2.CopyTo ( strings , 4 ) ; 
	foreach ( string s in strings )
	Console.WriteLine ( s ) ;
	} 
} 
