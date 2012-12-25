//-----------------------------------------------------------------------------
// File: CreateDevice.cs
//
// Desc: This is the first tutorial for using Direct3D. In this tutorial, all
//       we are doing is creating a Direct3D device and using it to clear the
//       window.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace DeviceTutorial
{
	public class CreateDevice : Form
	{
		// Our global variables for this project
		Device device = null; // Our rendering device

		public CreateDevice()
		{
			// Set the initial size of our form
			this.ClientSize = new System.Drawing.Size(400,300);
			// And it's caption
			this.Text = "My Window";
		}
		
		public bool InitializeGraphics()
		{
			try
			{
				// Now let's setup our D3D stuff
				PresentParameters presentParams = new PresentParameters();
				presentParams.Windowed=true;
				presentParams.SwapEffect = SwapEffect.Discard;
				device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
				return true;
			}
			catch (DirectXException)
            { 
                return false; 
            }
		}
		private void Render()
		{
			if (device == null) 
				return;

			//Clear the backbuffer to a black color 
			device.Clear(ClearFlags.Target, System.Drawing.Color.Black , 1.0f, 0);
			//Begin the scene
			device.BeginScene();
			
			// Rendering of scene objects can happen here
    
			//End the scene
			device.EndScene();
			device.Present();
		}
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			this.Render(); // Render on painting
		}
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			if ((int)(byte)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
				this.Close(); // Esc was pressed
		}

		/// <summary>The main entry point for the application. </summary>
		static void Main() 
		{

            using (CreateDevice frm = new CreateDevice())
            {
                if (!frm.InitializeGraphics()) // Initialize Direct3D
                {
                    MessageBox.Show("Could not initialize Direct3D.  This program will exit.");
                    return;
                }
                frm.Show();

                // While the form is still valid, render and process messages
                while(frm.Created)
                {
                    frm.Render();
                    Application.DoEvents();
                }
            }
		}
	}
}
