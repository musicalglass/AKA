using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorials.DrawTriangle
{
    public partial class MyForm : Form
    {
        // Variable Declarations
        Device DirectXGraphicsCard = null; // Create interface to DirectX graphics card
        VertexBuffer vertexBuffer = null; // Create place to store 3D objects

        public MyForm()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size( 300, 300 );
            InitializeComponent(); // Initialize the Form Window
            InitializeGraphics(); // Set up the DirectX Graphics Card
            this.Text = "Draw Triangle"; // Change the text that appears at the top of the Form window
            Show();
            this.ResumeLayout( false );
        }

        public void Run()
        {
            while (Created) // While the Form window hasn't been closed
            {               // Repeat everything in this loop over and over
                GameLoop(); // Update our game, and render to screen
                Application.DoEvents(); // Give Windows Operating System some processor time
            }
        }

        public void GameLoop()
        {
            if (DirectXGraphicsCard == null) // If there's nothing for the Graphics Card to render
                return;			// then skip the next bit

            DrawBackground(); // Wipe everything out and start from a blank slate

            DirectXGraphicsCard.BeginScene(); // And away we go! In the beginning there was nothing...

            DrawTriangleList(); // Draw stuff to the backbuffer

            DirectXGraphicsCard.EndScene(); // ...and that's all she wrote, folks!
            DirectXGraphicsCard.Present(); // Send our backbuffer to the screen
        }

        public void DrawBackground()
        {
            DirectXGraphicsCard.Clear( ClearFlags.Target, // Clear the screen
                System.Drawing.Color.Navy, // and set the Background color
                1.0f, 0 );
        }

        public void DrawTriangleList()
        {
            DirectXGraphicsCard.SetStreamSource(0, vertexBuffer, 0); // Grab some Points out of the Buffer
            DirectXGraphicsCard.VertexFormat = CustomVertex.TransformedColored.Format; // Describe how these points will appear on screen
            DirectXGraphicsCard.DrawPrimitives(PrimitiveType.TriangleList, 0, 1); // Draw this type of Polygon object from our points
        }

        public void InitializeGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                DirectXGraphicsCard = new Device(0,
                    DeviceType.Hardware,
                    this,
                    CreateFlags.HardwareVertexProcessing,
                    presentParams);
                // Create a new Event Handler which is triggered if somebody resizes the window or something
                DirectXGraphicsCard.DeviceReset += new System.EventHandler(this.OnResetDevice);
                // Currently nobody is resizing any windows so the trigger is set to off 
                OnResetDevice(DirectXGraphicsCard, null);
            }
            catch (DirectXException e)
            {
                MessageBox.Show(null,
                    "Error intializing graphics: "
                    + e.Message, "Error");
                Close();
            }
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

        // Create the Vertex Buffer, where our Points are stored
        // along with their position in 3D space in X, Y, and Z coordinates
        // also any color or texture information
        public void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            VertexBuffer buffer = (VertexBuffer)sender;

            CustomVertex.TransformedColored[] VerticeArray = // Declare a new Array called VerticeArray
                  new CustomVertex.TransformedColored[3]; // Type of Vertices and number of Points

            // Draw Polygon from Vertice Points in a clockwise direction
            VerticeArray[0].Position = new Vector4(50, 50, 0.5f, 1); // Top Left Vertice
            VerticeArray[0].Color = System.Drawing.Color.Orange.ToArgb();

            VerticeArray[1].Position = new Vector4(250, 50, 0.5f, 1); // Top Right
            VerticeArray[1].Color = System.Drawing.Color.Yellow.ToArgb();

            VerticeArray[2].Position = new Vector4(150, 250, 0.5f, 1); // Bottom
            VerticeArray[2].Color = System.Drawing.Color.Red.ToArgb();

            buffer.SetData(VerticeArray, 0, LockFlags.None);
        }
    }
}
