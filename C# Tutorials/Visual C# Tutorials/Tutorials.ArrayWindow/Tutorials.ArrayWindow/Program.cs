using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.ArrayWindow
{
    class MyForm : Form
    {
        // Variable Declarations and such
        string UserInputString = null;
        int LevelDifficulty = 3;
        int Counter = 0;
        int[] UserInputArray = new int[3];

        static void Main(string[] args)
        {
            Application.Run(new MyForm());
        }

        MyForm() // The Constructor for our application
        {
            SuspendLayout();
            Size = new Size(400, 300);
            AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            Text = "Graphic Input Output";
            CenterToScreen();
            ResumeLayout(false);

            // Create OnPaint Event Handler: fired every time Windows says it's time to repaint the canvas
            Paint += new PaintEventHandler(OnPaint);
        }

        void OnPaint(Object sender, PaintEventArgs e) // The Main "Loop" of our program
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            Font font = new Font("Arial", 16);
            e.Graphics.DrawString("Enter a " + LevelDifficulty + " digit number", font, blackBrush, 20, 20);

            if (Counter == LevelDifficulty)
            {
                e.Graphics.DrawString("You Entered: " + UserInputString, font, blackBrush, 20, 80);
                Counter = 0;
                UserInputString = null;
            }

            else
            {         // Continue to update numerical output to screen as user types
                e.Graphics.DrawString("" + UserInputString, font, blackBrush, 50, 50);
            }
        }
        /// <summary>Keypress event.</summary>
        /// <param name="e">Event arguments</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.D0:
                case Keys.NumPad0:
                    UserInputString = UserInputString + "0";
                    UserInputArray[Counter] = 0;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D1 :
                case Keys.NumPad1:
                    UserInputString = UserInputString + "1";
                    UserInputArray[Counter] = 1;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D2:
                case Keys.NumPad2:
                    UserInputString = UserInputString + "2";
                    UserInputArray[Counter] = 2;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D3:
                case Keys.NumPad3:
                    UserInputString = UserInputString + "3";
                    UserInputArray[Counter] = 3;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D4:
                case Keys.NumPad4:
                    UserInputString = UserInputString + "4";
                    UserInputArray[Counter] = 4;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D5:
                case Keys.NumPad5:
                    UserInputString = UserInputString + "5";
                    UserInputArray[Counter] = 5;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D6:
                case Keys.NumPad6:
                    UserInputString = UserInputString + "6";
                    UserInputArray[Counter] = 6;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D7:
                case Keys.NumPad7:
                    UserInputString = UserInputString + "7";
                    UserInputArray[Counter] = 7;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D8:
                case Keys.NumPad8:
                    UserInputString = UserInputString + "8";
                    UserInputArray[Counter] = 8;
                    Counter++;
                    Invalidate();
                    break;

                case Keys.D9:
                case Keys.NumPad9:
                    UserInputString = UserInputString + "9";
                    UserInputArray[Counter] = 9;
                    Counter++;
                    Invalidate();
                    break;
            }
        }
    }
}