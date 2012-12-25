#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Samples.DirectX.UtilityToolkit;

#endregion

namespace BattleTank2005
{
    partial class GameEngine : Form
    {
        public GameEngine()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            deltaTime = FrameworkTimer.GetElapsedTime();


            FrameworkTimer.Start();

            this.Invalidate();
        }

        private double deltaTime;
    }
}