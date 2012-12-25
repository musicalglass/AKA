using System ; 
using System.Collections.Generic;

class Whatever
{ 
	static void Main ( )
	{ 
	/byte data = 42;
Stack<byte> myStack = new Stack<byte>();
 
myStack.Push(data);
 
if (myStack.Count > 0) //Check within bounds
{
   data = myStack.Pop();
}
	} 
} 
