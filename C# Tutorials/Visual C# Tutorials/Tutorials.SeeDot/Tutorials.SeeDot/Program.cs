using System;
using System.Drawing;
using System.Windows.Forms;

namespace Draw_Dot
{
    public partial class DrawDot : Form
    {

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.DrawLine(Pens.Black, 50, 30, 50.1F, 30.1F);
        }


    }
}
