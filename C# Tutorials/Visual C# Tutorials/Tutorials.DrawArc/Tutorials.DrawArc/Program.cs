/// <Title>Draw an Arc</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.DrawArc
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
            Size = new Size(640, 480);
            BackColor = Color.Black;
            Text = " Draw Arc";
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
            /// <remarks>Create a Rectangle instance which defines the boundaries of our Arc </remarks>
            Rectangle ArcBoundary = new Rectangle(200, 50, 200, 200);

            /// <remarks>Create a Colored Pen to draw our Arc with (Color, Width) </remarks>
            Pen RedPen = new Pen(Color.Red, 6);

            /// <remarks>Draw Archie :) (ColoredPen, Rectangle Boundary, Start Angle, Sweep Angle)</remarks>
            PaintNow.Graphics.DrawArc(RedPen, ArcBoundary, 15, 150); 
        }
    }
}
