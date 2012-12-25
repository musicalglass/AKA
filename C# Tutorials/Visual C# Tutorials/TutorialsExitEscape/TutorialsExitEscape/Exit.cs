/// <Title>Exit using Escape Key</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tutorials.EscapeExit
{
    class MyForm : Form
    {
        // Variable Declarations and such go here
        // n/a

        /// <summary>Run MyForm. </summary>
        /// <remarks>We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that!</remarks>
        static void Main( )
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application. </summary>
        MyForm()
        {
            /// <remarks> Setup various Form window attributes. </remarks>
            Size = new Size(400, 300);
            Text = " Hit Escape to Exit";
            CenterToScreen();
        }

        /// <summary>Get Keyboard Input</summary>
        /// <param name="KeyboardPressed"></param>
        protected override void OnKeyDown(KeyEventArgs KeyboardPressed)
        {
            base.OnKeyDown(KeyboardPressed);
            switch (KeyboardPressed.KeyCode)
            {
                case Keys.Escape: // If Escape key is pressed...
                    GC.Collect(0); // Clean up any unused resources 
                    Environment.Exit(0); // Exit Application
                    break;
            }
        }
    }
} // ... and that's all she wrote!
