using System ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Windows.Forms ;
using Microsoft.DirectX ;
using Microsoft.DirectX.Direct3D ;

namespace Tutorials.TrianglePositionColored
{
    public partial class Form1 : Form
    {
        Device DX3DGraphicsCard = null ; // Create an interface to your graphics card
        VertexBuffer vertexBuffer = null ; // Create a place to store your 3D object

        public Form1()
        {
            InitializeComponent();
            Text = "Triangle PositionColored" ; // Set the text that appears in the top of the Form window
            this.ClientSize = new System.Drawing.Size( 375, 375 ); // Set the size of the window's screen
            InitializeGraphics(); //Set up the DirectX Device
            // Now that we're all intialized OnPaint will be triggered
        }

        public void InitializeGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true ;
                presentParams.SwapEffect = SwapEffect.Discard ;
                DX3DGraphicsCard = new Device( 0, DeviceType.Hardware, this,
                    CreateFlags.HardwareVertexProcessing, presentParams );
                DX3DGraphicsCard.DeviceReset += new System.EventHandler( this.VertexContainer );
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
            DX3DGraphicsCard.Clear( ClearFlags.Target, // Clear the Screen
            System.Drawing.Color.Navy, // Paint the Background color
            1.0f, 0 );
        }

        public void DrawTriangle()
        {
            DX3DGraphicsCard.SetStreamSource( 0, vertexBuffer, 0 );
            DX3DGraphicsCard.VertexFormat = CustomVertex.PositionColored.Format ;
            DX3DGraphicsCard.DrawPrimitives( PrimitiveType.TriangleList, 0, 1 );
        }

        public void VertexContainer( object sender, EventArgs e )
        {
            Device dev = (Device)sender ;
            // Set culling so we're not rendering the back of our triangle
            dev.RenderState.CullMode = Cull.CounterClockwise ;

            // Turn off D3D lighting, since we are providing our own vertex colors
            dev.RenderState.Lighting = false ;

            // Create an instance of ready-made DirectX VertexBuffer
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored),
                3, dev, 0, CustomVertex.PositionColored.Format, Pool.Default);

            // Lock our buffer so nothing gets changed while we are reading the data
            GraphicsStream GraphixStream = vertexBuffer.Lock( 0, 0, 0 ); 
            CustomVertex.PositionColored[] VerticeArray = new CustomVertex.PositionColored[3];

            VerticeArray[0].Position = new Vector3( -0.5f, 0.5f, 0 ); // top right Vertice
            VerticeArray[0].Color = System.Drawing.Color.Yellow.ToArgb();

            VerticeArray[1].Position = new Vector3( 0.5f, -0.5f, 0 ); // bottom right
            VerticeArray[1].Color = System.Drawing.Color.Orange.ToArgb();

            VerticeArray[2].Position = new Vector3( -0.5f, -0.5f, 0 ); // bottom left
            VerticeArray[2].Color = System.Drawing.Color.Red.ToArgb();

            GraphixStream.Write(VerticeArray);
            vertexBuffer.Unlock();
        }
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)(byte)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
                this.Close(); // Esc was pressed
        }
    }
}
