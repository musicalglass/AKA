// AttributeParamsDemo.cs
//  Using Positional and Named Attribute Parameters
using System;
using System.Runtime.InteropServices;

class AttributeParamsDemo
{
    [DllImport("User32.dll", EntryPoint="MessageBox")]
    static extern int MessageDialog(int hWnd, string msg, string caption, int msgType);

    [STAThread]
    static void Main(string[] args)
    {
        MessageDialog(0, "MessageDialog Called!", "DllImport Demo", 0);
    }
}

