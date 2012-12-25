using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tutorials.DrawTriangle
{
    static class Program
    {
        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        static void Main()
        {
            //Create an object from our class
            using ( MyForm MyGame = new MyForm())
            {
                MyGame.Run();
            }
        }
    }
}