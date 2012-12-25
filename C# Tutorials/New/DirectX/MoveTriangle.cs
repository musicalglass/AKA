using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectInput;

namespace DirectX_Tutorial
{

    public class WinForm : System.Windows.Forms.Form
    {
        private Microsoft.DirectX.Direct3D.Device device;
        private System.ComponentModel.Container components = null;
        //private float angle = 0f;
        private CustomVertex.PositionColored[] vertices;
        private float MyMaticeX = -5.0f, MyMaticeY = -5.0f, MyMaticeZ = 0.0f;
        private Microsoft.DirectX.DirectInput.Device keyb;

        public WinForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
        }


        public void InitializeDevice()
        {
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            device = new Microsoft.DirectX.Direct3D.Device
                        (0, Microsoft.DirectX.Direct3D.DeviceType.Hardware,
                        this, CreateFlags.SoftwareVertexProcessing, presentParams);
        }
        public void InitializeKeyboard()
        {
            keyb = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Keyboard);
            keyb.SetCooperativeLevel(this, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
            keyb.Acquire();
        }

        private void CameraPositioning()
        {
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, this.Width / this.Height, 1f, 50f);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, -30), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            device.RenderState.Lighting = false;
            device.RenderState.CullMode = Cull.None;
        }

        private void VertexDeclaration()
        {
            vertices = new CustomVertex.PositionColored[3];
            vertices[0].Position = (new Vector3(0f, 0f, 0f));
            vertices[0].Color = Color.Red.ToArgb();
            vertices[1].Position = (new Vector3(10f, 0f, 0f));
            vertices[1].Color = Color.Yellow.ToArgb();
            vertices[2].Position = (new Vector3(5f, 10f, 0f));
            vertices[2].Color = Color.Blue.ToArgb();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            device.Clear(ClearFlags.Target, Color.Navy, 1.0f, 0);
            device.BeginScene();

            device.VertexFormat = CustomVertex.PositionColored.Format;
            device.Transform.World = Matrix.Translation(MyMaticeX, MyMaticeY, MyMaticeZ);
            device.DrawUserPrimitives( PrimitiveType.TriangleList, 1, vertices );

            device.EndScene();
            device.Present();
            this.Invalidate();

            ReadKeyboard();

        }
        private void ReadKeyboard()
        {
            KeyboardState keys = keyb.GetCurrentKeyboardState();

            if (keys[Key.RightArrow]) { MyMaticeX += 0.5f; }
            if (keys[Key.LeftArrow]) { MyMaticeX -= 0.5f; }
            if (keys[Key.UpArrow]) { MyMaticeY += 0.5f; }
            if (keys[Key.DownArrow]) { MyMaticeY -= 0.5f; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size( 500, 500 );
            this.Text = "Moving Triangle";
        }

        static void Main()
        {

            using (WinForm our_directx_form = new WinForm())
            {
                our_directx_form.InitializeDevice();
                our_directx_form.CameraPositioning();
                our_directx_form.VertexDeclaration();
                our_directx_form.InitializeKeyboard();
                Application.Run(our_directx_form);
            }
        }
    }
}
