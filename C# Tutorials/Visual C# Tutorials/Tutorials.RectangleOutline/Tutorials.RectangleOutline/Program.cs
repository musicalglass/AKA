/// <Title>Draw a Rectangle Outline</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright © 2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tutorials.RectangleOutline
{
    class MyForm : Form
    {
        // Variable Declarations and such go here
        // n/a

        /// <summary>Run MyForm. </summary>
        /// <remarks>We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that!</remarks>
        static void Main( )
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application. </summary>
        MyForm()
        {
            /// <remarks> Setup various Form window attributes. </remarks>
            Size = new Size(400, 300);
            BackColor = Color.Black;
            Text = " Draw Rectangle Outline";
            CenterToScreen();

            /// <remarks>Create OnPaint Event Handler: 
            /// fired every time Windows says it's time to repaint the canvas. </remarks>
            Paint += new PaintEventHandler(DrawGraphics); // When Windows says Paint, DrawGraphics
        }

        /// <summary>Update the screen and draw any graphic objects. </summary>
        /// <remarks>Triggered by the PaintEventHandler.</remarks>
        /// <param name="sender"></param> <param name="PaintNow"></param>
        void DrawGraphics(Object sender, PaintEventArgs PaintNow)
        {
            // Make clone of default Rectangle.FromLTRB (Left X, Top Y, Right X, Bottom Y)
            Rectangle MyRectangle = Rectangle.FromLTRB(150, 75, 250, 175);
            Pen PurpleCrayon = new Pen(Color.Purple, 6); // Create a pen to outline our Rectangle (Color, Width)
            PaintNow.Graphics.DrawRectangle(PurpleCrayon, MyRectangle); // Draw a Square

            // Or you could write it all on one line thusly:
         // PaintNow.Graphics.DrawRectangle(new Pen(Color.LimeGreen, 5), Rectangle.FromLTRB(160, 85, 240, 165)); 
        }
    }
}
