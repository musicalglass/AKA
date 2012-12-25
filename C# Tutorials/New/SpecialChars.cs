using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int MyChar = 1; MyChar < 40; MyChar++)
            {
                Console.WriteLine("char {0:D4}: ", ( MyChar * 14 ));
                //Console.WriteLine("{0}", (char)MyChar); 
            }
        }
    }
}
