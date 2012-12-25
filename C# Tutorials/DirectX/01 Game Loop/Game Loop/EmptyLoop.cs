using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorials.EmptyLoop
{
    public class GameEngine : Form
    {
        // Global Declarations
        Device device = null;

        static void Main()
        {

            GameEngine MyGame = new GameEngine();
            MyGame.InitializeGraphics();
            MyGame.Show();


            while (MyGame.Created)
            {
                // Set the size of Window's drawing area
                MyGame.ClientSize = new System.Drawing.Size( 400, 400 );
                // Set Window Text
                MyGame.Text = "Nothing at 1500 FPS!"; 
                MyGame.Render();
                Application.DoEvents(); //Let the OS do whatever it needs to
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
