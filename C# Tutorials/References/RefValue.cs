using System ; 
// Reference-type declaration
class PointR { 
public int x, y ; 
}
// Value-type declaration
struct Pointv { 
public int x, y ; 
}
class ReferenceValue
{ 
	static void Main ( )
	{ 
	PointR a ; /* Local Reference-Type variable, uses 4 bytes of
				memory on the stack to hold address */
	PointV b ;  /* Local Value-Type Variable, uses 8 bytes of 
				memory on the stack for x and y
				a = new PointR(); */
	a = new PointR( ) ;  /* Assigns the reference to address of
					new instance of PointR allocated on the heap*/
	b = new PointV( ) ;  /* Calls the value type's default constructor */
	a.x = 7 ; 
	b.x = 7 ; 
	} 
} 
PointR c = a ; 
PointV d = b ; 
c.x = 9 ;
d.x = 9 ;
Console.WriteLine ( a.x ) ;
Console.WriteLine ( b.x ) ;
}
}

