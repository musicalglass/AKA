/// <Title>Simple Animation</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright © 2006 Timothy Lee Heermann</Copyright>

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tutorials.Animation
{
    public class MyForm : Form
    {
        // Declare Variables
        int SpriteX, SpriteY; // Sprite position in pixels from Left, Top
        int SpriteWidth = 4, SpriteHeight = 4; // Sprite size

        Timer MyTimer; /// <remarks>Create an instance of the Timer class called MyTimer </remarks>
        int TimerDuration = 500; // Set Timer duration (1 second = 1000 milliseconds)
        int SpriteMove = 4;  // Distance to move Sprite every Timer tick

        /// <summary>Run MyForm. </summary>
        /// <remarks>We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that!</remarks>
        static void Main()
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application. </summary>
        MyForm()
        {
            // Set the Form window's attributes
            Text = " See Dot Move";
            BackColor = Color.Black;
            CenterToScreen();

            SpriteX = 0; // Sprite position starting at the far left of our window
            SpriteY = 100; // Starting from the top down (minus menubar height of approx 38)

            MyTimer = new Timer(); // Instatiate instance of MyTimer
            MyTimer.Interval = TimerDuration; // Set the timer duration. 
            MyTimer.Start(); // Obviously this line makes cheese fall from the sky
            // Create Event Handler for Timer Tick. Every time MyTimer Ticks... 
            MyTimer.Tick += new EventHandler(Update); // run the Method called Update (see below)

            /// <remarks>Create OnPaint Event Handler: 
            /// fired every time Windows says it's time to repaint the canvas. </remarks>
            Paint += new PaintEventHandler(DrawGraphics); // When Windows says Paint: run DrawGraphics (see below)
        }

        void DrawGraphics(Object sender, PaintEventArgs PaintNow)
        {
            Rectangle MySprite = new Rectangle(SpriteX, SpriteY, SpriteWidth, SpriteHeight); // Create rectangle (start position, and size X & Y)
            SolidBrush WhiteBrush = new SolidBrush(Color.White); // Create Brush(Color) to paint rectangle

            PaintNow.Graphics.FillRectangle(WhiteBrush, MySprite);
        }

        public void Update(object sender, System.EventArgs e) // Every time MyTimer ticks
        {
            SpriteX += SpriteMove; // Update Sprite position

            // If Sprite Position = Window width
            if (SpriteX >= (640 - (SpriteWidth * 2))) // Subtract the width of the sprite * 2 so it's not offscreen
                MyTimer.Stop();

            Invalidate(); // Trigger OnPaint again, creating a loop
        }
    }
}
