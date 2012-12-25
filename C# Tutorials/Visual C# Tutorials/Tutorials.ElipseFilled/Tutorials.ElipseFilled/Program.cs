/// <Title>Draw an Elipse Outline </Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.ElipseFilled
{
    class MyForm : Form
    {
        // Variable Declarations and such go here
        // n/a

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
            Text = " Draw Elipse Filled";
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
            // Create a rectangle which defines the boundary of our Oval
            Rectangle BoundingRectangle = new Rectangle(100, 40, 120, 180);
            SolidBrush YellowBrush = new SolidBrush(Color.Yellow); // Create a brush to paint our Oval

            PaintNow.Graphics.FillEllipse(YellowBrush, BoundingRectangle); // Discover fusion!
        }
    }
}
