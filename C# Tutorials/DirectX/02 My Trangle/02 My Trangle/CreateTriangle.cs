using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorials.DrawingATriangle
{
    public class GameEngine : Form
    {
        Device device = null; //Think of this as your graphics card
        VertexBuffer vertexBuffer = null; //To store 3D objects!

        static void Main()
        {
            //Create an object from our class
            GameEngine MyGame = new GameEngine();


            MyGame.InitializeGraphics(); //Set up the device
            MyGame.Show();

            //While the MyGame hasn't been closed
            while (MyGame.Created)
            {
                //Update our game, and render to screen
                MyGame.Render();
                Application.DoEvents(); //Let the OS handle what it needs to
            }
        }

        public void InitializeGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                device = new Device(0,
                    DeviceType.Hardware,
                    this,
                    CreateFlags.HardwareVertexProcessing,
                    presentParams);
                device.DeviceReset += new System.EventHandler(this.OnResetDevice);
                OnResetDevice(device, null);

            }
            catch (DirectXException e)
            {

                MessageBox.Show(null,
                    "Error intializing graphics: "
                    + e.Message, "Error");
                Close();
            }
        }

        private void Render()
        {
            if (device == null) //if there's nothing to render with
                return;			//then don't bother 


            //Set the backbuffer to a nice blue
            device.Clear(ClearFlags.Target,
                System.Drawing.Color.Blue,
                1.0f, 0);

            device.BeginScene();

            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = CustomVertex.TransformedColored.Format;
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);

            device.EndScene();


            device.Present(); //Send our backbuffer to the screen!
        }

        public void OnResetDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;

            vertexBuffer =
                new VertexBuffer(typeof(CustomVertex.TransformedColored),
                3,
                dev,
                0,
                CustomVertex.TransformedColored.Format,
                Pool.Default);

            vertexBuffer.Created +=
                new System.EventHandler(this.OnCreateVertexBuffer);
            this.OnCreateVertexBuffer(vertexBuffer, null);
        }


        public void OnCreateVertexBuffer(object sender, EventArgs e)
        {

            VertexBuffer buffer = (VertexBuffer)sender;

            CustomVertex.TransformedColored[] verts =
                new CustomVertex.TransformedColored[3];
            verts[0].Position = new Vector4(50, 50, 0.5f, 1);
            verts[0].Color = System.Drawing.Color.Black.ToArgb();
            verts[1].Position = new Vector4(250, 50, 0.5f, 1);
            verts[1].Color = System.Drawing.Color.Black.ToArgb();
            verts[2].Position = new Vector4(150, 250, 0.5f, 1);
            verts[2].Color = System.Drawing.Color.Black.ToArgb();

            buffer.SetData(verts, 0, LockFlags.None);

        }


    }
}