//-----------------------------------------------------------------------------
// File: texture.cs
//
// Desc: Better than just lights and materials, 3D objects look much more
//       convincing when texture-mapped. Textures can be thought of as a sort
//       of wallpaper, that is shrinkwrapped to fit a texture. Textures are
//       typically loaded from image files, and D3DX provides a utility to
//       function to do this for us. Like a vertex buffer, textures have
//       Lock() and Unlock() functions to access (read or write) the image
//       data. Textures have a width, height, miplevel, and pixel format. The
//       miplevel is for "mipmapped" textures, an advanced performance-
//       enhancing feature which uses lower resolutions of the texture for
//       objects in the distance where detail is less noticeable. The pixel
//       format determines how the colors are stored in a texel. The most
//       common formats are the 16-bit R5G6B5 format (5 bits of red, 6-bits of
//       green and 5 bits of blue) and the 32-bit A8R8G8B8 format (8 bits each
//       of alpha, red, green, and blue).
//
//       Textures are associated with geometry through texture coordinates.
//       Each vertex has one or more sets of texture coordinates, which are
//       named tu and tv and range from 0.0 to 1.0. Texture coordinates can be
//       supplied by the geometry, or can be automatically generated using
//       Direct3D texture coordinate generation (which is an advanced feature).
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Direct3D=Microsoft.DirectX.Direct3D;

namespace TextureTutorial
{
	public class Textures : Form
	{
		// Our global variables for this project
		Device device = null; // Our rendering device
		VertexBuffer vertexBuffer = null;
		Texture texture = null;
		PresentParameters presentParams = new PresentParameters();
		bool pause = false;


		public Textures()
		{
			// Set the initial size of our form
			this.ClientSize = new System.Drawing.Size(400,300);
			// And its caption
			this.Text = "Direct3D Tutorial 5 - Textures";
		}

		public bool InitializeGraphics()
		{
			try
			{
				presentParams.Windowed=true; // We don't want to run fullscreen
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
			vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionNormalTextured), 100, dev, Usage.WriteOnly, CustomVertex.PositionNormalTextured.Format, Pool.Default);
			vertexBuffer.Created += new System.EventHandler(this.OnCreateVertexBuffer);
			this.OnCreateVertexBuffer(vertexBuffer, null);
		}
		public void OnResetDevice(object sender, EventArgs e)
		{
			Device dev = (Device)sender;
			// Turn off culling, so we see the front and back of the triangle
			dev.RenderState.CullMode = Cull.None;
			// Turn off D3D lighting
			dev.RenderState.Lighting = false;
			// Turn on the ZBuffer
			dev.RenderState.ZBufferEnable = true;
			// Now create our texture
			texture = TextureLoader.FromFile(dev, Application.StartupPath + @"\..\..\banana.bmp");
		}
		public void OnCreateVertexBuffer(object sender, EventArgs e)
		{
			VertexBuffer vb = (VertexBuffer)sender;
			// Create a vertex buffer (100 customervertex)
			CustomVertex.PositionNormalTextured[] verts = (CustomVertex.PositionNormalTextured[])vb.Lock(0,0); // Lock the buffer (which will return our structs)
			for (int i = 0; i < 50; i++)
			{
				// Fill up our structs
				float theta = (float)(2 * Math.PI * i) / 49;
				verts[2 * i].Position = new Vector3((float)Math.Sin(theta), -1, (float)Math.Cos(theta));
				verts[2 * i].Normal = new Vector3((float)Math.Sin(theta), 0, (float)Math.Cos(theta));
				verts[2 * i].Tu = ((float)i)/(50-1);
				verts[2 * i].Tv = 1.0f;
				verts[2 * i + 1].Position = new Vector3((float)Math.Sin(theta), 1, (float)Math.Cos(theta));
				verts[2 * i + 1].Normal = new Vector3((float)Math.Sin(theta), 0, (float)Math.Cos(theta));
				verts[2 * i + 1].Tu = ((float)i)/(50-1);
				verts[2 * i + 1].Tv = 0.0f;
			}
			// Unlock (and copy) the data
			vb.Unlock();
		}
		private void SetupMatrices()
		{
			// For our world matrix, we will just rotate the object about the y-axis.
			device.Transform.World = Matrix.RotationAxis(new Vector3((float)Math.Cos(Environment.TickCount / 250.0f),1,(float)Math.Sin(Environment.TickCount / 250.0f)), Environment.TickCount / 1000.0f );

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
			// what distances geometry should be no longer be rendered).
			device.Transform.Projection = Matrix.PerspectiveFovLH( (float)Math.PI / 4.0f, 1.0f, 1.0f, 100.0f );
		}

		private void Render()
		{
			if (pause)
				return;

			//Clear the backbuffer to a blue color 
			device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, System.Drawing.Color.Blue, 1.0f, 0);
			//Begin the scene
			device.BeginScene();
			// Setup the world, view, and projection matrices
			SetupMatrices();
			// Setup our texture. Using textures introduces the texture stage states,
			// which govern how textures get blended together (in the case of multiple
			// textures) and lighting information. In this case, we are modulating
			// (blending) our texture with the diffuse color of the vertices.
			device.SetTexture(0,texture);
			device.TextureState[0].ColorOperation = TextureOperation.Modulate;
			device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
			device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
			device.TextureState[0].AlphaOperation = TextureOperation.Disable;
	
			device.SetStreamSource(0, vertexBuffer, 0);
			device.VertexFormat = CustomVertex.PositionNormalTextured.Format;
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
				this.Dispose(); // Esc was pressed
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

            using (Textures frm = new Textures())
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
