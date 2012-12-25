using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorials.TriangleEvent
{
    public partial class Form1 : Form
    {
        Device DX3DGraphicsCard = null; // Create an interface to your graphics card
        VertexBuffer vertexBuffer = null; // Create a place to store your 3D object

        public Form1()
        {
            InitializeComponent();
            Text = "Draw a Triangle"; // Set the text that appears in the top of the Form window
            this.ClientSize = new System.Drawing.Size( 300, 300 ); // Set the size of the window's screen
            InitializeGraphics(); //Set up the DirectX Device
            // Now that we're all intialized OnPaint will be triggered
        }

        public void InitializeGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                DX3DGraphicsCard = new Device(0,
                    DeviceType.Hardware,
                    this,
                    CreateFlags.HardwareVertexProcessing,
                    presentParams);
                // DX3DGraphicsCard.DeviceReset += new System.EventHandler( this.VertexContainer );
                VertexContainer( DX3DGraphicsCard, null );
            }
            catch ( DirectXException e )
            {
                MessageBox.Show(null,
                    "Error intializing graphics: "
                    + e.Message, "Error");
                Close();
            }
        }

        // OnPaint event fired by Operating System when Form window opens
        protected override void OnPaint( PaintEventArgs e )
        {
            BackgroundPaint(); // Clear the screen and paint the background
            DX3DGraphicsCard.BeginScene(); 
            DrawTriangle(); // Draw stuff to the backbuffer
            DX3DGraphicsCard.EndScene();
            DX3DGraphicsCard.Present(); //Send our backbuffer to the screen
        }

        public void BackgroundPaint()
        {
            DX3DGraphicsCard.Clear(ClearFlags.Target, // Clear the Screen
            System.Drawing.Color.Navy, // Paint the Background color
            1.0f, 0);
        }

        public void DrawTriangle()
        {
            DX3DGraphicsCard.SetStreamSource(0, vertexBuffer, 0);
            DX3DGraphicsCard.VertexFormat = CustomVertex.TransformedColored.Format;
            DX3DGraphicsCard.DrawPrimitives( PrimitiveType.TriangleList, 0, 1 );
        }

        public void VertexContainer( object sender, EventArgs e )
        {
            Device dev = ( Device )sender;
            vertexBuffer =
                new VertexBuffer( typeof( CustomVertex.TransformedColored ),
                3, dev, 0, CustomVertex.TransformedColored.Format,
                Pool.Default );

            GraphicsStream GraphixStream = vertexBuffer.Lock( 0, 0, 0 );
            CustomVertex.TransformedColored[] VerticeArray = new CustomVertex.TransformedColored[3];

            VerticeArray[0].Position = new Vector4( 50, 50, 0.5f, 1 ); // top left Vertice
            VerticeArray[0].Color = System.Drawing.Color.Orange.ToArgb();

            VerticeArray[1].Position = new Vector4( 250, 50, 0.5f, 1 ); // top right
            VerticeArray[1].Color = System.Drawing.Color.Yellow.ToArgb();

            VerticeArray[2].Position = new Vector4( 150, 250, 0.5f, 1 ); // bottom
            VerticeArray[2].Color = System.Drawing.Color.Red.ToArgb();

            GraphixStream.Write( VerticeArray );
            vertexBuffer.Unlock();
        }
    }
}