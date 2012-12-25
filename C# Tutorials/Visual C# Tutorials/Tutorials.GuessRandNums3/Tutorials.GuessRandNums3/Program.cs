using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tutorials.GuessRandNum
{
    class MyForm : Form
    {
        // Variable Declarations and such
        string GameState = "start";
        string UserInputString = null;
        string TempString = null;
        int LevelDifficulty = 3;
        int Counter = 0;
        int ExactMatches = 0;
        int NumberOfMatches = 0;

        int[] RandNums = new int[24]; // Create an Array to store sequence of Random Numbers
        int[] UserInputArray = new int[24]; // Array to store User Input
        int[] TempArray = new int[24]; // Swap Array: for comparing arrays
        
        Random r = new Random();// Initialize Random number generator

        static void Main(string[] args)
        {
            Application.Run(new MyForm());
        }

        MyForm() // The Constructor for our application
        {
            // Setup various Form window attributes
            SuspendLayout();
            Size = new Size(400, 300);
            AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            Text = "Random Array";
            CenterToScreen();
            ResumeLayout(false);

            // Create OnPaint Event Handler: fired every time Windows says it's time to repaint the canvas
            Paint += new PaintEventHandler(OnPaint);
        }

        void OnPaint(Object sender, PaintEventArgs e) // The Main "Loop" of our program
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            Font font = new Font("Arial", 16);
            switch (GameState)
            {
                case "start":
                    TempString = null;

                    e.Graphics.DrawString("Press Enter to begin", font, blackBrush, 20, 20);
                    e.Graphics.DrawString("Or enter a new Level of Difficulty", font, blackBrush, 20, 50);
                    e.Graphics.DrawString("Current Level of Difficulty: " + LevelDifficulty, font, blackBrush, 20, 80);

                    // Use a for loop to fill array with Random Numbers
                    for (int iCounter = 0; iCounter < LevelDifficulty; iCounter++)
                    {
                        RandNums[iCounter] = r.Next(10);
                    }
                    break;

                case "endgame":
                    e.Graphics.DrawString("Correct! Again  ", font, blackBrush, 20, 90);
                    break;

                case "game":
                    
                    // Prompt user for input
                    if (UserInputString == null) // Only prompt user for input if they haven't already entered something
                    {
                        e.Graphics.DrawString("Enter a " + LevelDifficulty + " digit number", font, blackBrush, 20, 20);
                    }

                    // Use a foreach loop to write Random Numbers to String
                    TempString = null;
                    for (int iArraySpace = 0; iArraySpace < LevelDifficulty; iArraySpace++)
                    {
                        TempString += RandNums[iArraySpace]; 
                    }
                    // Print Random Numbers String to screen
                    e.Graphics.DrawString("Hint: " + TempString, font, blackBrush, 20, 180);
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
                            // Now for each cell in the first array...
                            // use a second "Nested" For Loop to cycle through
                            // each cell in the second array
                            for (int bCounter = 0; bCounter < LevelDifficulty; bCounter++)
                            {
                                if (TempArray[aCounter] == UserInputArray[bCounter]) // If a match is found anywhere in the Array...
                                {
                                    TempArray[aCounter] = TempArray[aCounter] + 10; // mark it as read by putting it out of range
                                    NumberOfMatches++; // Add it to the counter
                                    break; // Look no further in this Array. Break out of this loop and proceed with the outer loop
                                }
                            }
                        }

                        if (ExactMatches == LevelDifficulty)
                        {
                            GameState = "endgame";
                            Invalidate();
                        }
                        if (ExactMatches != LevelDifficulty)
                        {
                            e.Graphics.DrawString("You entered: " + UserInputString, font, blackBrush, 20, 40);
                            e.Graphics.DrawString("You have " + NumberOfMatches + " right", font, blackBrush, 20, 80);
                            e.Graphics.DrawString("" + ExactMatches + " in the correct order", font, blackBrush, 20, 110);
                        }
                        Counter = 0;
                        UserInputString = null;
                    }

                    if (Counter != LevelDifficulty)
                        e.Graphics.DrawString("" + UserInputString, font, blackBrush, 20, 60);
                    break;

            }
        }
        /// <summary>Keypress event.</summary>
        /// <param name="e">Event arguments</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (GameState)
            {
                case "start":

                 base.OnKeyDown(e);
                 switch (e.KeyCode)
                 {
                     case Keys.Enter:
                        GameState = "game";
                        Invalidate();
                        break;

                    case Keys.D1:
                    case Keys.NumPad1:
                        TempString = TempString + "1";
                        Invalidate();
                        break;

                    case Keys.D2:
                    case Keys.NumPad2:
                        TempString = TempString + "2";
                        Invalidate();
                        break;

                    case Keys.D3:
                    case Keys.NumPad3:
                        TempString = TempString + "3";
                        Invalidate();
                        break;

                    case Keys.D4:
                    case Keys.NumPad4:
                        TempString = TempString + "4";
                        Invalidate();
                        break;

                    case Keys.D5:
                    case Keys.NumPad5:
                        TempString = TempString + "5";
                        Invalidate();
                        break;

                    case Keys.D6:
                    case Keys.NumPad6:
                        TempString = TempString + "6";
                        Invalidate();
                        break;

                    case Keys.D7:
                    case Keys.NumPad7:
                        TempString = TempString + "7";
                        Invalidate();
                        break;

                    case Keys.D8:
                    case Keys.NumPad8:
                        TempString = TempString + "8";
                        Invalidate();
                        break;

                    case Keys.D9:
                    case Keys.NumPad9:
                        TempString = TempString + "9";
                        Invalidate();
                        break;

                    case Keys.D0:
                    case Keys.NumPad0:
                        TempString = TempString + "0";
                        Invalidate();
                        break;
                 }
                    if ( TempString != null )
                 LevelDifficulty = int.Parse(TempString);
                 break;

                case "game":

                    base.OnKeyDown(e);

                    switch (e.KeyCode)
                    {

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
                    break;

                case "endgame":

                    base.OnKeyDown(e);
                    switch (e.KeyCode)
                    {

                        case Keys.Space:
                        case Keys.Enter:
                            GameState = "start";
                            Invalidate();
                            break;

                        case Keys.Escape:
                            this.Close();
                            break;
                    }
               break;
              }
            }
        }
    }
