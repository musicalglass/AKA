using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorials.EmptyLoop
{
    public class example : Form
    {
        Device device = null;

        static void Main()
        {

            example form = new example();
            form.InitializeGraphics();
            form.Show();


            while (form.Created)
            {
                // Set the initial size of our form
                form.ClientSize = new System.Drawing.Size( 400, 400 );
                // And its caption
                form.Text = "Nothing at 1500 FPS!";
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
            if (device == null)
                return;

            device.Clear(ClearFlags.Target, // Clear the screen
               System.Drawing.Color.Blue, // Paint the background Blue
               1.0f, 0 );

            device.Present();
        }

    }
}
