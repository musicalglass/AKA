/// <Title>Draw a Dot</Title>
/// <Trademark>Tutorials1 in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.DrawCurves
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
            Size = new Size(640, 480);
            BackColor = Color.Black;
            Text = " See Dot";
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
            using (Graphics grf = CreateGraphics())
            {
                grf.Clear(Color.White);
                // create points for the cardinal spline curve
                Point[] pts = new Point[]
      {
        new Point(10, 210),
        new Point(150, 300),
        new Point(300, 270),
        new Point(220, 220)
      };
                // Draw the same curve with different tension values
                grf.DrawCurve(Pens.Black, pts, 1.0f);
                grf.DrawCurve(Pens.Red, pts, 0.0f);
                grf.DrawCurve(Pens.Blue, pts, 2.0f);
            }

        }
    }
}
