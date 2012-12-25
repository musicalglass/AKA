using System ; 

public class Echo
{
	string myString ; 

	public Echo ( string aString ) 
	{
		myString = aString ; 
	}

	public void Tell() 
	{
		Console.WriteLine ( myString ) ; 
	}
}

public class Hello
{
	public static void Main ( ) 
	{
		Echo h = new Echo ( "Hello.\nMy first C# object!" ) ; 
		h.Tell() ; 
	}
}