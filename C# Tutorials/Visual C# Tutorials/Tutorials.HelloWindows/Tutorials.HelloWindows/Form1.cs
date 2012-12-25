using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tutorials.HelloWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "My Window";
        }
  
        protected override void OnPaint(PaintEventArgs pea)
        {
            pea.Graphics.DrawString("Hello Windows!", this.Font,
                     Brushes.Black, 100, 100);
        }
    }
}