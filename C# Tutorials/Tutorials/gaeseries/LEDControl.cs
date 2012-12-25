using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace LEDDecoderSim
{
	/// <summary>
	/// Summary description for LEDControl.
	/// </summary>
	public class LEDControl : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LEDControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		Pen ThePen = new Pen(Brushes.Red, 5);
		private void DrawHorizontal(Graphics g, int x, int y)
		{
			g.DrawLine(ThePen, x + 3,(y*this.Height/2), x+Width - 3, (y*Height/2));
		}

		private void DrawVertical(Graphics g, int x, int y)
		{
			g.DrawLine(ThePen, x*Width/2,(y*Height/2) + 3, x*Width/2, (y*Height/2) + Height/2 - 3);
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// LEDControl
			// 
			this.Name = "LEDControl";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.LEDControl_Paint);

		}
		#endregion

		private void LEDControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			if (SegmentA)
			{
				DrawHorizontal(g, 0, 0);			 	
			}
			if (SegmentB)
			{
				DrawVertical(g, 2, 0);			 	
			}
			if (SegmentC)
			{
				DrawVertical(g, 2, 1);			 	
			}
			if (SegmentD)
			{
			 	DrawHorizontal(g, 0, 2);
			}
			if (SegmentE)
			{
				DrawVertical(g, 0, 1);			 	
			}
			if (SegmentF)
			{
				DrawVertical(g, 0, 0);			 	
			}
			if (SegmentG)
			{
				DrawHorizontal(g, 0, 1);
			}
		}

		private bool m_SegmentA = false;
		public bool SegmentA
		{
			get
			{
				return m_SegmentA;
			}

			set
			{	
				m_SegmentA = value;
				this.Invalidate();
			}
		}

		private bool m_SegmentB = false;
		public bool SegmentB
		{
			get
			{
				return m_SegmentB;
			}

			set
			{	
				m_SegmentB = value;
				this.Invalidate();
			}
		}

		private bool m_SegmentC = false;
		public bool SegmentC
		{
			get
			{
				return m_SegmentC;
			}

			set
			{	
				m_SegmentC = value;
				this.Invalidate();
			}
		}

		private bool m_SegmentD = false;
		public bool SegmentD
		{
			get
			{
				return m_SegmentD;
			}

			set
			{	
				m_SegmentD = value;
				this.Invalidate();
			}
		}

		private bool m_SegmentE = false;
		public bool SegmentE
		{
			get
			{
				return m_SegmentE;
			}

			set
			{	
				m_SegmentE = value;
				this.Invalidate();
			}
		}

		private bool m_SegmentF = false;
		public bool SegmentF
		{
			get
			{
				return m_SegmentF;
			}

			set
			{	
				m_SegmentF = value;
				this.Invalidate();
			}
		}

		private bool m_SegmentG = false;
		public bool SegmentG
		{
			get
			{
				return m_SegmentG;
			}

			set
			{	
				m_SegmentG = value;
				this.Invalidate();
			}
		}






	}
}
