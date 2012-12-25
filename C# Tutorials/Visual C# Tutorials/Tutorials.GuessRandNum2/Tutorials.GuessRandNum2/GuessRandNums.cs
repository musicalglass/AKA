using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.GuessRandNum
{
    class MyForm : Form
    {
        // Variable Declarations and such
        string UserInputString = null;
        string TempString = null;
        int LevelDifficulty = 3;
        int Counter = 0;
        int ExactMatches = 0;
        int NumberOfMatches = 0;
        int[] RandNums = new int[3];
        int[] UserInputArray = new int[3];
        int[] TempArray = new int[3];

        static void Main(string[] args)
        {
            Application.Run(new MyForm());
        }

        MyForm() // The Constructor for our application
        {
            SuspendLayout();
            Size = new Size(400, 300);
            AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            Text = "Random Array";
            CenterToScreen();
            ResumeLayout(false);

            // Create OnPaint Event Handler: fired every time Windows says it's time to repaint the canvas
            Paint += new PaintEventHandler(OnPaint);

            // Initialize Random number generator
            Random r = new Random();

            // Use a for loop to fill array with Random Numbers
            for (int iCounter = 0; iCounter < LevelDifficulty; iCounter++)
            {
                RandNums[iCounter] = r.Next(10);
            }
        }

        void OnPaint(Object sender, PaintEventArgs e) // The Main "Loop" of our program
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            Font font = new Font("Arial", 16); 
            // Prompt user for input
            e.Graphics.DrawString("Enter a " + LevelDifficulty + " digit number", font, blackBrush, 20, 20);

            // Use a foreach loop to write Random Numbers to String
            foreach (int iArraySpace in RandNums)
                TempString += iArraySpace;
            // Print Random numbers to screen
            e.Graphics.DrawString("Random Number: " + TempString, font, blackBrush, 20, 120);
            TempString = null; // Reset TempString for future use

            if (Counter == LevelDifficulty) // Once user has entered the required number of inputs
            {
                // Count the number of exact matches
                ExactMatches = 0; // Reset Exact match counter to 0 before counting
                for (int iCounter = 0; iCounter < LevelDifficulty; iCounter++)
                {   // If one array matches the other's corresponding cell..
                    if (RandNums[iCounter] == UserInputArray[iCounter]) 
                    ExactMatches++;
                }

          // Copy RandNums to TempArray using a For Loop
          for (int iArrayCell = 0; iArrayCell < LevelDifficulty; iArrayCell++)
          {
            TempArray[iArrayCell] = RandNums[iArrayCell];
          }
                // Check for matches not necessarily in the correct order
                NumberOfMatches = 0; // Reset the counter before counting
                // Use a For Loop to iterate through each of MyNum Array Cells
                    for (int aCounter = 0; aCounter < LevelDifficulty; aCounter++)
			{
			// Compare each cell consecutively to each of the other's
                    for (int bCounter = 0; bCounter < LevelDifficulty; bCounter++)
                    {
                        if (TempArray[aCounter] == UserInputArray[bCounter])
                        {
                            TempArray[aCounter] = TempArray[aCounter] + 10; // Mark it as read by putting it out of range
                            NumberOfMatches++;
                            break;
                        }
                    } 
			}

            if (ExactMatches == LevelDifficulty)
            {
                e.Graphics.DrawString("Correct!  ", font, blackBrush, 20, 160);

            }
            else
            {
                e.Graphics.DrawString("You have  " + NumberOfMatches + " right", font, blackBrush, 20, 160);
                e.Graphics.DrawString("" + ExactMatches + " in order", font, blackBrush, 20, 180);
            }
                Counter = 0;
                UserInputString = null;
            }

            else e.Graphics.DrawString("" + UserInputString, font, blackBrush, 50, 50);


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

                case Keys.D1:
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