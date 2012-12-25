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
        int BorderLeft, BorderTop, BorderRight, BorderBottom;
        int ClientWidth = 640, ClientHeight = 480, MenuHeight = 30;
        int SpriteMove = 4;  // Distance to move Sprite every tick
        int BorderWidth = 4; // Width of the pen used to draw our border
        int TimerDuration = 15; // Set the timer duration. 1000 milliseconds = 1 second 

        bool SpriteReverse = false;

        Timer MyTimer; // Create an instance of the Timer class called MyTimer

        [STAThread]
        static void Main()
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application</summary>
        public MyForm()
        {
            // Set the Form window's attributes
            ClientSize = new System.Drawing.Size(ClientWidth, ClientHeight);
            Text = "  Try resizing the window";
            BackColor = Color.Black;
            CenterToScreen();

            //Initiates double buffering
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            MyTimer = new Timer(); // Instantiate instance of MyTimer
            MyTimer.Interval = TimerDuration; // Set the timer duration
            MyTimer.Start(); // Obviously this line makes cheese fall from the sky
            // Create Event Handler for Timer Tick. Every time MyTimer Ticks... 
            MyTimer.Tick += new EventHandler(Update); // run the Method called Update (see below)

            BorderLeft = 20 + (BorderWidth / 2);
            BorderTop = 20 + (BorderWidth / 2);

            SpriteX = BorderLeft; // Starting at the far left of our window
           
        }

        protected override void OnPaint(PaintEventArgs PaintNow)
        {
            // Update a few things if the window gets resized
            SpriteY = ((this.Height / 2) - MenuHeight); // About halfway down the window (minus menubar height)
            BorderRight = this.Width - BorderLeft - 20 - (BorderWidth * 2);
            BorderBottom = this.Height - BorderTop - 20 - MenuHeight - (BorderWidth * 2);

            // Create rectangle (start position, and size X & Y)
            Rectangle MyRectangle = new Rectangle(SpriteX, SpriteY, SpriteWidth, SpriteHeight);
            SolidBrush whiteBrush = new SolidBrush(Color.White); // Create Brush(Color) to paint rectangle
            PaintNow.Graphics.FillRectangle(whiteBrush, MyRectangle);

            Pen whitePen = new Pen(Color.White);
            whitePen.Width = BorderWidth;
            PaintNow.Graphics.DrawRectangle(whitePen, BorderLeft, BorderTop, BorderRight, BorderBottom);
        }

        public void Update(object sender, System.EventArgs e) // Every time MyTimer ticks
        {
            if (SpriteReverse == false)
                SpriteX += SpriteMove; // Update Sprite position Positive X
            if (SpriteReverse == true)
                SpriteX -= SpriteMove; // Update Sprite position Negative X

            // If Sprite Position = Window width
            if (SpriteX >= BorderRight - (SpriteWidth - BorderLeft) - (BorderWidth / 2 )) // If Sprite reaches screen's Right side
                SpriteReverse = true;
            if (SpriteX <= BorderLeft + (BorderWidth / 2)) // If Sprite reaches screen's Left side
                SpriteReverse = false;

            Invalidate(); // Trigger OnPaint again, creating a loop
        }
    }
}
