//-----------------------------------------------------------------------------
// File: Meshes.cs
//
// Desc: For advanced geometry, most apps will prefer to load pre-authored
//       meshes from a file. Fortunately, when using meshes, D3DX does most of
//       the work for this, parsing a geometry file and creating vertx buffers
//       (and index buffers) for us. This tutorial shows how to use a D3DXMESH
//       object, including loading it from a file and rendering it. One thing
//       D3DX does not handle for us is the materials and textures for a mesh,
//       so note that we have to handle those manually.
//
//       Note: one advanced (but nice) feature that we don't show here is that
//       when cloning a mesh we can specify the FVF. So, regardless of how the
//       mesh was authored, we can add/remove normals, add more texture
//       coordinate sets (for multi-texturing), etc.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Direct3D=Microsoft.DirectX.Direct3D;

namespace MeshesTutorial
{
    public class Meshes : Form
    {

        Device device = null; // Our rendering device
        Mesh mesh = null; // Our mesh object in system
        Direct3D.Material[] meshMaterials; // Materials for our mesh
        Texture[] meshTextures; // Textures for our mesh
        PresentParameters presentParams = new PresentParameters();
        bool pause = false;

        public Meshes()
        {
            // Set the initial size of our form
            this.ClientSize = new System.Drawing.Size(400,300);
            // And its caption
            this.Text = "Direct3D Tutorial 6 - Meshes";
        }

        bool InitializeGraphics()
        {
            // Get the current desktop display mode, so we can set up a back
            // buffer of the same format
            try
            {
                // Set up the structure used to create the D3DDevice. Since we are now
                // using more complex geometry, we will create a device with a zbuffer.
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.EnableAutoDepthStencil = true;
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;

                // Create the D3DDevice
                device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
                device.DeviceReset += new System.EventHandler(this.OnResetDevice);
                this.OnResetDevice(device, null);
                pause = false;
            }
            catch (DirectXException)
            {
                return false;
            }
            return true;
        }
        public void OnResetDevice(object sender, EventArgs e)
        {
            ExtendedMaterial[] materials = null;

            // Set the directory up two to load the right data (since the default build location is bin\debug or bin\release
            Directory.SetCurrentDirectory(Application.StartupPath +  @"\..\..\");

            Device dev = (Device)sender;

            // Turn on the zbuffer
            dev.RenderState.ZBufferEnable = true;

            // Turn on ambient lighting 
            dev.RenderState.Ambient = System.Drawing.Color.White;
            // Load the mesh from the specified file
            mesh = Mesh.FromFile("tiger.x", MeshFlags.SystemMemory, device, out materials);

            
            if (meshTextures == null)
            {
                // We need to extract the material properties and texture names 
                meshTextures  = new Texture[materials.Length];
                meshMaterials = new Direct3D.Material[materials.Length];
                for( int i=0; i<materials.Length; i++ )
                {
                    meshMaterials[i] = materials[i].Material3D;
                    // Set the ambient color for the material (D3DX does not do this)
                    meshMaterials[i].Ambient = meshMaterials[i].Diffuse;
     
                    // Create the texture
                    meshTextures[i] = TextureLoader.FromFile(dev, materials[i].TextureFilename);
                }
            }

        }
        void SetupMatrices()
        {
            // For our world matrix, we will just leave it as the identity
            device.Transform.World = Matrix.RotationY(Environment.TickCount/1000.0f );

            // Set up our view matrix. A view matrix can be defined given an eye point,
            // a point to lookat, and a direction for which way is up. Here, we set the
            // eye five units back along the z-axis and up three units, look at the 
            // origin, and define "up" to be in the y-direction.
            device.Transform.View = Matrix.LookAtLH(new Vector3( 0.0f, 3.0f,-5.0f ), 
                new Vector3( 0.0f, 0.0f, 0.0f ), 
                new Vector3( 0.0f, 1.0f, 0.0f ) );

            // For the projection matrix, we set up a perspective transform (which
            // transforms geometry from 3D view space to 2D viewport space, with
            // a perspective divide making objects smaller in the distance). To build
            // a perpsective transform, we need the field of view (1/4 pi is common),
            // the aspect ratio, and the near and far clipping planes (which define at
            // what distances geometry should be no longer be rendered).
            device.Transform.Projection = Matrix.PerspectiveFovLH( (float)(Math.PI / 4), 1.0f, 1.0f, 100.0f );
        }
        private void Render()
        {
            if (device == null) 
                return;

            if (pause)
                return;

            //Clear the backbuffer to a blue color 
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, System.Drawing.Color.Blue, 1.0f, 0);
            //Begin the scene
            device.BeginScene();
            // Setup the world, view, and projection matrices
            SetupMatrices();
            
            // Meshes are divided into subsets, one for each material. Render them in
            // a loop
            for( int i=0; i<meshMaterials.Length; i++ )
            {
                // Set the material and texture for this subset
                device.Material = meshMaterials[i];
                device.SetTexture(0, meshTextures[i]);
        
                // Draw the mesh subset
                mesh.DrawSubset(i);
            }

            //End the scene
            device.EndScene();
            device.Present();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            this.Render(); // Render on painting
        }
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)(byte)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
                this.Dispose(); // Esc was pressed
        }

        protected override void OnResize(System.EventArgs e)
        {
            pause = ((this.WindowState == FormWindowState.Minimized) || !this.Visible);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() 
        {
            using (Meshes frm = new Meshes())
            {
                if (!frm.InitializeGraphics()) // Initialize Direct3D
                {
                    MessageBox.Show("Could not initialize Direct3D.  This tutorial will exit.");
                    return;
                }
                frm.Show();

                // While the form is still valid, render and process messages
                while(frm.Created)
                {
                    frm.Render();
                    Application.DoEvents();
                }
            }
        }
    }
}
