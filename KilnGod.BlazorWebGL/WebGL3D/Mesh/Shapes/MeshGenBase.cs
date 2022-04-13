using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using KilnGod.BlazorWebGL.WebGL3D.MathAddendums;

namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.Shapes
{

    // similar to three.js -> BufferGeometery.js
    public abstract class MeshGenBase
    {
#nullable disable
        public List<Vector3i> Indices { get; set; }
        public List<Vector3> Vertices { get; set; }
        public List<Vector3> Normals { get; set; }
        public List<Vector2> TextureCoords { get; set; }

        public List<MaterialGroup> Groups {get;set;}
#nullable enable

        public virtual bool ComputeMesh()
        {
            Indices = new List<Vector3i>();
            Vertices = new List<Vector3>();
            Normals = new List<Vector3>();
            TextureCoords = new List<Vector2>();
            Groups = new List<MaterialGroup>();

            return true;
        }

        /*
        public void computeVertexNormals()
        {

            const index = this.index;
            const positionAttribute = this.getAttribute('position');

            if (positionAttribute !== undefined)
            {

                let normalAttribute = this.getAttribute('normal');

                if (normalAttribute === undefined)
                {

                    normalAttribute = new BufferAttribute(new Float32Array(positionAttribute.count * 3), 3);
                    this.setAttribute('normal', normalAttribute);

                }
                else
                {

                    // reset existing normals to zero

                    for (let i = 0, il = normalAttribute.count; i < il; i++)
                    {

                        normalAttribute.setXYZ(i, 0, 0, 0);

                    }

                }

                const pA = new Vector3(), pB = new Vector3(), pC = new Vector3();
                const nA = new Vector3(), nB = new Vector3(), nC = new Vector3();
                const cb = new Vector3(), ab = new Vector3();

                // indexed elements

                if (index)
                {

                    for (let i = 0, il = index.count; i < il; i += 3)
                    {

                        const vA = index.getX(i + 0);
                        const vB = index.getX(i + 1);
                        const vC = index.getX(i + 2);

                        pA.fromBufferAttribute(positionAttribute, vA);
                        pB.fromBufferAttribute(positionAttribute, vB);
                        pC.fromBufferAttribute(positionAttribute, vC);

                        cb.subVectors(pC, pB);
                        ab.subVectors(pA, pB);
                        cb.cross(ab);

                        nA.fromBufferAttribute(normalAttribute, vA);
                        nB.fromBufferAttribute(normalAttribute, vB);
                        nC.fromBufferAttribute(normalAttribute, vC);

                        nA.add(cb);
                        nB.add(cb);
                        nC.add(cb);

                        normalAttribute.setXYZ(vA, nA.x, nA.y, nA.z);
                        normalAttribute.setXYZ(vB, nB.x, nB.y, nB.z);
                        normalAttribute.setXYZ(vC, nC.x, nC.y, nC.z);

                    }

                }
                else
                {

                    // non-indexed elements (unconnected triangle soup)

                    for (let i = 0, il = positionAttribute.count; i < il; i += 3)
                    {

                        pA.fromBufferAttribute(positionAttribute, i + 0);
                        pB.fromBufferAttribute(positionAttribute, i + 1);
                        pC.fromBufferAttribute(positionAttribute, i + 2);

                        cb.subVectors(pC, pB);
                        ab.subVectors(pA, pB);
                        cb.cross(ab);

                        normalAttribute.setXYZ(i + 0, cb.x, cb.y, cb.z);
                        normalAttribute.setXYZ(i + 1, cb.x, cb.y, cb.z);
                        normalAttribute.setXYZ(i + 2, cb.x, cb.y, cb.z);

                    }

                }

                this.normalizeNormals();

                normalAttribute.needsUpdate = true;

            }

        }
        */

        public float[] Get_GPU_Vertices()
        {
            List<float> vertices = new List<float>();

            for (int i = 0; i < Vertices.Count; i++)
            {
                
                vertices.Add(Vertices[i].X);
                vertices.Add(Vertices[i].Y);
                vertices.Add(Vertices[i].Z);

            }

            return vertices.ToArray();
        }


        public float[] Get_GPU_Normals()
        {
            List<float> normals = new List<float>();

            for (int i = 0; i < Normals.Count; i++)
            {
               
                normals.Add(Normals[i].X);
                normals.Add(Normals[i].Y);
                normals.Add(Normals[i].Z);
            }

            return normals.ToArray();
        }


        public uint[] Get_GPU_Indices_uInt()
        {
            List<uint> indices = new List<uint>();

            for (int i = 0; i < Indices.Count; i++)
            {
                
                indices.Add((uint)Indices[i].X);
                indices.Add((uint)Indices[i].Y);
                indices.Add((uint)Indices[i].Z);
            }

            return indices.ToArray();
        }


        public ushort[] Get_GPU_Indices_uShort()
        {
            List<ushort> indices = new List<ushort>();

            for (int i = 0; i < Indices.Count; i++)
            {

                indices.Add((ushort)Indices[i].X);
                indices.Add((ushort)Indices[i].Y);
                indices.Add((ushort)Indices[i].Z);
            }

            return indices.ToArray();
        }

        public float[] Get_GPU_TextureCoords()
        {
          
                List<float> textureCoords = new List<float>();

                for (int i = 0; i < TextureCoords.Count; i++)
                {

                textureCoords.Add(TextureCoords[i].X);
                textureCoords.Add(TextureCoords[i].Y);
              
                }

                return textureCoords.ToArray();
            }

        }
}
