using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tutorials.DrawingATriangleFan
{
    static class Program
    {
        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        static void Main()
        {
            //Create an object from our class
            using (MyForm form = new MyForm())
            {
                form.Run();
            }
        }
    }
}