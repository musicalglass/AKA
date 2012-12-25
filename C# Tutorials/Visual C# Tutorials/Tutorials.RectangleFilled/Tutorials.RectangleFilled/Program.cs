/// <Title>Draw a Dot</Title>
/// <Trademark>Tutorials1 in plain English by Dillinger</Trademark>
/// <Copyright>Copyright ©  2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.RectangleFilled
{
    class DMC : Form
    {
        // Variable Declarations and such go here
        //

        /// <summary>Run DMC </summary>
        /// <remarks>We don't actually Run DMC. Nooooooooo.
        /// We instantiate an instance of DMC and run that!</remarks>
        static void Main(string[] args)
        {
            Application.Run(new DMC());
        }

        /// <summary> Da Main Constructah! </summary>
        DMC()
        {
            /// <remarks> Setup various Form window stuff. </remarks>
            SuspendLayout();
            Size = new Size(400, 300);
            BackColor = Color.Black;
            Text = " Draw a Rectangle";
            CenterToScreen();
            ResumeLayout(false);

            /// <remarks>Create SprayPaint Event Handlah: 
            /// Yo bro, I'm about to break it down fo ya.
            /// When the main Windows man says it's time to get down,
            /// do yo funky grafitti thang</remarks>
            Paint += new PaintEventHandler(DoGrafitti); 
        }

        /// <summary>Tag the neighborhood. </summary>
        /// <remarks>Triggered by the Paint event.</remarks>
        /// <param name="sender"></param> <param name="PaintNow"></param>
        void DoGrafitti(Object sender, PaintEventArgs Tag)
        {
            // Make rectangle clone (Top Left X, Top Left Y, Width, Height)
            Rectangle MyRectangle = new Rectangle(150, 75, 100, 100); 
            SolidBrush RedBrush = new SolidBrush(Color.Red); // Grab a can o red SprayPaint

            Tag.Graphics.FillRectangle(RedBrush, MyRectangle); // Blast teacher with pepper spray
        }
    }
}
