/// <Title>Screen Rebound</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tutorials.ScreenRebound
{
    public class MyForm : Form
    {
        // Declare Variables
        int SpriteX, SpriteY; // Sprite position in pixels from Left, Top
        int SpriteWidth = 4, SpriteHeight = 4; // Sprite size

        int SpriteMove = 10;  // Distance to move Sprite every tick

        bool SpriteReverse = false;

        Timer MyTimer; // Create an instance of the Timer class called MyTimer

        /// <summary>Run MyForm. </summary>
        /// <remarks>We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that!</remarks>
        static void Main()
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application</summary>
        public MyForm()
        {
            /// <remarks> Setup various Form window attributes. </remarks>
            ClientSize = new System.Drawing.Size(400, 250);
            Text = "  Bouncing off the Walls!";
            BackColor = Color.Black;
            CenterToScreen();

            MyTimer = new Timer(); // Instantiate instance of MyTimer
            MyTimer.Interval = 20; // Set the timer duration. 1000 milliseconds = 1 second 
            MyTimer.Start(); // Tell Timer to start timing
            // Create Event Handler for Timer Tick. Every time MyTimer Ticks... 
            MyTimer.Tick += new EventHandler(Update); // run the Method called Update (see below)

            SpriteX = 0; // Starting at the far left of our window
            SpriteY = 100; // About halfway down the window (minus menubar height)

            /// <remarks>Create OnPaint Event Handler: 
            /// fired every time Windows says it's time to repaint the canvas. 
            /// When Windows says Paint run DrawGraphics method (see below)</remarks>
            Paint += new PaintEventHandler(DrawGraphics);
        }

        void DrawGraphics(Object sender, PaintEventArgs PaintNow)
        {
            Rectangle Dot = new Rectangle(SpriteX, SpriteY, SpriteWidth, SpriteHeight); // Create rectangle (start position, and size X & Y)
            SolidBrush WhiteBrush = new SolidBrush(Color.White); // Create Brush(Color) to paint rectangle

            PaintNow.Graphics.FillRectangle(WhiteBrush, Dot);
        }

        public void Update(object sender, System.EventArgs e) // Every time MyTimer ticks
        {
            if (SpriteReverse == false)
                SpriteX += SpriteMove; // Update Sprite position Positive X
            if (SpriteReverse == true)
                SpriteX -= SpriteMove; // Update Sprite position Negative X

            // If Sprite Position = Window width
            if (SpriteX >= this.Width - SpriteWidth) // If Sprite reaches this side of screen's Right side
                SpriteReverse = true; // Reverse Sprite's inner calling
            if (SpriteX <= 0) // If Sprite reaches screen's Left side..
                SpriteReverse = false; // Obviously this line sends a mild electric shock to the user

            Invalidate(); // Trigger Paint Event again, creating a loop
        }
    }
} // ... and that's how string cheese was invented!
