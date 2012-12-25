using System ; 
using System.Collections.Generic;

class StackList
{ 
	static void Main ( )
	{ 
	byte data = 42;
List<byte> myList = new List<byte>();
 
myList.Insert(0, data); //PUSH
 
if (myList.Count > 0) //Check within bounds
{
   //POP
   data = myList[0];
   myList.RemoveAt(0);
}
	} 
} 
