/// <Title>Draw a Line</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.DrawLine
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
            BackColor = Color.White;
            Text = " Draw a Line";
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
            Graphics PaintNowInstance = PaintNow.Graphics; // Create an Instance of Graphics object because...
            PaintNowInstance.SmoothingMode = SmoothingMode.AntiAlias; // we need to modify some of it's attributes
            Pen BlackPen = new Pen(Color.Black, 4); // Create pen to draw line (Line Color, Width)

            PaintNowInstance.DrawLine(BlackPen, 50, 50, 300, 200); // Draw Line (Pen, Start X, Start Y, End X, End Y)

             // Here's another way to do it
             Point LineStart = new Point(300, 50); // Create starting point (X, Y)
             Point LineEnd = new Point(50, 200);
             PaintNowInstance.DrawLine(BlackPen, LineStart, LineEnd ); // Encounter non carbon based lifeform
        }
    }
}
