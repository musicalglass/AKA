//-----------------------------------------------------------------------------
// File: Matrices.cs
//
// Desc: Now that we know how to create a device and render some 2D vertices,
//       this tutorial goes the next step and renders 3D geometry. To deal with
//       3D geometry we need to introduce the use of 4x4 matrices to transform
//       the geometry with translations, rotations, scaling, and setting up our
//       camera.
//
//       Geometry is defined in model space. We can move it (translation),
//       rotate it (rotation), or stretch it (scaling) using a world transform.
//       The geometry is then said to be in world space. Next, we need to
//       position the camera, or eye point, somewhere to look at the geometry.
//       Another transform, via the view matrix, is used, to position and
//       rotate our view. With the geometry then in view space, our last
//       transform is the projection transform, which "projects" the 3D scene
//       into our 2D viewport.
//
//       Note that in this tutorial, we are introducing the use of D3DX, which
//       is a set of helper utilities for D3D. In this case, we are using some
//       of D3DX's useful matrix initialization functions. To use D3DX, simply
//       include the D3DX reference in your project
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
using System ;
using System.Drawing ;
using System.Windows.Forms ;
using Microsoft.DirectX ;
using Microsoft.DirectX.Direct3D ;
using Direct3D = Microsoft.DirectX.Direct3D ;

namespace MatricesTutorial
{
	public class Matrices : Form
	{
		// Our global variables for this project
		Device device = null; // Our rendering device
		VertexBuffer vertexBuffer = null;
		PresentParameters presentParams = new PresentParameters();
		bool pause = false;

		public Matrices()
		{
			// Set the initial size of our form
			this.ClientSize = new System.Drawing.Size(400,300);
			// And it's caption
			this.Text = "Direct3D 3 - Matrices";
		}

		public bool InitializeGraphics()
		{
			try
			{
				// Now let's setup our D3D stuff
				presentParams.Windowed=true;
				presentParams.SwapEffect = SwapEffect.Discard;
				device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
				device.DeviceReset += new System.EventHandler(this.OnResetDevice);
				this.OnCreateDevice(device, null);
				this.OnResetDevice(device, null);
				pause = false;
				return true;
			}
			catch (DirectXException)
            { 
                return false; 
            }
		}
		public void OnCreateDevice(object sender, EventArgs e)
		{
			Device dev = (Device)sender;
			// Now Create the VB
			vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 3, dev, 0, CustomVertex.PositionColored.Format, Pool.Default);
			vertexBuffer.Created += new System.EventHandler(this.OnCreateVertexBuffer);
			this.OnCreateVertexBuffer( vertexBuffer, null);
		}
		public void OnResetDevice( object sender, EventArgs e )
		{
			Device dev = (Device)sender ;
			// Turn off culling, so we see the front and back of the triangle
			dev.RenderState.CullMode = Cull.CounterClockwise ;
			// Turn off D3D lighting, since we are providing our own vertex colors
			dev.RenderState.Lighting = false ;
		}
		public void OnCreateVertexBuffer( object sender, EventArgs e )
		{
			VertexBuffer vb = ( VertexBuffer )sender;
			CustomVertex.PositionColored[] verts = ( CustomVertex.PositionColored[])vb.Lock(0,0);
			verts[0].X=-1.0f; verts[0].Y=-1.0f; verts[0].Z=0.0f; verts[0].Color = System.Drawing.Color.Tomato.ToArgb();
			verts[1].X=1.0f; verts[1].Y=-1.0f ;verts[1].Z=0.0f; verts[1].Color = System.Drawing.Color.MediumOrchid.ToArgb();
			verts[2].X=0.0f; verts[2].Y=1.0f; verts[2].Z = 0.0f; verts[2].Color = System.Drawing.Color.Cornsilk.ToArgb();
			vb.Unlock();
		}

		private void Render()
		{
			if (device == null) 
				return;

			if (pause)
				return;

			//Clear the backbuffer to a black color 
			device.Clear(ClearFlags.Target, System.Drawing.Color.Black, 1.0f, 0);
			//Begin the scene
			device.BeginScene();
			// Setup the world, view, and projection matrices
			SetupMatrices();
	
			device.SetStreamSource(0, vertexBuffer, 0);
			device.VertexFormat = CustomVertex.PositionColored.Format;
			device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
			//End the scene
			device.EndScene();
			device.Present();
		}

		private void SetupMatrices()
		{
			// For our world matrix, we will just rotate the object about the y-axis.

			// Set up the rotation matrix to generate 1 full rotation (2*PI radians) 
			// every 1000 ms. To avoid the loss of precision inherent in very high 
			// floating point numbers, the system time is modulated by the rotation 
			// period before conversion to a radian angle.
			int  iTime  = Environment.TickCount % 1000;
			float fAngle = iTime * (2.0f * (float)Math.PI) / 2000.0f;
			device.Transform.World = Matrix.RotationY( fAngle );

			// Set up our view matrix. A view matrix can be defined given an eye point,
			// a point to lookat, and a direction for which way is up. Here, we set the
			// eye five units back along the z-axis and up three units, look at the
			// origin, and define "up" to be in the y-direction.
			device.Transform.View = Matrix.LookAtLH( new Vector3( 0.0f, 0.0f,-4.0f ), new Vector3( 0.0f, 0.0f, 10.0f ), new Vector3( 0.0f, 1.0f, 0.0f ) );

			// For the projection matrix, we set up a perspective transform (which
			// transforms geometry from 3D view space to 2D viewport space, with
			// a perspective divide making objects smaller in the distance). To build
			// a perpsective transform, we need the field of view (1/4 pi is common),
			// the aspect ratio, and the near and far clipping planes (which define at
			// what distances geometry should be no longer be rendered).
			device.Transform.Projection = Matrix.PerspectiveFovLH( (float)Math.PI / 4, 1.0f, 1.0f, 100.0f );
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
        protected override void OnResize(System.EventArgs e)
        {
            pause = ((this.WindowState == FormWindowState.Minimized) || !this.Visible);
        }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main() 
		{
            using (Matrices frm = new Matrices())
            {
                if (!frm.InitializeGraphics()) // Initialize Direct3D
                {
                    MessageBox.Show("Could not initialize Direct3D.  This tutorial will exit.");
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
