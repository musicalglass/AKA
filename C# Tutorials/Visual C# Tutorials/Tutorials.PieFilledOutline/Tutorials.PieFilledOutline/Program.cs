/// <Title>Make a Pie</Title>
/// <Trademark>C# recipes by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.PieCrustwFilling
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
            Text = " Draw Pie with Crust";
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
            /// <remarks>Create a Rectangle instance which defines the boundaries of our Pie </remarks>
            Rectangle PiePan = new Rectangle(100, 20, 200, 200);
            /// <remarks> Create a nice Lemon filling for our Pie </remarks>
            SolidBrush LemonFilling = new SolidBrush(Color.LemonChiffon);

            /// <remarks>Bake Lemon Chiffon Pie :) (ColoredFill, Rectangle Boundary, Start Angle, Sweep Angle)</remarks>
            PaintNow.Graphics.FillPie(LemonFilling, PiePan, 15, 150); // Note Pi R round, cornbread R square

            /// <remarks>Create a Colored Pen to draw our Crust (Color, Width) </remarks>
            Pen Brownish = new Pen(Color.Wheat, 12);

            /// <remarks>Until crust is Golden Brown (ColoredPen, Rectangle Boundary, Start Angle, Sweep Angle)</remarks>
            PaintNow.Graphics.DrawArc(Brownish, PiePan, 15, 150); 
        }
    }
}
