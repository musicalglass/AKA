using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.Polygon
{
    class MyForm : Form
    {
        // Variable Declarations and such go here

        static void Main(string[] args)
        {
            Application.Run(new MyForm());
        }

        MyForm() // The Constructor for our application
        {
            // Setup various Form window attributes
            SuspendLayout();
            Size = new Size(400, 300);
            BackColor = Color.Black;
            Text = " Draw Polygon";
            CenterToScreen();
            ResumeLayout(false);

            // Create OnPaint Event Handler: fired every time Windows says it's time to repaint the canvas
            Paint += new PaintEventHandler(OnPaint);
        }

        void OnPaint(Object sender, PaintEventArgs PaintNow) // The Main "Loop" of our program
        {
            PaintNow.Graphics.DrawPolygon(new Pen(Color.Red, 6),
            new Point[] { new Point(200,40),
                          new Point(265,100),
                          new Point(200,125),
                          new Point(290,140),
                          new Point(150,230),
                          new Point(120,80)});
        }

        /// <summary>Keypress event.</summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
