using System ; 
using System.Collections.Generic;
// A Queue simulated using a List
class QueueList
{ 
	static void Main ( )
	{ 
	
	byte myData = 42;

	List<byte> myQueue = new List<byte>();
 
	myQueue.Add(myData); //Enqueue
        
	if (myQueue.Count > 0) //Check within bounds
	{
	   //Dequeue
	   myData = myQueue[0];
	   myQueue.RemoveAt(0);
	}

	} 
} 
