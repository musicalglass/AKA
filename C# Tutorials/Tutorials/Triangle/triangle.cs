using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorials.DrawingATriangle
{
    public class AForm : Form
    {
        Device device = null; //Think of this as your graphics card
        VertexBuffer vertexBuffer = null; //To store 3D objects!

        static void Main()
        {
            //Create an object from our class
            AForm form = new AForm();


            form.InitializeGraphics(); //Set up the device
            form.Show();

            //While the form hasn't been closed
            while (form.Created)
            {
                //Update our game, and render to screen
                form.Render();
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
                device.DeviceCreated += new System.EventHandler(this.OnCreateDevice);
                OnCreateDevice(device, null);
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


        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            vertexBuffer =
                new VertexBuffer(typeof(CustomVertex.TransformedColored),
                3, dev, 0, CustomVertex.TransformedColored.Format,
                Pool.Default);

            GraphicsStream stm = vertexBuffer.Lock(0, 0, 0);
            CustomVertex.TransformedColored[] verts = new CustomVertex.TransformedColored[3];

            verts[0].X = 150;
            verts[0].Y = 50;
            verts[0].Z = 0.5f;
            verts[0].Rhw = 1;
            verts[0].Color = System.Drawing.Color.Aqua.ToArgb();
            verts[1].X = 250;
            verts[1].Y = 250;
            verts[1].Z = 0.5f;
            verts[1].Rhw = 1;
            verts[1].Color = System.Drawing.Color.Brown.ToArgb();
            verts[2].X = 50;
            verts[2].Y = 250;
            verts[2].Z = 0.5f;
            verts[2].Rhw = 1;
            verts[2].Color = System.Drawing.Color.LightPink.ToArgb();
            stm.Write(verts);
            vertexBuffer.Unlock();
        }


    }
}
