/// <Title>Infinite Screen</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright © 2006 Timothy Lee Heermann</Copyright>

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tutorials.InfiniteScreen
{
    public class MyForm : Form
    {
        // Declare Variables
        int SpriteX, SpriteY; // Sprite position in pixels from Left, Top
        int SpriteWidth = 4, SpriteHeight = 4; // Sprite size

        int SpriteMove = 4;  // Distance to move Sprite every tick

        Timer MyTimer; // Create an instance of the Timer class called MyTimer

        /// <summary>Run MyForm. </summary>
        /// <remarks>We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that!</remarks>
        [STAThread]
        static void Main()
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our project. </summary>
        public MyForm()
        {
            // Set the Form window's attributes
            Text = " Infinite Screen";
            BackColor = Color.Black;
            CenterToScreen();

            MyTimer = new Timer(); // Instantiate instance of MyTimer
            MyTimer.Interval = 20; // Set the timer duration. 1000 milliseconds = 1 second 
            MyTimer.Start(); // Obviously this line makes cheese fall from the sky
            // Create Event Handler for Timer Tick. Every time MyTimer Ticks... 
            MyTimer.Tick += new EventHandler(Update); // run the Method called Update (see below)

            SpriteX = 0; // Starting at the far left of our window
            SpriteY = 100 ; // From top to bottom. +Y is Down!

            /// <remarks>Create OnPaint Event Handler: 
            /// fired every time Windows says it's time to repaint the canvas.
            /// When Windows says Paint: run DrawGraphics (see below) </remarks>
            Paint += new PaintEventHandler(DrawGraphics); 
        }

        /// <summary> Update Sprite position very time MyTimer ticks </summary>
        public void Update(object sender, System.EventArgs e) 
        {
            SpriteX += SpriteMove; /// <remarks>Update Sprite position </remarks>

            // If Sprite Position exceeds Window width...
            if (SpriteX >= this.Width) // Subtract the width of the sprite * 2 so it's not offscreen
                SpriteX = ( 0 - SpriteWidth) ;

            Invalidate(); // Trigger OnPaint again, creating a loop
        }

        /// <summary>Update the screen and draw any graphic objects. </summary>
        /// <remarks>Triggered by the PaintEventHandler.</remarks>
        /// <param name="sender"></param> <param name="PaintNow"></param>
        void DrawGraphics(Object sender, PaintEventArgs PaintNow) // When Windows says it's time to redraw the window
        {
            // Create rectangle (start position, and size X & Y)
            Rectangle Dot = new Rectangle(SpriteX, SpriteY, SpriteWidth, SpriteHeight);
            // Create Brush(Color) to paint Dot
            SolidBrush WhiteBrush = new SolidBrush(Color.White); 

            PaintNow.Graphics.FillRectangle(WhiteBrush, Dot);
        }
    }
}
