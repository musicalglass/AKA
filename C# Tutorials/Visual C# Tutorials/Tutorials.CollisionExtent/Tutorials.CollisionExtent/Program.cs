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
        bool CollisionDetected = false, CollisionX = false, CollisionY = false;
        bool TopCollision = false, BottomCollision = false;
      //  int ZoneLeftCoord = 120, ZoneWidth = 130;
       // int ZoneTopCoord = 60, ZoneHeight = 140;

        int ZoneX = 185;
        int ZoneY = 130;
        int ZoneWidth = 130, ZoneHeight = 140;
        int ZoneLeft, ZoneRight;
        int ZoneTop, ZoneBottom;
        // These positions represent the CENTER of our Sprite rectangle
        int SpriteX = 100; // Starting position in pixels from left of window, to right
        // Contrary to High School Geometry, in Windows Forms, Y is DOWN! Don't ask me Y
        int SpriteY = 100; // From top to bottom??! 

        int SpriteWidth = 24, SpriteHeight = 30;
        int SpriteLeft, SpriteRight;
        int SpriteTop, SpriteBottom;

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
            Text = " Collision on Either Side";
            BackColor = Color.Black;
            CenterToScreen();

            /// <remarks>Turn on double-buffering to eliminate flickering </remarks>
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            /// <remarks>Create Paint Event Handler: 
            /// fired every time Windows says it's time to repaint the Form. </remarks>
            Paint += new PaintEventHandler(DrawStuff);

            /// <remarks>Creates a new mouse movement event handler </remarks>
            MouseMove += new MouseEventHandler(MouseMoveUpdate);

            ZoneLeft = ZoneX - (ZoneWidth / 2); // The left side is half the Width to the left of Center
            ZoneRight = ZoneX + (ZoneWidth / 2); // Half the Width to the right
            ZoneTop = ZoneY - (ZoneHeight / 2); // obviously this must turn seaweed into fertilizer
            ZoneBottom = ZoneY + (ZoneHeight / 2);
        }

        /// <summary> The Main "Loop" of our program </summary>
        /// <remarks>Since this is Event based, the Form Window is only
        /// updated when something happens: like a mouse being moved.
        /// Otherwise, no resources are being used</remarks>
        void DrawStuff(Object sender, PaintEventArgs PaintNow)
        {
            UpdateSprite();

            // Draw Sprite( DefaultPen.Color, Rectangle.Type ( Coords Left, Top, Right, Bottom ))
            PaintNow.Graphics.DrawRectangle(Pens.Green, Rectangle.FromLTRB(ZoneLeft, ZoneTop, ZoneRight, ZoneBottom));

            float DistanceX = Math.Abs(ZoneX - SpriteX); // The distance from Center to Center in X
            float DistanceY = Math.Abs(ZoneY - SpriteY);

            if 
                (
                // If the overall distance is greater than the distance from edge to edge of both objects
                ( DistanceX < ( (SpriteWidth / 2) + (ZoneWidth / 2) ) )
                && 
                ( DistanceY < ( (SpriteHeight / 2) + (ZoneHeight / 2) ) ) 
                )
                CollisionDetected = true;
            else
                CollisionDetected = false;



            Font Arial12 = new Font("Arial", 12); // Create Arial 12 point font
            SolidBrush RedBrush = new SolidBrush(Color.Red); // Create font Color
            PaintNow.Graphics.DrawString(
                "Sprite Center X Coords: " + SpriteX, Arial12, RedBrush, 20, 12); // Print Sprite Center coords to screen
            PaintNow.Graphics.DrawString(
                "Sprite Left Coords: " + SpriteLeft, Arial12, RedBrush, 20, 34); // Print Sprite Left coords
            PaintNow.Graphics.DrawString(
                "Sprite Right Coords: " + SpriteRight, Arial12, RedBrush, 20, 56); // Print Sprite Right coords
            PaintNow.Graphics.DrawString(
                "Left Collision " + LeftCollision, Arial12, RedBrush, 20, 130);
            PaintNow.Graphics.DrawString(
                "Right Collision " + RightCollision, Arial12, RedBrush, 20, 150);
            PaintNow.Graphics.DrawString(
                "Collision Detected = " + CollisionDetected, Arial12, RedBrush, 20, 200);

            // Draw Sprite( DefaultPen.Color, Rectangle.Type ( Coords Left, Top, Right, Bottom ))
            PaintNow.Graphics.FillRectangle(new SolidBrush(Color.Orange), Rectangle.FromLTRB(SpriteLeft, SpriteTop, SpriteRight, SpriteBottom));

            // Create Sprite rectangle ( start position X , Y, and size Width , Height )
            Rectangle SpriteCenter = new Rectangle(SpriteX, SpriteY, 2, 2);
            // Draw Sprite Center
            PaintNow.Graphics.FillRectangle(new SolidBrush(Color.White), SpriteCenter);
        }
        public void UpdateSprite()
        {
            SpriteLeft = SpriteX - (SpriteWidth / 2); // The left side is half the Width to the left of Center
            SpriteRight = SpriteX + (SpriteWidth / 2); // Half the Width to the right
            SpriteTop = SpriteY - (SpriteHeight / 2); // obviously this must turn seaweed into fertilizer
            SpriteBottom = SpriteY + (SpriteHeight / 2);
        }

        /// <summary> Events to update if the mouse is moved </summary>
        /// <param name="sender"></param> 
        /// <param name="GetMousePosition">Get's current position of User's Mouse</param>
        void MouseMoveUpdate(object sender, MouseEventArgs GetMousePosition)
        {
            // Move Dot to Mouse's X coordinate
            SpriteX = GetMousePosition.X - 10; // Set Sprite position to User's current Mouse coords
            SpriteY = GetMousePosition.Y - 20;
            Invalidate(); // Trigger the Paint Event and update our Form window
        }
    }
} // ... and you can take dat to da bank!