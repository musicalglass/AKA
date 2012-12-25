using System ; 

namespace HelloUtil
{
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
}