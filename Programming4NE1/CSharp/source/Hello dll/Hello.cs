using System ; 

public class Hello 
{
	public static void Main () 
	{
		HelloUtil.Echo h = new HelloUtil.Echo ( "Hello.\nMy first dll !" ) ; 
		h.Tell() ; 
		}
}