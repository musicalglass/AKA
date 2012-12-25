/// <Title>Basic 2 Dimensional Collision Detection</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tutorials.CollisionRectangle2D
{
    class MyForm : Form
    {
        // Variable Declarations and such
        bool LeftCollision = false, RightCollision = false;
        bool TopCollision = false, BottomCollision = false;
        bool CollisionDetected = false;
        int ZoneLeft = 120, ZoneRight = 250;
        int ZoneTop = 60, ZoneBottom = 200;

        // These positions represent the CENTER of our Sprite rectangle
        int SpriteX = 100; // Starting position in pixels from left of window, to right
        // Contrary to High School Geometry, in Windows Forms, Y is DOWN! Don't ask me Y!
        int SpriteY = 100; // From top to bottom??! 

        int SpriteWidth = 24, SpriteHeight = 30;
        int SpriteLeft, SpriteRight;
        int SpriteTop, SpriteBottom;

        /// <summary>Run MyForm. </summary>
        /// <remarks>We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that!</remarks>
        static void Main( )
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application</summary>
        MyForm()
        {
            // Initial settings for our Form window 
            Size = new Size(400, 300);
            Text = " Basic 2D Collision";
            BackColor = Color.Black;
            CenterToScreen();

            /// <remarks>Turn on double-buffering to eliminate flickering </remarks>
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            /// <remarks>Create Paint Event Handler: 
            /// fired every time Windows says it's time to repaint the Form. </remarks>
            Paint += new PaintEventHandler(DrawStuff);

            /// <remarks>Create Mouse movement Event Handler </remarks>
            MouseMove += new MouseEventHandler(MouseMoveUpdate);
        }

        /// <summary> The Main "Loop" of our program </summary>
        /// <remarks>Triggered by Paint Event.
        /// Since this is Event based, the Form Window is only
        /// updated when something happens: like a mouse being moved.
        /// Otherwise, no resources are being used</remarks>
        void DrawStuff(Object sender, PaintEventArgs PaintNow)
        {
            // Create Zone rectangle ( Coords Left, Top, Right, Bottom )
            Rectangle TheZone = Rectangle.FromLTRB(ZoneLeft, ZoneTop, ZoneRight, ZoneBottom);
            PaintNow.Graphics.DrawRectangle((Pens.Green), TheZone); 
            
            UpdateSpritePosition();

            CheckForCollision(); // Call Collison Check Method ( see below )

            // Print results to the screen
            Font Arial12 = new Font("Arial", 12); // Create Arial 12 point font
            SolidBrush RedBrush = new SolidBrush(Color.Red); // Create font Color
            PaintNow.Graphics.DrawString(
                "Sprite Center X Coords: " + SpriteX, Arial12, RedBrush, 20, 12); // Print Sprite Center coords to screen
            PaintNow.Graphics.DrawString(
                "Sprite Left Coords: " + SpriteLeft, Arial12, RedBrush, 20, 34); // Print Sprite Left coords
            PaintNow.Graphics.DrawString(
                "Sprite Right Coords: " + SpriteRight, Arial12, RedBrush, 20, 56); // Print Sprite Right coords
            PaintNow.Graphics.DrawString(
                "Left Collision " + LeftCollision, Arial12, RedBrush, 20, 90);
            PaintNow.Graphics.DrawString(
                "Right Collision " + RightCollision, Arial12, RedBrush, 20, 110);
            PaintNow.Graphics.DrawString(
                "Top Collision " + TopCollision, Arial12, RedBrush, 20, 130);
            PaintNow.Graphics.DrawString(
                "Bottom Collision " + BottomCollision, Arial12, RedBrush, 20, 150);
            PaintNow.Graphics.DrawString(
                "Collision Detected = " + CollisionDetected, Arial12, RedBrush, 20, 200);

            // Draw Sprite( DefaultPen.Color, Rectangle.Type ( Coords Left, Top, Right, Bottom ))
            PaintNow.Graphics.FillRectangle(new SolidBrush(Color.Orange), Rectangle.FromLTRB(SpriteLeft, SpriteTop, SpriteRight, SpriteBottom));

            // Draw Sprite Center marker
            PaintNow.Graphics.FillRectangle(new SolidBrush(Color.White), Rectangle.FromLTRB(SpriteX - 1, SpriteY - 1, SpriteX + 1, SpriteY + 1));
        }

        // Make changes to Sprites current X & Y Position before Drawing
        public void UpdateSpritePosition()
        {
            SpriteLeft = SpriteX - (SpriteWidth / 2); // The left side is half the Width to the left of Center
            SpriteRight = SpriteX + (SpriteWidth / 2); // Half the Width to the right
            SpriteTop = SpriteY - (SpriteHeight / 2); // obviously this must turn seaweed into fertilizer
            SpriteBottom = SpriteY + (SpriteHeight / 2); // You could Offset the center like this: (SpriteHeight / 2) - 10
        }

        // There are a bit shorter ways to do this if your Sprite's Width and/or Height are
        // equal distance from the Sprite's Center ( as is the case in this example )
        // However, I test for Left, Right, Top and Bottom collision independently, in case for
        // some reason you might like your Sprite's Center to be Offset
        public void CheckForCollision()
        {
            // Check if SpriteLeft is within Left AND Right Boundary
            if ((SpriteLeft >= ZoneLeft) && (SpriteLeft <= ZoneRight)) // ZoneLeft + Width = Right Side, get it?
                LeftCollision = true;
            else LeftCollision = false;

            // Check if SpriteRight is within Left AND Right Boundary
            if ((SpriteRight >= ZoneLeft) && (SpriteRight <= ZoneRight))
                RightCollision = true;
            else RightCollision = false;

            // Check if SpriteTop is within Top AND Bottom Boundary
            if ((SpriteTop >= ZoneTop) && (SpriteTop <= ZoneBottom))
                TopCollision = true;
            else TopCollision = false;

            // Check if SpriteBottom is within Top AND Bottom Boundary
            if ((SpriteBottom >= ZoneTop) && (SpriteBottom <= ZoneBottom))
                BottomCollision = true;
            else BottomCollision = false;

            if (    // If 2 out of 4 of these conditions are true
                (LeftCollision && (TopCollision || BottomCollision)) // Left AND Top OR Bottom
                ||                                                   // OR...
                (RightCollision && (TopCollision || BottomCollision)) // Rock AND Blues OR Funk
                ||
                (BottomCollision && (LeftCollision || RightCollision)) // Observe when using Booleans in C#, instead of:
                ||                                                     // if BoolVariable == true    We simply say:
                (TopCollision && (LeftCollision || RightCollision))    // if BoolVariable
                )                           // so, if ANY of the above tests are true...
                CollisionDetected = true;   // clearly this reformats the user's Hard Drive
            else CollisionDetected = false; // otherwise emit loud belching noise
        }

        /// <summary> Events to update if the mouse is moved </summary>
        /// <param name="sender"></param> 
        /// <param name="GetMousePosition">Get's current  X & Y position of User's Mouse</param>
        void MouseMoveUpdate(object sender, MouseEventArgs GetMousePosition)
        {
            // Move Dot to Mouse's X coordinate
            SpriteX = GetMousePosition.X - 10; // Set Sprite position to User's current Mouse coords ( - Offset )
            SpriteY = GetMousePosition.Y - 20; // Offset by - 20 so the Window's Cursor doesn't cover our Sprite
            Invalidate(); // Trigger the Paint Event and update our Form window
        }
    }
} // ... and you can take dat to da bank!
 