using System ; 
using System.Collections ; 

class QueueCollect
{ 
	static void Main ( )
	{ 
	Queue q = new Queue ( ) ; 
	q.Enqueue ( 1 ) ; // Box an Integer
	q.Enqueue ( 2 ) ; // Box another Integer
	Console.Write ( ( int ) q.Dequeue ( ) ) ; // Unbox an Integer 
	Console.Write ( ( int ) q.Dequeue ( ) ) ; // Unbox an Integer
	} 
} 
