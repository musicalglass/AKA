//--------------------------------------------------------------------------------------
// File: DXMUTMesh.cs
//
// Support code for loading DirectX .X files.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//--------------------------------------------------------------------------------------
using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Microsoft.Samples.DirectX.UtilityToolkit
{
    /// <summary>Class for loading and rendering file-based meshes</summary>
    public sealed class FrameworkMesh : IDisposable
    {
        #region Instance Data
        private string meshFileName;
        private Mesh systemMemoryMesh = null; // System Memory mesh, lives through a resize
        private Mesh localMemoryMesh = null; // Local mesh, rebuilt on resize

        private Material[] meshMaterials = null; // Materials for the mesh
        private BaseTexture[] meshTextures = null; // Textures for the mesh
        private bool isUsingMeshMaterials = true; // Should the mesh be rendered with the materials

        /// <summary>Returns the system memory mesh</summary>
        public Mesh SystemMesh { get { return systemMemoryMesh; } }
        /// <summary>Returns the local memory mesh</summary>
        public Mesh LocalMesh { get { return localMemoryMesh; } }
        /// <summary>Should the mesh be rendered with materials</summary>
        public bool IsUsingMaterials{ get { return isUsingMeshMaterials; } set { isUsingMeshMaterials = value; } }
        /// <summary>Number of materials in mesh</summary>
        public int NumberMaterials { get { return meshMaterials.Length; } }
        /// <summary>Gets a texture from the mesh</summary>
        public BaseTexture GetTexture(int index) { return meshTextures[index]; }
        /// <summary>Gets a material from the mesh</summary>
        public Material GetMaterial(int index) { return meshMaterials[index]; }
        #endregion

        #region Creation
        /// <summary>Create a new mesh using this file</summary>
        public FrameworkMesh(Device device, string name)
        {
            meshFileName = name;
            Create(device, meshFileName);
        }
        /// <summary>Create a new mesh</summary>
        public FrameworkMesh() : this(null, "FrameworkMeshFile_Mesh") {}
        
        /// <summary>Create the mesh data</summary>
        public void Create(Device device, string name)
        {
            // Hook the device events
            System.Diagnostics.Debug.Assert(device != null, "Device should not be null.");
            device.DeviceLost += new EventHandler(OnLostDevice);
            device.DeviceReset += new EventHandler(OnResetDevice);
            device.Disposing += new EventHandler(OnDeviceDisposing);

            GraphicsStream adjacency; // Adjacency information
            ExtendedMaterial[] materials; // Mesh material information

            // First try to find the filename
            string path = string.Empty;
            try
            {
                path = Utility.FindMediaFile(name);
            }
            catch(MediaNotFoundException)
            {
                // The media was not found, maybe a full path was passed in?
                if (System.IO.File.Exists(name))
                {
                    path = name;
                }
                else
                {
                    // No idea what this is trying to find
                    throw new MediaNotFoundException();
                }
            }

            // Now load the mesh
            systemMemoryMesh = Mesh.FromFile(path, MeshFlags.SystemMemory, device, out adjacency, 
                out materials);

            using (adjacency)
            {
                // Optimize the mesh for performance
                systemMemoryMesh.OptimizeInPlace(MeshFlags.OptimizeVertexCache | MeshFlags.OptimizeCompact | 
                    MeshFlags.OptimizeAttributeSort, adjacency);

                // Find the folder of where the mesh file is located
                string folder = Utility.AppendDirectorySeparator(new System.IO.FileInfo(path).DirectoryName);

                // Create the materials
                CreateMaterials(folder, device, adjacency, materials);
            }

            // Finally call reset
            OnResetDevice(device, EventArgs.Empty);
        }
        // TODO: Create with XOF

        /// <summary>Create the materials for the mesh</summary>
        public void CreateMaterials(string folder, Device device, GraphicsStream adjacency, ExtendedMaterial[] materials)
        {
            // Does the mesh have materials?
            if ((materials != null) && (materials.Length > 0))
            {
                // Allocate the arrays for the materials
                meshMaterials = new Material[materials.Length];
                meshTextures = new BaseTexture[materials.Length];

                // Copy each material and create it's texture
                for(int i = 0; i < materials.Length; i++)
                {
                    // Copy the material first
                    meshMaterials[i] = materials[i].Material3D;
                    
                    // Is there a texture for this material?
                    if ((materials[i].TextureFilename == null) || (materials[i].TextureFilename.Length == 0) )
                        continue; // No, just continue now

                    ImageInformation info = new ImageInformation();
                    string textureFile = folder + materials[i].TextureFilename;
                    try
                    {
                        // First look for the texture in the same folder as the input folder
                        info = TextureLoader.ImageInformationFromFile(textureFile);
                    }
                    catch
                    {
                        try
                        {
                            // Couldn't find it, look in the media folder
                            textureFile = Utility.FindMediaFile(materials[i].TextureFilename);
                            info = TextureLoader.ImageInformationFromFile(textureFile);
                        }
                        catch (MediaNotFoundException)
                        {
                            // Couldn't find it anywhere, skip it
                            continue;
                        }
                    }
                    switch (info.ResourceType)
                    {
                        case ResourceType.Textures:
                            meshTextures[i] = TextureLoader.FromFile(device, textureFile);
                            break;
                        case ResourceType.CubeTexture:
                            meshTextures[i] = TextureLoader.FromCubeFile(device, textureFile);
                            break;
                        case ResourceType.VolumeTexture:
                            meshTextures[i] = TextureLoader.FromVolumeFile(device, textureFile);
                            break;
                    }
                }
            }
        }
        #endregion

        #region Class Methods
        /// <summary>Updates the mesh to a new vertex format</summary>
        public void SetVertexFormat(Device device, VertexFormats format)
        {
            Mesh tempSystemMesh = null;
            Mesh tempLocalMesh = null;
            VertexFormats oldFormat = VertexFormats.None;
            using(systemMemoryMesh)
            {
                using (localMemoryMesh)
                {
                    // Clone the meshes
                    if (systemMemoryMesh != null)
                    {
                        oldFormat = systemMemoryMesh.VertexFormat;
                        tempSystemMesh = systemMemoryMesh.Clone(systemMemoryMesh.Options.Value,
                            format, device);
                    }
                    if (localMemoryMesh != null)
                    {
                        tempLocalMesh = localMemoryMesh.Clone(localMemoryMesh.Options.Value,
                            format, device); 
                    }
                }
            }

            // Store the new meshes
            systemMemoryMesh = tempSystemMesh;
            localMemoryMesh = tempLocalMesh;

            // Compute normals if they are being requested and the old mesh didn't have them
            if ( ((oldFormat & VertexFormats.Normal) == 0) && ((format & VertexFormats.None) != 0) )
            {
                if (systemMemoryMesh != null)
                    systemMemoryMesh.ComputeNormals();
                if (localMemoryMesh != null)
                    localMemoryMesh.ComputeNormals();
            }
        }
        /// <summary>Updates the mesh to a new vertex declaration</summary>
        public void SetVertexDeclaration(Device device, VertexElement[] decl)
        {
            Mesh tempSystemMesh = null;
            Mesh tempLocalMesh = null;
            VertexElement[] oldDecl = null;
            using(systemMemoryMesh)
            {
                using (localMemoryMesh)
                {
                    // Clone the meshes
                    if (systemMemoryMesh != null)
                    {
                        oldDecl = systemMemoryMesh.Declaration;
                        tempSystemMesh = systemMemoryMesh.Clone(systemMemoryMesh.Options.Value,
                            decl, device);
                    }
                    if (localMemoryMesh != null)
                    {
                        tempLocalMesh = localMemoryMesh.Clone(localMemoryMesh.Options.Value,
                            decl, device); 
                    }
                }
            }

            // Store the new meshes
            systemMemoryMesh = tempSystemMesh;
            localMemoryMesh = tempLocalMesh;
            
            bool hadNormal = false;
            // Check if the old declaration contains a normal.
            for(int i = 0; i < oldDecl.Length; i++)
            {
                if (oldDecl[i].DeclarationUsage == DeclarationUsage.Normal)
                {
                    hadNormal = true;
                    break;
                }
            }
            // Check to see if the new declaration has a normal
            bool hasNormalNow = false;
            for(int i = 0; i < decl.Length; i++)
            {
                if (decl[i].DeclarationUsage == DeclarationUsage.Normal)
                {
                    hasNormalNow = true;
                    break;
                }
            }

            // Compute normals if they are being requested and the old mesh didn't have them
            if ( !hadNormal && hasNormalNow )
            {
                if (systemMemoryMesh != null)
                    systemMemoryMesh.ComputeNormals();
                if (localMemoryMesh != null)
                    localMemoryMesh.ComputeNormals();
            }
        }

        /// <summary>Occurs after the device has been reset</summary>
        private void OnResetDevice(object sender, EventArgs e)
        {
            Device device = sender as Device;
            if (systemMemoryMesh == null)
                throw new InvalidOperationException("There is no system memory mesh.  Nothing to do here.");

            // Make a local memory version of the mesh. Note: because we are passing in
            // no flags, the default behavior is to clone into local memory.
            localMemoryMesh = systemMemoryMesh.Clone((systemMemoryMesh.Options.Value & ~MeshFlags.SystemMemory), 
                systemMemoryMesh.VertexFormat, device);
        }

        /// <summary>Occurs before the device is going to be reset</summary>
        private void OnLostDevice(object sender, EventArgs e)
        {
            if (localMemoryMesh != null)
                localMemoryMesh.Dispose();

            localMemoryMesh = null;
        }
        /// <summary>Renders this mesh</summary>
        public void Render(Device device, bool canDrawOpaque, bool canDrawAlpha)
        {
            if (localMemoryMesh == null)
                throw new InvalidOperationException("No local memory mesh.");

            // Frist, draw the subsets without alpha
            if (canDrawOpaque)
            {
                for (int i = 0; i < meshMaterials.Length; i++)
                {
                    if (isUsingMeshMaterials)
                    {
                        if (meshMaterials[i].DiffuseColor.Alpha < 1.0f)
                            continue; // Only drawing opaque right now

                        // set the device material and texture
                        device.Material = meshMaterials[i];
                        device.SetTexture(0, meshTextures[i]);
                    }
                    localMemoryMesh.DrawSubset(i);
                }
            }

            // Then, draw the subsets with alpha
            if (canDrawAlpha)
            {
                for (int i = 0; i < meshMaterials.Length; i++)
                {
                    if (meshMaterials[i].DiffuseColor.Alpha == 1.0f)
                        continue; // Only drawing non-opaque right now

                    // set the device material and texture
                    device.Material = meshMaterials[i];
                    device.SetTexture(0, meshTextures[i]);
                    localMemoryMesh.DrawSubset(i);
                }
            }
        }
        /// <summary>Renders this mesh</summary>
        public void Render(Device device) { Render(device, true, true); }

        // TODO: Render with effect

        /// <summary>Compute a bounding sphere for this mesh</summary>
        public float ComputeBoundingSphere(out Vector3 center)
        {
            if (systemMemoryMesh == null)
                throw new InvalidOperationException("There is no system memory mesh.  Nothing to do here.");

            // Get the object declaration
            int strideSize = VertexInformation.GetFormatSize(systemMemoryMesh.VertexFormat);

            // Lock the vertex buffer
            GraphicsStream data = null;
            try
            {
                data = systemMemoryMesh.LockVertexBuffer(LockFlags.ReadOnly);
                // Now compute the bounding sphere
                return Geometry.ComputeBoundingSphere(data, systemMemoryMesh.NumberVertices, 
                    systemMemoryMesh.VertexFormat, out center);
            }
            finally
            {
                // Make sure to unlock the vertex buffer
                if (data != null)
                    systemMemoryMesh.UnlockVertexBuffer();
            }
        }
        #endregion

        #region IDisposable Members

        /// <summary>Cleans up any resources required when this object is disposed</summary>
        public void Dispose()
        {
            OnLostDevice(null, EventArgs.Empty);
            if (meshTextures != null)
            {
                for(int i = 0; i < meshTextures.Length; i++)
                {
                    if (meshTextures[i] != null)
                        meshTextures[i].Dispose();
                }
            }
            meshTextures = null;
            meshMaterials = null;

            if (systemMemoryMesh != null)
                systemMemoryMesh.Dispose();

            systemMemoryMesh = null;

        }

        /// <summary>Cleans up any resources required when this object is disposed</summary>
        private void OnDeviceDisposing(object sender, EventArgs e)
        {
            // Just dispose of our class
            Dispose();
        }
        #endregion

    }
}