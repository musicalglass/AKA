/// <Title>Move Dot using Mouse</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright © 2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tutorials.MoveMouseX
{
    class MyForm : Form
    {
        // Variable Declarations and such
        // These positions represent the Left, Top corner of our "Sprite" rectangle
        int SpriteX = 100; // Starting position in pixels from left of window, to right
        // Contrary to High School Geometry, in Windows Forms, Y is DOWN! Don't ask me Y!
        int SpriteY = 70; // From top to bottom??! 

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
            //Initial settings for our Form window 
            Size = new Size(400, 300);
            Text = " Move Mouse Left & Right";
            BackColor = Color.Black;
            CenterToScreen();

            /// <remarks>Turn on double-buffering to eliminate flickering </remarks>
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            /// <remarks>Create Paint Event Handler: 
            /// fired every time Windows says it's time to repaint the Form. </remarks>
            Paint += new PaintEventHandler(RenderStuff);

            /// <remarks>Create a new Mouse movement Event Handler </remarks>
            MouseMove += new MouseEventHandler(MouseMoveUpdate);
        }

        /// <summary> The Main "Loop" of our program </summary>
        /// <remarks>Since this is Event based, the Form Window is only
        /// updated when something happens: like a mouse being moved.
        /// Otherwise, no resources are being used</remarks>
        void RenderStuff(Object sender, PaintEventArgs PaintNow)
        {
            Rectangle Dot = new Rectangle(SpriteX, SpriteY, 2, 2); // Create rectangle (start position, and size X & Y)
            SolidBrush WhiteBrush = new SolidBrush(Color.White); // Create Brush(Color) to paint rectangle

            PaintNow.Graphics.FillRectangle(WhiteBrush, Dot); // Play Parcheesi!
        }

        /// <summary> Events to update if the Mouse is moved </summary>
        /// <param name="sender"></param> 
        /// <param name="GetMousePosition">Get's current position of User's Mouse</param>
        void MouseMoveUpdate(object sender, MouseEventArgs GetMousePosition)
        {
            // Move Sprite to Mouse's X coordinate
            SpriteX = GetMousePosition.X; // Set Sprite position to User's current Mouse coords
            Invalidate(); // Trigger the Paint Event and update our Form window
        }
    }
} // ... and that's the meaning of life, the universe... all that good stuff!
 