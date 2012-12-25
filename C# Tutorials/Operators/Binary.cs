using System;

class Binary
{
    public static void Main ()
    {
        int Num1 , Num2 , iResult ;
        float fResult ;

        Num1 = 7 ; 
        Num2 = 5 ; 

        iResult = Num1 + Num2 ; 
        Console.WriteLine ( "Num1 + Num2: {0}" , iResult ) ; 

        iResult = Num1 - Num2 ; 
        Console.WriteLine ( "Num1 - Num2: {0}" , iResult ) ; 

        iResult = Num1 * Num2 ; 
        Console.WriteLine ( "Num1 * Num2: {0}" , iResult ) ; 

        iResult = Num1 / Num2 ; 
        Console.WriteLine ( "Num1 / Num2: {0}" , iResult ) ; 

        fResult = ( float )Num1 / ( float )Num2 ; 
        Console.WriteLine ( "Num1 / Num2: {0}" , fResult ) ; 

        iResult = Num1 % Num2 ; 
        Console.WriteLine ( "Num1 % Num2: {0}" , iResult ) ; 

        iResult += Num1 ; 
        Console.WriteLine ( "iResult += Num1: {0}" , iResult ) ; 
    }
} 