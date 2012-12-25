using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.Background
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
            Text = "Background";
            CenterToScreen();
            ResumeLayout(false);

            // Create OnPaint Event Handler: fired every time Windows says it's time to repaint the canvas
            Paint += new PaintEventHandler(OnPaint);
        }

        void OnPaint(Object sender, PaintEventArgs PaintNow) // The Main "Loop" of our program
        {
            // Create a Background Rectangle
            Rectangle BackgroundRectangle = ClientRectangle;

            // Create background color Brush for Startup Screen
            LinearGradientBrush BackgroundRectangleColor = new LinearGradientBrush
            (BackgroundRectangle, Color.PapayaWhip, Color.Purple, LinearGradientMode.BackwardDiagonal);

            PaintNow.Graphics.FillRectangle(BackgroundRectangleColor, BackgroundRectangle);
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
