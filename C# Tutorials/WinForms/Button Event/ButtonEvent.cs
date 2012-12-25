using System ; 
using System.Windows.Forms ; 

class MyFirstForm : Form
{

	public MyFirstForm ( ) 
	{
	this.Text = "My Button" ; 
	Button button = new Button ( ) ; 
	button.Text = "Click Me!" ;
	button.Click += new EventHandler ( button_Click ) ; 
	this.Controls.Add ( button ) ; 
	}

	void button_Click ( object sender, EventArgs e )
	{
	MessageBox.Show ( "You clicked?" ) ; 
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
