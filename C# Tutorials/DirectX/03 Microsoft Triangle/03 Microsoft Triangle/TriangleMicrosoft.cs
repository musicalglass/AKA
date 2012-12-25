//-----------------------------------------------------------------------------
// File: Triangle.cs
//
// Desc: In this tutorial, we are rendering some vertices. This introduces the
//       concept of the vertex buffer, a Direct3D object used to store
//       vertices. Vertices can be defined any way we want by defining a
//       custom structure and a custom FVF (flexible vertex format). In this
//       tutorial, we are using vertices that are transformed (meaning they
//       are already in 2D window coordinates) and lit (meaning we are not
//       using Direct3D lighting, but are supplying our own colors).
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace VerticesTutorial
{
    public class Vertices : Form
    {
        // Our global variables for this project

        Device device = null; // Our rendering device
        VertexBuffer vertexBuffer = null;
        int BufferSize = 3;

        public Vertices()
        {
            // Set the initial size of our form
            this.ClientSize = new System.Drawing.Size(300, 300);
            // And its caption
            this.Text = "Microsoft Coords";
        }

        public bool InitializeGraphics()
        {
            try
            {
                // Now let's setup our D3D stuff
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
                this.OnCreateDevice(device, null);
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
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.TransformedColored), BufferSize, dev, 0, CustomVertex.TransformedColored.Format, Pool.Default);
            vertexBuffer.Created += new System.EventHandler(this.OnCreateVertexBuffer);
            this.OnCreateVertexBuffer(vertexBuffer, null);
        }
        public void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            VertexBuffer vb = (VertexBuffer)sender;
            GraphicsStream stm = vb.Lock(0, 0, 0);
            CustomVertex.TransformedColored[] verts = new CustomVertex.TransformedColored[BufferSize];

            verts[0].X = 50; verts[0].Y = 50; verts[0].Z = 0.5f;
            verts[0].Rhw = 1; verts[0].Color = System.Drawing.Color.Black.ToArgb();
            verts[1].X = 250; verts[1].Y = 50; verts[1].Z = 0.5f;
            verts[1].Rhw = 1; verts[1].Color = System.Drawing.Color.Black.ToArgb();
            verts[2].X = 150; verts[2].Y = 250; verts[2].Z = 0.5f;
            verts[2].Rhw = 1; verts[2].Color = System.Drawing.Color.Black.ToArgb();
            stm.Write(verts);
            vb.Unlock();
        }
        private void Render()
        {
            if (device == null)
                return;

            //Clear the backbuffer to a blue color (ARGB = 000000ff)
            device.Clear(ClearFlags.Target, System.Drawing.Color.Blue, 1.0f, 0);
            //Begin the scene
            device.BeginScene();

            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = CustomVertex.TransformedColored.Format;
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
            //End the scene
            device.EndScene();
            device.Present();
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pea)
        {
            this.Render(); // Render on painting
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)(byte)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
                this.Close(); // Esc was pressed
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            using (Vertices frm = new Vertices())
            {
                if (!frm.InitializeGraphics()) // Initialize Direct3D
                {
                    MessageBox.Show("Could not initialize Direct3D.  This tutorial will exit.");
                    return;
                }
                frm.Show();

                // While the form is still valid, render and process messages
                while (frm.Created)
                {
                    frm.Render();
                    Application.DoEvents();
                }
            }
        }

    }
}
