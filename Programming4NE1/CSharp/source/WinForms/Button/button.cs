using System ; 
using System.Windows.Forms ; 

class MyFirstForm : Form
{

	public MyFirstForm ( ) 
	{
	this.Text = "My Button" ; 
	Button button = new Button ( ) ; 
	button.Text = "Click Me!" ;
	this.Controls.Add ( button ) ; 
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
