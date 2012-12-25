/// <Title>"Simple" DirectX Game Loop</Title>
/// <Trademark>Tutorials in plain English by Dillinger</Trademark>
/// <Copyright>Copyright © 2006 Timothy Lee Heermann</Copyright>

using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tutorials.GameLoop
{
    class MyForm : Form
    {
        // Variable Declarations and such go here
        /// <remarks>Create DirectX interface to graphics card. </remarks>
        Device DirectXGraphicsCard = null;
        /// <remarks>Create place to store 3D objects. </remarks>
        VertexBuffer vertexBuffer = null; 

        /// <summary>Run MyForm. </summary><remarks>
        ///  We don't actually run our form. Nooooooooo.
        /// We instantiate an instance of MyForm and run that! </remarks>
        static void Main( )
        {
            Application.Run(new MyForm());
        }

        /// <summary> The Constructor for our application. </summary>
        MyForm()
        {
            /// <remarks> Setup various Form window attributes. </remarks>
            Size = new Size(350, 350);
            Text = " Basic Game Loop";
            CenterToScreen();

            /// <remarks> Set up the DirectX interface to your Graphics Card. </remarks>
            InitializeGraphicsCard(); 
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
                // Now we set a couple basic parameters.
                presentParams.Windowed = true; // In a window
                presentParams.SwapEffect = SwapEffect.Discard; // Trash the Back Buffer if it's not ready to show yet
                // OK now set up the DirectX "Device" : an Interpreter that speaks to your Graphics Card
                DirectXGraphicsCard = new Device(0, DeviceType.Hardware,
                 this, CreateFlags.HardwareVertexProcessing, presentParams);
                // Create a new Event Handler which is triggered if somebody resizes the window or something
                DirectXGraphicsCard.DeviceReset += new System.EventHandler(CreateVertexBuffer);
                // Create the Vertex Buffer in your Graphics Card
                CreateVertexBuffer(DirectXGraphicsCard, null);
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

            DirectXGraphicsCard.RenderState.Lighting = false;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 4, 
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
             new CustomVertex.PositionColored[4]; // Type of Vertices and number of Points

            // Draw Polygon from Vertice Points in a clockwise direction
            VerticeArray[0].Position = new Vector3(-0.32f, 0.32f, 0.5f); // Top Left Vertice 
            VerticeArray[0].Color = System.Drawing.Color.Red.ToArgb();

            VerticeArray[1].Position = new Vector3(0.32f, 0.32f, 0.5f); // Top Right
            VerticeArray[1].Color = System.Drawing.Color.Yellow.ToArgb();

            VerticeArray[2].Position = new Vector3(0.32f, -0.32f, 0.5f); // Bottom Right
            VerticeArray[2].Color = System.Drawing.Color.Blue.ToArgb();

            VerticeArray[3].Position = new Vector3(-0.32f, -0.32f, 0.5f); // Bottom Left
            VerticeArray[3].Color = System.Drawing.Color.Purple.ToArgb();

            vertexBuffer.SetData(VerticeArray, 0, LockFlags.None);
        }

        public void DrawGraphics()
        {
            UpdateGame(); ///<remarks>Update any movement changes etc. .  </remarks>

            DrawBackground(); ///<remarks>Wipe everything out and start from a blank slate </remarks>

            DirectXGraphicsCard.BeginScene(); ///<remarks>And away we go! In the beginning there was nothing... </remarks>

            DrawTriangleFan(); ///<remarks>Draw stuff to the backbuffer </remarks>

            DirectXGraphicsCard.EndScene(); ///<remarks>...and that's all she wrote, folks! </remarks>
            DirectXGraphicsCard.Present(); ///<remarks>Send our backbuffer to the screen </remarks>
        }

        /// <summary>Update Sprite movement etc.</summary>
        public void UpdateGame()
        {
            // n/a Non moving object. Nothing to update.
        }

        public void DrawBackground()
        {
            DirectXGraphicsCard.Clear(ClearFlags.Target, // Clear the screen
                System.Drawing.Color.Navy, // and set the Background color
                1.0f, 0);
        }

        public void DrawTriangleFan()
        {
            // Grab some Points out of the Vertex Buffer
            DirectXGraphicsCard.SetStreamSource(0, vertexBuffer, 0);
            // Describe how these points will appear on screen
            DirectXGraphicsCard.VertexFormat = CustomVertex.PositionColored.Format;
            // Draw this type of Polygon object from our Points using 2 triangles
            DirectXGraphicsCard.DrawPrimitives(PrimitiveType.TriangleFan, 0, 2);
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
    }
} // Elvis has left the building
