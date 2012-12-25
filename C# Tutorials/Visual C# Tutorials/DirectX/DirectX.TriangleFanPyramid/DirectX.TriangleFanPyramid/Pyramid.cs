/// <Title>Draw a 3D Pryamid using a TriangleFan</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright © 2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorials.DirectX.TriangleFanPyramid
{
    class MyForm : Form
    {
        // Variable Declarations and such go here
        int NumberOfVertices = 6;
        int NumberOfTriangles = 4;
        /// <remarks>Create DirectX interface to graphics card. </remarks>
        Device DirectXGraphicsCard = null;
        /// <remarks>Create place to store 3D objects. </remarks>
        VertexBuffer vertexBuffer = null;

        /// <summary>Run MyForm. </summary><remarks>
        ///  We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that! </remarks>
        static void Main()
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application. </summary>
        MyForm()
        {
            /// <remarks> Setup various Form window attributes. </remarks>
            Size = new Size(400, 400);
            Text = " Move Mouse to Rotate";
            CenterToScreen();

            /// <remarks> Set up the DirectX interface to your Graphics Card. </remarks>
            InitializeGraphicsCard();

            /// <remarks>Create a new Mouse movement Event Handler </remarks>
            MouseMove += new MouseEventHandler(MouseMoveUpdate);
        }

        /// <summary>Run Main Game Loop. </summary><remarks>
        /// OnPaint Event Triggered by Operating System 
        /// after everything is done Intializing </remarks> 
        protected override void OnPaint(PaintEventArgs e)
        {
            GameLoop();
        }

        /// <summary>Loop our Game over and over 
        /// ( as long as it's OK with the OS ;) </summary>
        public void GameLoop()
        {
            while (Created) /// <remarks>While the Form window hasn't been closed... </remarks>
            {              /// <remarks> repeat everything in this loop over and over.  </remarks>
                if (DirectXGraphicsCard != null) // Don't Render unless there's something to Draw. 
                    DrawGraphics();  /// <remarks> Update our game, and render to screen.  </remarks>

                Application.DoEvents();  /// <remarks> Give Operating System some processor time. </remarks>
            }
        }

        // ====  And that's it in a nutshell! Game over. You can all go home now folks!  ====
        // ( Now here's the details ;)

        /// <summary> Set up your DirectX enabled Graphics Card. </summary><remarks>
        /// If unable to do so, Catch the Exception and display 
        /// an error message dialog box.</remarks>
        public void InitializeGraphicsCard()
        {
            try
            {   // OK first, we create an Instance of the Parameters class
                PresentParameters presentParams = new PresentParameters();
                // Now we tweak a couple basic Parameters.
                presentParams.Windowed = false; // Change this to false for Fullscreen
                if (presentParams.Windowed == false)
                {
                    DisplayMode DispMode = Manager.Adapters[Manager.Adapters.Default.Adapter].CurrentDisplayMode;
                    presentParams.BackBufferFormat = DispMode.Format;
                    presentParams.BackBufferWidth = DispMode.Width;
                    presentParams.BackBufferHeight = DispMode.Height;
                }
                presentParams.SwapEffect = SwapEffect.Discard; // Trash the Back Buffer if it's not ready to show yet
                // OK now set up the DirectX "Device" : an Interpreter that speaks to your Graphics Card
                DirectXGraphicsCard = new Device(0, DeviceType.Hardware,
                 this, CreateFlags.HardwareVertexProcessing, presentParams);
                // Create a new Event Handler which is triggered if somebody resizes the window or something
                DirectXGraphicsCard.DeviceReset += new System.EventHandler(CreateVertexBuffer);
                // Create the Vertex Buffer in your Graphics Card
                CreateVertexBuffer(DirectXGraphicsCard, null);

                DirectXGraphicsCard.RenderState.Lighting = false;
                // Turn off back culling so we can see the backside of our rotated object
                DirectXGraphicsCard.RenderState.CullMode = Cull.CounterClockwise;

                // Setup Field of View ( field of view Y, Aspect Ratio, Near Clipping Plane, Far Clipping Plane )
                DirectXGraphicsCard.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1.0f, 1.0f, 100.0f);

                // Build LeftHanded Lookat Matrix ( Camera Position, Camera Target, Camera Up Vector )
                DirectXGraphicsCard.Transform.View = Matrix.LookAtLH(new Vector3(0.0f, 0.0f, -2.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f));
            }
            catch (DirectXException DirectXception) // If there were any glitches in the above...
            {
                MessageBox.Show(null, // Show one of those annoying little boxes with an OK button.
                    // Display what the actual error was
                    "Error intializing graphics: " + DirectXception.Message, "Error");
                Close(); // If the user clicks OK, make strained spinach
            }
        }

        public void CreateVertexBuffer(object sender, EventArgs e)
        {
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), NumberOfVertices,
             DirectXGraphicsCard, 0, CustomVertex.PositionColored.Format, Pool.Default);

            vertexBuffer.Created += new EventHandler(CreateVertexArray);
            CreateVertexArray(vertexBuffer, null);
        }

        /// <summary> Create the Vertex Array. </summary>
        /// <remarks>Where our Vertice Points are initially stored with each of
        ///  their positions in 3D space in X, Y, and Z coordinates.
        ///  Also any color or texture information.</remarks>
        public void CreateVertexArray(object sender, EventArgs e)
        {
            CustomVertex.PositionColored[] VerticeArray = // Declare a new Array called VerticeArray
             new CustomVertex.PositionColored[NumberOfVertices]; // Type of Vertices and number of Points

            // Draw TriangleFan from Vertice Points in a clockwise direction
            VerticeArray[0].Position = new Vector3(0.0f, 0.32f, 0.0f); // Top Center 
            VerticeArray[0].Color = System.Drawing.Color.Yellow.ToArgb();

            VerticeArray[1].Position = new Vector3(-0.32f, -0.32f, 0.32f); // Left Bottom Rear
            VerticeArray[1].Color = System.Drawing.Color.Yellow.ToArgb();

            VerticeArray[2].Position = new Vector3(0.32f, -0.32f, 0.32f); // Right Bottom Rear
            VerticeArray[2].Color = System.Drawing.Color.Orange.ToArgb();

            VerticeArray[3].Position = new Vector3(0.32f, -0.32f, -0.32f); // Right Bottom Front
            VerticeArray[3].Color = System.Drawing.Color.Red.ToArgb();

            VerticeArray[4].Position = new Vector3(-0.32f, -0.32f, -0.32f); // Bottom Front Left
            VerticeArray[4].Color = System.Drawing.Color.Orange.ToArgb();

            VerticeArray[5].Position = new Vector3(-0.32f, -0.32f, 0.32f); // Left Bottom Rear
            VerticeArray[5].Color = System.Drawing.Color.Yellow.ToArgb();

            vertexBuffer.SetData(VerticeArray, 0, LockFlags.None);
        }

        public void DrawGraphics()
        {
            DrawBackground(); ///<remarks>Wipe everything out and start from a blank slate </remarks>

            DirectXGraphicsCard.BeginScene(); ///<remarks>And away we go! In the beginning there was nothing... </remarks>

            DrawTriangleFan(); ///<remarks>Draw stuff to the backbuffer </remarks>

            DirectXGraphicsCard.EndScene(); ///<remarks>...and that's all she wrote, folks! </remarks>
            DirectXGraphicsCard.Present(); ///<remarks>Send our backbuffer to the screen </remarks>
        }

        public void DrawBackground()
        {
            DirectXGraphicsCard.Clear(ClearFlags.Target, // Clear the screen
                System.Drawing.Color.Black, // and set the Background color
                1.0f, 0);
        }

        public void DrawTriangleFan()
        {
            // Grab some Points out of the Vertex Buffer
            DirectXGraphicsCard.SetStreamSource(0, vertexBuffer, 0);
            // Describe how these points will appear on screen
            DirectXGraphicsCard.VertexFormat = CustomVertex.PositionColored.Format;
            // Draw this type of Polygon object from our Points using 2 triangles
            DirectXGraphicsCard.DrawPrimitives(PrimitiveType.TriangleFan, 0, NumberOfTriangles);
        }

        /// <summary>Keyboard Input </summary>
        /// <param name="KeyboardPressed"></param>
        protected override void OnKeyDown(KeyEventArgs KeyboardPressed)
        {
            switch (KeyboardPressed.KeyCode)
            {
                case Keys.Escape: // If Escape key is pressed...
                    GC.Collect(0); // clean up any unused resources..
                    Environment.Exit(0); // and Bail
                    break; // end case statement
            }
        }

        /// <summary> Events to update if the Mouse is moved </summary>
        /// <param name="sender"></param> 
        /// <param name="GetMousePosition">Get's current position of User's Mouse</param>
        void MouseMoveUpdate(object sender, MouseEventArgs GetMousePosition)
        {
            // Move Sprite to Mouse's X coordinate
            DirectXGraphicsCard.Transform.World = Matrix.RotationY(GetMousePosition.X / -100.0f);
        }
    }
} // and the fat lady sings!
