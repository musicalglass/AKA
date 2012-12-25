using System ; 
using System.IO ;
using System.Security.Cryptography ; 

class EncoderFun
{ 
	static void Main ( )
	{ 
	Stream stm = new FileStream ( "foo.txt" , FileMode.Open , FileAccess.Read ) ; 
	ICryptoTransform ict = new ToBase64Transform ( ) ; 
	CryptoStream cs = new CryptoStream ( stm , ict, CryptoStreamMode.Read ) ; 
	TextReader tr = new StreamReader ( cs ) ; 
	string s = tr.ReadToEnd ( ) ;
	Console.WriteLine ( s ) ;
	} 
} 
