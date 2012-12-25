using System ; 

class ForLoopPause
{ 
    public static void Main ( ) 
    { 
    int iCounter ; 
            Console.WriteLine ( "\nPress the Enter key" ) ; 
        for ( iCounter = 1 ; iCounter <= 10 ; iCounter++ ) 
		{
		Console.Write( "{0} \n", iCounter ) ; 
		Console.ReadLine ( ) ;
		}
    } 
} 
