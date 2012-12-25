// File: My Tile.cs

using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorial.Tiles
{
    public class MyTile : Form
    {
        // Global Variables

        Device device = null; // Our rendering device
        VertexBuffer vertexBuffer = null; // Place to store our Tiles
        int BufferSize = 4 ; // Space for number of Vertices required
            

        public MyTile()
        {
            // Set the initial size of our form
            this.ClientSize = new System.Drawing.Size( 300, 300 );
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
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), BufferSize, dev, 0, CustomVertex.PositionColored.Format, Pool.Default);
            vertexBuffer.Created += new System.EventHandler(this.OnCreateVertexBuffer);
            this.OnCreateVertexBuffer(vertexBuffer, null);
        }

        public void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            VertexBuffer buffer = (VertexBuffer)sender;

            CustomVertex.PositionColored[] verts =
                  new CustomVertex.PositionColored[BufferSize];


            verts[0].Position = new Vector3( 0.32f, 0, 0.5f ) ; // Top Right
            verts[0].Color = System.Drawing.Color.AntiqueWhite.ToArgb();

            verts[1].Position = new Vector3( 0.32f, -0.32f, 0.5f ); // Bottom Right
            verts[1].Color = System.Drawing.Color.Black.ToArgb();

            verts[2].Position = new Vector3( 0, -0.32f, 0.5f ); // Bottom Left
            verts[2].Color = System.Drawing.Color.Purple.ToArgb();

            verts[3].Position = new Vector3( 0, 0, 0.5f ); // Top Left
            verts[3].Color = System.Drawing.Color.Purple.ToArgb();


            buffer.SetData(verts, 0, LockFlags.None);
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
            device.VertexFormat = CustomVertex.PositionColored.Format;
            device.DrawPrimitives(PrimitiveType.TriangleFan, 0, 2);
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

            using (MyTile frm = new MyTile())
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
