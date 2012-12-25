using System;

class GeorgetownCleaningServices
{
	static void Main()
	{
		string CustomerName;
		string CustomerHomePhone;

		ushort NumberOfShirts;
		ushort NumberOfPants;
		ushort NumberOfDresses;

		decimal PriceOneShirt;
		decimal PriceAPairOfPants;
		decimal PriceOneDress;

		uint OrderDay;
		uint OrderMonth;
		uint OrderYear;

		double MondayDiscount;

		CustomerName      = "Gregory Almas";
		CustomerHomePhone = "(301) 723-4425";
		NumberOfShirts    = 1;
		NumberOfPants     = 1;
		NumberOfDresses   = 1;
		OrderDay          = 15;
		OrderMonth        = 7;
		OrderYear         = 2002;
		PriceOneShirt     = 0.95M;
		PriceAPairOfPants = 2.95M;
		PriceOneDress     = 4.55M;
		MondayDiscount    = 0.25; // 25%

		Console.WriteLine("-/- Georgetown Cleaning Services -/-");
		Console.WriteLine("========================");
		Console.Write("Customer:   ");
		Console.WriteLine(CustomerName);
		Console.Write("Home Phone: ");
		Console.WriteLine(CustomerHomePhone);
		Console.Write("Order Date: ");
		Console.Write(OrderMonth);
		Console.Write('/');
		Console.Write(OrderDay);
		Console.Write('/');
		Console.WriteLine(OrderYear);
		Console.WriteLine("------------------------");
		Console.WriteLine("Item Type  Qty Sub-Total");
		Console.WriteLine("------------------------");
		Console.Write("Shirts      ");
		Console.Write(NumberOfShirts);
		Console.Write("     ");
		Console.WriteLine(PriceOneShirt);
		Console.Write("Pants       ");
		Console.Write(NumberOfPants);
		Console.Write("     ");
		Console.WriteLine(PriceAPairOfPants);
		Console.Write("Dresses     ");
		Console.Write(NumberOfDresses);
		Console.Write("     ");
		Console.WriteLine(PriceOneDress);
		Console.WriteLine("------------------------");
		Console.Write("Monday Discount: ");
		Console.Write(MondayDiscount);
		Console.WriteLine('%');
		Console.WriteLine("========================");
		Console.WriteLine();
	}
}
