using System ; 
using System.Collections ; 
class MyQueue
{ 
	static void Main ( )
	{ 
	Stack s = new Stack ( ) ;
	s.Push ( 1 ) ; // Stack = 1
	s.Push ( 2 ) ; // Stack = 1, 2
	s.Push ( 3 ) ; // Stack = 1, 2, 3
	Console.WriteLine ( s.Pop( ) ) ; // Prints 3
	Console.WriteLine ( s.Pop( ) ) ; // Prints 2
	Console.WriteLine ( s.Pop( ) ) ; // Prints 1
	} 
} 
