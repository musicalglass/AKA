using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace LEDDecoderSim
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private LEDDecoderSim.LEDControl ledControl1;
		private System.Windows.Forms.CheckBox buttona;
		private System.Windows.Forms.CheckBox buttonb;
		private System.Windows.Forms.CheckBox buttonc;
		private System.Windows.Forms.CheckBox buttond;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			ControlLogic();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ledControl1 = new LEDDecoderSim.LEDControl();
			this.buttona = new System.Windows.Forms.CheckBox();
			this.buttonb = new System.Windows.Forms.CheckBox();
			this.buttonc = new System.Windows.Forms.CheckBox();
			this.buttond = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// ledControl1
			// 
			this.ledControl1.Location = new System.Drawing.Point(96, 48);
			this.ledControl1.Name = "ledControl1";
			this.ledControl1.SegmentA = false;
			this.ledControl1.SegmentB = false;
			this.ledControl1.SegmentC = false;
			this.ledControl1.SegmentD = false;
			this.ledControl1.SegmentE = false;
			this.ledControl1.SegmentF = false;
			this.ledControl1.SegmentG = false;
			this.ledControl1.Size = new System.Drawing.Size(96, 128);
			this.ledControl1.TabIndex = 0;
			// 
			// buttona
			// 
			this.buttona.Location = new System.Drawing.Point(24, 224);
			this.buttona.Name = "buttona";
			this.buttona.Size = new System.Drawing.Size(40, 32);
			this.buttona.TabIndex = 1;
			this.buttona.Text = "a";
			this.buttona.CheckedChanged += new System.EventHandler(this.buttona_CheckedChanged);
			// 
			// buttonb
			// 
			this.buttonb.Location = new System.Drawing.Point(96, 224);
			this.buttonb.Name = "buttonb";
			this.buttonb.Size = new System.Drawing.Size(40, 32);
			this.buttonb.TabIndex = 2;
			this.buttonb.Text = "b";
			this.buttonb.CheckedChanged += new System.EventHandler(this.buttonb_CheckedChanged);
			// 
			// buttonc
			// 
			this.buttonc.Location = new System.Drawing.Point(160, 224);
			this.buttonc.Name = "buttonc";
			this.buttonc.Size = new System.Drawing.Size(32, 32);
			this.buttonc.TabIndex = 3;
			this.buttonc.Text = "c";
			this.buttonc.CheckedChanged += new System.EventHandler(this.buttonc_CheckedChanged);
			// 
			// buttond
			// 
			this.buttond.Location = new System.Drawing.Point(224, 224);
			this.buttond.Name = "buttond";
			this.buttond.Size = new System.Drawing.Size(40, 32);
			this.buttond.TabIndex = 4;
			this.buttond.Text = "d";
			this.buttond.CheckedChanged += new System.EventHandler(this.buttond_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.buttond,
																		  this.buttonc,
																		  this.buttonb,
																		  this.buttona,
																		  this.ledControl1});
			this.Name = "Form1";
			this.Text = "LED 7-Segment Decoder Simulation";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void ControlLogic()
		{
			this.ledControl1.SegmentA = (((buttona.Checked &(!buttonb.Checked))^buttonc.Checked)| (buttond.Checked ^ ((!buttonb.Checked) | buttona.Checked)));
			this.ledControl1.SegmentB = (!   (   (buttona.Checked &  (buttonc.Checked & buttond.Checked) ) |   (     (    (!buttonc.Checked) &   (buttonc.Checked & buttond.Checked) ) ^  (    ( (buttona.Checked | buttonc.Checked) ^   buttond.Checked  ) &    buttonb.Checked    )  ) ));
			this.ledControl1.SegmentC = ((buttonb.Checked ^ buttona.Checked) | (!(((buttonc.Checked & (buttona.Checked ^ buttond.Checked)) ^ buttonc.Checked) | ((buttona.Checked ^ buttond.Checked) & buttona.Checked))));
			this.ledControl1.SegmentD = ((!(buttond.Checked | (buttonb.Checked ^ buttona.Checked))) | ((!(buttond.Checked ^ buttonc.Checked)) ^ buttonb.Checked));
			this.ledControl1.SegmentE = ((!((buttonc.Checked ^ (buttonc.Checked | buttonb.Checked)) | buttond.Checked)) | (buttona.Checked & (buttonb.Checked | buttonc.Checked)));
			this.ledControl1.SegmentF = (((buttonc.Checked & (buttonb.Checked & (buttonc.Checked ^ buttond.Checked))) | (!(buttonc.Checked |buttond.Checked))) | ((buttonb.Checked & (buttonc.Checked ^ buttond.Checked)) ^ buttona.Checked));
			this.ledControl1.SegmentG = ((((!buttond.Checked) & buttonb.Checked) ^ buttona.Checked) | ((((!buttond.Checked) & buttonb.Checked) ^ buttonb.Checked) ^ buttonc.Checked));
		}

		private void buttona_CheckedChanged(object sender, System.EventArgs e)
		{
		  ControlLogic();
		}

		private void buttonb_CheckedChanged(object sender, System.EventArgs e)
		{
			ControlLogic();
		
		}

		private void buttonc_CheckedChanged(object sender, System.EventArgs e)
		{
			ControlLogic();
		
		}

		private void buttond_CheckedChanged(object sender, System.EventArgs e)
		{
			ControlLogic();
		
		}
	}
}
