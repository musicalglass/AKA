using System;
using System.Windows.Forms ; 

class MyFirstForm : Form
{
	public MyFirstForm ()
	{
	this.Text = ("Hello Windoze") ;
	}

	class OkieDokie
	{
		static void Main()
		{ 
		Form MyForm = new MyFirstForm() ;
		Application.Run (MyForm) ; 
		}
	}
}