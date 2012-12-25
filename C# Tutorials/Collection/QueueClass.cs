using System ; 
using System.Collections ; 
class MyQueue
{ 
	static void Main ( )
	{ 
	Queue q = new Queue ( ) ;
	q.Enqueue ( 1 ) ; 
	q.Enqueue ( 2 ) ; 
	Console.WriteLine ( q.Dequeue ( ) ) ; // Prints "1"
	Console.WriteLine ( q.Dequeue ( ) ) ; // Prints "2"
	} 
} 
