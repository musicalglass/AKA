using System ; 
public class WonkyWay
{
	static void Main ( )
	{ 
	// Assign a value of 3 to Variable
	int NumberOfWorkers = 7 ; 
	int RateOfPay = 21 ; 
	// Insert Variable into output String
	Console.Write ( "\nNumber of unskilled workers: " ) ; 
	Console.Write ( NumberOfWorkers ) ; 
	Console.Write ( "\nPay rate: " ) ; 
	Console.Write ( RateOfPay ) ; 
	Console.Write ( " Pesos per day\n" ) ; 
	Console.Write ( "Needed: " ) ; 
	Console.Write ( NumberOfWorkers ) ; 
	Console.Write ( " hard hats, " ) ; 
	Console.Write ( NumberOfWorkers ) ; 
	Console.Write ( " pair of gloves and " ) ; 
	Console.Write ( NumberOfWorkers ) ; 
	Console.Write ( " burritos for " ) ; 
	Console.Write ( NumberOfWorkers ) ; 
	Console.Write ( " workers.\n" ) ; 
	Console.Write ( "Salary: " ) ; 
	Console.Write ( RateOfPay * 7) ; 
	Console.Write ( " Pesos per week\n " ) ; 
	}
}