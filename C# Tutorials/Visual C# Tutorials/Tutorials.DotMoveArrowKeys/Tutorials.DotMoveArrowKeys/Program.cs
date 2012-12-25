/// <Title>See Dot Move using Arrow Keys</Title>
/// <remarks>Example demonstrates Event Based movement </remarks>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tutorials.MoveArrowKeys
{
    class MyForm : Form
    {
        // Variable Declarations and such
        // Note: These positions represent the top, left corner of our "Sprite" rectangle
        int SpriteX = 100; // Starting position in pixels from left of window, to right
        int SpriteY = 70; // From top to bottom??! In Windows Forms, Y is DOWN!

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
            //Size = new Size(360, 300);
            Text = " Press the Arrow Keys";
            BackColor = Color.Black;
            CenterToScreen();

            /// <remarks>Turn on double-buffering to eliminate flickering </remarks>
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            /// <remarks>Create OnPaint Event Handler: 
            /// fired every time Windows says it's time to repaint the canvas. </remarks>
            Paint += new PaintEventHandler(RenderStuff);
        }

        /// <summary> The Main "Loop" of our program </summary>
        /// <remarks>Since this is Event based, the Form Window is only
        /// updated when something happens: like a key being pressed.
        /// Otherwise, no resources are being used</remarks>
        void RenderStuff(Object sender, PaintEventArgs PaintNow)
        {
            Rectangle Dot = new Rectangle(SpriteX, SpriteY, 2, 2); // Create rectangle (start position, and size X & Y)
            SolidBrush whiteBrush = new SolidBrush(Color.White); // Create Brush(Color) to paint rectangle

            PaintNow.Graphics.FillRectangle(whiteBrush, Dot);
        }
        /// <summary>Keypress event.</summary>
        protected override void OnKeyDown(KeyEventArgs KeyboardInput)
        {
            switch (KeyboardInput.KeyCode)
            {
                case Keys.Right: // If Right Arrow key is pressed
                    SpriteX = SpriteX + 2; // Update Sprite postion
                    Invalidate(); // Trigger the Paint event all over again, creating a "render loop"
                    break; // end case statement

                case Keys.Left: // Then clearly this must make guacamole!
                    SpriteX = SpriteX - 2;
                    Invalidate();
                    break;

                case Keys.Up:
                    SpriteY = SpriteY - 2;
                    Invalidate();
                    break;

                case Keys.Down:
                    SpriteY = SpriteY + 2;
                    Invalidate();
                    break;

                case Keys.Escape: // If Escape key is pressed...
                    GC.Collect(0); // clean up any unused resources 
                    Environment.Exit(0); // and bail
                    break;
            }
        }
    }
} // ... and you can take dot to da bank!
 