/// <Title>Basic 1 dimensional Collision Detection</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tutorials.CollisionX
{
    class MyForm : Form
    {
        // Variable Declarations and such
        bool LeftCollision = false, RightCollision = false, CollisionDetected = false;
        int ZoneLeftCoord = 150, ZoneRightCoord = 100;
        // These positions represent the Left, Top corner of our "Sprite" rectangle
        int SpriteX = 100; // Starting position in pixels from left of window, to right
        // Contrary to High School Geometry, in Windows Forms, Y is DOWN! Don't ask me Y
        int SpriteY = 50; // From top to bottom??! 

        /// <summary>Run MyForm. </summary>
        /// <remarks>We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that!</remarks>
        static void Main(string[] args)
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application</summary>
        MyForm()
        {
            //Initial settings for our Form window 
            Size = new Size(400, 300);
            Text = " Collision Detection 101";
            BackColor = Color.Black;
            CenterToScreen();

            /// <remarks>Turn on double-buffering to eliminate flickering </remarks>
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            /// <remarks>Create OnPaint Event Handler: 
            /// fired every time Windows says it's time to repaint the Form. </remarks>
            Paint += new PaintEventHandler(DrawStuff);

            /// <remarks>Creates a new mouse movement event handler </remarks>
            MouseMove += new MouseEventHandler(MouseMoveUpdate);
        }

        /// <summary> The Main "Loop" of our program </summary>
        /// <remarks>Since this is Event based, the Form Window is only
        /// updated when something happens: like a mouse being moved.
        /// Otherwise, no resources are being used</remarks>
        void DrawStuff(Object sender, PaintEventArgs PaintNow)
        {
            // Create Zone rectangle ( start position X , Y, and size Width , Height )
            Rectangle TheZone = new Rectangle(ZoneLeftCoord, 14, ZoneRightCoord, 230); 
            PaintNow.Graphics.DrawRectangle((Pens.Green), TheZone);

            Font Arial12 = new Font("Arial", 12); // Create Arial 12 point font
            SolidBrush RedBrush = new SolidBrush(Color.Red); // Create font Color
            PaintNow.Graphics.DrawString(
                "Mouse Coordinates X: " + SpriteX, Arial12, RedBrush, 30, 16); // Print Sprite coords to screen

        // Check if Sprite is Within Left Boundary
        if (SpriteX >= ZoneLeftCoord)
            LeftCollision = true;
        else
            LeftCollision = false;

        // Check if Sprite is Within Right Boundary
        if (SpriteX <= (ZoneLeftCoord + ZoneRightCoord))
            RightCollision = true;
        else
            RightCollision = false;

            PaintNow.Graphics.DrawString(
                "If (Mouse Position X >= 150) ", Arial12, RedBrush, 14, 70);
            PaintNow.Graphics.DrawString(
                "Zone Collision Left: " + LeftCollision, Arial12, RedBrush, 14, 90);

            PaintNow.Graphics.DrawString(
                "If (Mouse Position X <= 250) ", Arial12, RedBrush, 14, 130);
            PaintNow.Graphics.DrawString(
                "Zone Collision Right: " + RightCollision, Arial12, RedBrush, 14, 150);

        // Check if both boundaries are True. If yes, Collision! (That's a good thing)
            if ( RightCollision && LeftCollision )
                CollisionDetected = true; 
        else
            CollisionDetected = false;

            PaintNow.Graphics.DrawString(
                "If (LeftCollision && RightCollision == True)", Arial12, RedBrush, 10, 200);
            PaintNow.Graphics.DrawString(
                "Collision Detected: " + CollisionDetected, Arial12, RedBrush, 14, 220);

            // Create Sprite rectangle ( start position X , Y, and size Width , Height )
            Rectangle Dot = new Rectangle(SpriteX, SpriteY, 3, 3); 
            PaintNow.Graphics.FillRectangle(new SolidBrush(Color.White), Dot);
        }

        /// <summary> Events to update if the mouse is moved </summary>
        /// <param name="sender"></param> 
        /// <param name="GetMousePosition">Get's current position of User's Mouse</param>
        void MouseMoveUpdate(object sender, MouseEventArgs GetMousePosition)
        {
            // Move Dot to Mouse's X coordinate
            SpriteX = GetMousePosition.X; // Set Sprite position to User's current Mouse coords
            Invalidate(); // Trigger the Paint Event and update our Form window
        }
    }
} // ... and that's the name of that tune!