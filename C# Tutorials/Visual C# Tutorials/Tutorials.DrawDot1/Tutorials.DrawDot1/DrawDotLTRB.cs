using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tutorials.DrawDot1
{
    class MyForm : Form
    {
        // Variable Declarations and such go here
        // n/a

        static void Main( )
        {
            Application.Run(new MyForm());
        }

        MyForm() // The Constructor for our application
        {
            // Setup various Form window attributes
            BackColor = Color.Black;
            Text = " See Dot";

            // Create OnPaint Event Handler: fired every time Windows says it's time to repaint the canvas
            // When Windows says Paint, execute DrawGraphics Method ( see below )
            Paint += new PaintEventHandler(DrawGraphics);
        }

        /// <summary> Update the screen and draw any graphic objects </summary>
        /// <param name="sender"></param> <param name="PaintNow"></param>
        void DrawGraphics(Object sender, PaintEventArgs PaintNow)
        {
            // Draw Rectangle( DefaultPen.Color, Rectangle.Type ( Coords Left, Top, Right, Bottom ))
            PaintNow.Graphics.DrawRectangle(Pens.White, Rectangle.FromLTRB(150, 100, 151, 101)); 
        }
    }
}
