using System ; 
public class WonkyWay
{
	static void Main ( )
	{ 
	// Assign a value of 3 to Variable
	int NumberOfWorkers = 7 ; 
	int RateOfPay = 60 ; 
	// Insert Variable into output String
	Console.Write ( "\nNumber of skilled workers: {0}" , NumberOfWorkers ) ; 
	Console.Write ( "\nPay rate: {0} Dollars per hour\n" , RateOfPay ) ; 

	Console.Write ( "Needed: {0} computers, {0} office chairs and {0} sushi plates for {0} programmers.\n" , NumberOfWorkers ) ; 

	int HoursPerDay = 8 ; 
	int Wages = (  ( RateOfPay * HoursPerDay ) * 5 ) ; 
	Console.Write ( "Salary: {0} Dollars per week\n" , Wages ) ; 

	}
}