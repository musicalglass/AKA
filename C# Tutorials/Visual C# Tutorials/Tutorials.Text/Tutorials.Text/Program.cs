/// <Title>Draw a Dot</Title>
/// <Trademark>Tutorials.Text in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.Text
{
    class MyForm : Form
    {
        // Variable Declarations and such go here
        //

        /// <summary>Run MyForm. </summary>
        /// <remarks>We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that!</remarks>
        static void Main(string[] args)
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application. </summary>
        MyForm()
        {
            /// <remarks> Setup various Form window attributes. </remarks>
            SuspendLayout();
            Size = new Size(400, 300);
            BackColor = Color.Black;
            Text = " Hello Windows";
            CenterToScreen();
            ResumeLayout(false);

            /// <remarks>Create OnPaint Event Handler: 
            /// fired every time Windows says it's time to repaint the canvas. </remarks>
            Paint += new PaintEventHandler(DrawGraphics);
        }

        /// <summary>Update the screen and draw any graphic objects. </summary>
        /// <remarks>Triggered by the PaintEventHandler.</remarks>
        /// <param name="sender"></param> <param name="PaintNow"></param>
        void DrawGraphics(Object sender, PaintEventArgs PaintNow)
        {
            Font Arial16 = new Font("Arial", 18);
            SolidBrush YellowBrush = new SolidBrush(Color.Yellow);
            PaintNow.Graphics.DrawString("I am!", Arial16, YellowBrush, 150, 100);
        }
    }
}
