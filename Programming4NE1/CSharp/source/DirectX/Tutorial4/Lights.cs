//-----------------------------------------------------------------------------
// File: Lights.cs
//
// Desc: Rendering 3D geometry is much more interesting when dynamic lighting
//       is added to the scene. To use lighting in D3D, you must create one or
//       more lights, setup a material, and make sure your geometry contains surface
//       normals. Lights may have a position, a color, and be of a certain type
//       such as directional (light comes from one direction), point (light
//       comes from a specific x,y,z coordinate and radiates in all directions)
//       or spotlight. Materials describe the surface of your geometry,
//       specifically, how it gets lit (diffuse color, ambient color, etc.).
//       Surface normals are part of a vertex, and are needed for the D3D's
//       internal lighting calculations.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Direct3D=Microsoft.DirectX.Direct3D;

namespace LightsTutorial
{
	public class Lights : Form
	{
		// Our global variables for this project
		Device device = null; // Our rendering device
		VertexBuffer vertexBuffer = null;
		PresentParameters presentParams = new PresentParameters();
		bool pause = false;

		public Lights()
		{
			// Set the initial size of our form
			this.ClientSize = new System.Drawing.Size(400,300);
			// And its caption
			this.Text = "Direct3D Tutorial 4 - Lights";
		}

		public bool InitializeGraphics()
		{
			try
			{
				presentParams.Windowed = true ; // We don't want to run fullscreen
				presentParams.SwapEffect = SwapEffect.Discard; // Discard the frames 
				presentParams.EnableAutoDepthStencil = true; // Turn on a Depth stencil
				presentParams.AutoDepthStencilFormat = DepthFormat.D16; // And the stencil format
				device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams); //Create a device
				device.DeviceReset += new System.EventHandler(this.OnResetDevice);
				this.OnCreateDevice(device, null);
				this.OnResetDevice(device, null);
				pause = false;
				return true;
			}
			catch (DirectXException)
			{
				// Catch any errors and return a failure
				return false;
			}
		}
		public void OnCreateDevice(object sender, EventArgs e)
		{
			Device dev = (Device)sender;
			// Now Create the VB
			vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionNormal), 100, dev, Usage.WriteOnly, CustomVertex.PositionNormal.Format, Pool.Default);
			vertexBuffer.Created += new System.EventHandler(this.OnCreateVertexBuffer);
			this.OnCreateVertexBuffer(vertexBuffer, null);
		}
		public void OnResetDevice(object sender, EventArgs e)
		{
			Device dev = (Device)sender;
			// Turn off culling, so we see the front and back of the triangle
			device.RenderState.CullMode = Cull.None;
			// Turn on the ZBuffer
			device.RenderState.ZBufferEnable = true;
			device.RenderState.Lighting = true;    //make sure lighting is enabled
		}
		public void OnCreateVertexBuffer(object sender, EventArgs e)
		{
			VertexBuffer vb = (VertexBuffer)sender;
			// Create a vertex buffer (100 customvertex)
			CustomVertex.PositionNormal[] verts = (CustomVertex.PositionNormal[])vb.Lock(0,0); // Lock the buffer (which will return our structs)
			for (int i = 0; i < 50; i++)
			{
				// Fill up our structs
				float theta = (float)(2 * Math.PI * i) / 49;
				verts[2 * i].Position = new Vector3((float)Math.Sin(theta), -1, (float)Math.Cos(theta));
				verts[2 * i].Normal = new Vector3((float)Math.Sin(theta), 0, (float)Math.Cos(theta));
				verts[2 * i + 1].Position = new Vector3((float)Math.Sin(theta), 1, (float)Math.Cos(theta));
				verts[2 * i + 1].Normal = new Vector3((float)Math.Sin(theta), 0, (float)Math.Cos(theta));
			}
			// Unlock (and copy) the data
			vb.Unlock();
		}
		private void SetupMatrices()
		{
			// For our world matrix, we will just rotate the object about the y-axis.
			device.Transform.World = Matrix.RotationAxis(new Vector3((float)Math.Cos(Environment.TickCount / 250.0f),1,(float)Math.Sin(Environment.TickCount / 250.0f)), Environment.TickCount / 3000.0f );

			// Set up our view matrix. A view matrix can be defined given an eye point,
			// a point to lookat, and a direction for which way is up. Here, we set the
			// eye five units back along the z-axis and up three units, look at the
			// origin, and define "up" to be in the y-direction.
			device.Transform.View = Matrix.LookAtLH( new Vector3( 0.0f, 3.0f,-5.0f ), new Vector3( 0.0f, 0.0f, 0.0f ), new Vector3( 0.0f, 1.0f, 0.0f ) );

			// For the projection matrix, we set up a perspective transform (which
			// transforms geometry from 3D view space to 2D viewport space, with
			// a perspective divide making objects smaller in the distance). To build
			// a perpsective transform, we need the field of view (1/4 pi is common),
			// the aspect ratio, and the near and far clipping planes (which define at
			// what distances geometry should no longer be rendered).
			device.Transform.Projection = Matrix.PerspectiveFovLH( (float)Math.PI / 4.0f, 1.0f, 1.0f, 100.0f );
		}
		private void SetupLights()
		{
			System.Drawing.Color col = System.Drawing.Color.White;
			//Set up a material. The material here just has the diffuse and ambient
			//colors set to yellow. Note that only one material can be used at a time.
			Direct3D.Material mtrl = new Direct3D.Material();
			mtrl.Diffuse = col;
			mtrl.Ambient = col;
			device.Material = mtrl;
			
			//Set up a white, directional light, with an oscillating direction.
			//Note that many lights may be active at a time (but each one slows down
			//the rendering of our scene). However, here we are just using one. Also,
			//we need to set the D3DRS_LIGHTING renderstate to enable lighting
    
			device.Lights[0].Type = LightType.Directional;
			device.Lights[0].Diffuse = System.Drawing.Color.DarkTurquoise;
			device.Lights[0].Direction = new Vector3((float)Math.Cos(Environment.TickCount / 250.0f), 1.0f, (float)Math.Sin(Environment.TickCount / 250.0f));

			device.Lights[0].Enabled = true;//turn it on

			//Finally, turn on some ambient light.
			//Ambient light is light that scatters and lights all objects evenly
			device.RenderState.Ambient = System.Drawing.Color.FromArgb(0x202020);
		}

		private void Render()
		{
			if (pause)
				return;

			//Clear the backbuffer to a blue color 
			device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, System.Drawing.Color.Blue, 1.0f, 0);
			//Begin the scene
			device.BeginScene();
			// Setup the lights and materials
			SetupLights();
			// Setup the world, view, and projection matrices
			SetupMatrices();
	
			device.SetStreamSource(0, vertexBuffer, 0);
			device.VertexFormat = CustomVertex.PositionNormal.Format;
			device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, (4*25)-2);
			//End the scene
			device.EndScene();
			// Update the screen
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
		protected override void OnResize(System.EventArgs e)
		{
            pause = ((this.WindowState == FormWindowState.Minimized) || !this.Visible);
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main() 
		{

            using (Lights frm = new Lights())
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
