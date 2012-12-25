using System ; 
using Collections.Generic ;

class Whatever
{ 
	static void Main ( )
	{ 
	byte data = 42;
	Queue<byte> myQueue = new Queue<byte>();
 
	myQueue.Enqueue(data);
 
	if (myQueue.Count > 0) //Check within bounds
	{
	   data = myQueue.Dequeue();
	}
	} 
} 
