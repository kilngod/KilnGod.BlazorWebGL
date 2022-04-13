using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.STL
{
    public class STLMesh
    {

        public STLMesh(TriangleMesh[] mesh)
        {
            Mesh = mesh;
        }

        public TriangleMesh[] Mesh { get; set; }

        public Vector3 Center { get; set; }

        public Vector3 Axis { get; set; }

        public float[] Get_Mesh_Vertices()
        {
            List<float> vertices = new List<float>();

            for (int i = 0; i < Mesh.Length; i++)
            {
                /* vertex 1 */
                vertices.Add(Mesh[i].Vertex1.X);
                vertices.Add(Mesh[i].Vertex1.Y);
                vertices.Add(Mesh[i].Vertex1.Z);
                /* vertex 2 */
                vertices.Add(Mesh[i].Vertex2.X);
                vertices.Add(Mesh[i].Vertex2.Y);
                vertices.Add(Mesh[i].Vertex2.Z);
                /* vertex 3 */
                vertices.Add(Mesh[i].Vertex3.X);
                vertices.Add(Mesh[i].Vertex3.Y);
                vertices.Add(Mesh[i].Vertex3.Z);
            }

            return vertices.ToArray();
        }


        public float[] Get_Mesh_Vertices(float zOffset)
        {
            List<float> vertices = new List<float>();

            for (int i = 0; i < Mesh.Length; i++)
            {
                /* vertex 1 */
                vertices.Add(Mesh[i].Vertex1.X);
                vertices.Add(Mesh[i].Vertex1.Y);
                vertices.Add(Mesh[i].Vertex1.Z + zOffset);
                /* vertex 2 */
                vertices.Add(Mesh[i].Vertex2.X);
                vertices.Add(Mesh[i].Vertex2.Y);
                vertices.Add(Mesh[i].Vertex2.Z + zOffset);
                /* vertex 3 */
                vertices.Add(Mesh[i].Vertex3.X);
                vertices.Add(Mesh[i].Vertex3.Y);
                vertices.Add(Mesh[i].Vertex3.Z + zOffset);
            }

            return vertices.ToArray();
        }

        public float[] Get_Mesh_Normals()
        {
            List<float> normals = new List<float>();

            for (int i = 0; i < Mesh.Length; i++)
            {
                /* normal 1 */
                normals.Add(Mesh[i].Normal1.X);
                normals.Add(Mesh[i].Normal1.Y);
                normals.Add(Mesh[i].Normal1.Z);
                /* normal 2 */
                normals.Add(Mesh[i].Normal2.X);
                normals.Add(Mesh[i].Normal2.Y);
                normals.Add(Mesh[i].Normal2.Z);
                /* normal 3 */
                normals.Add(Mesh[i].Normal3.X);
                normals.Add(Mesh[i].Normal3.Y);
                normals.Add(Mesh[i].Normal3.Z);
            }

            return normals.ToArray();
        }


        public Vector3 GetMinMeshPosition()
        {
            Vector3 minVec = new Vector3();
            float[] minRefArray = new float[3];
            minRefArray[0] = Mesh.Min(j => j.Vertex1.X);
            minRefArray[1] = Mesh.Min(j => j.Vertex2.X);
            minRefArray[2] = Mesh.Min(j => j.Vertex3.X);
            minVec.X = minRefArray.Min();
            minRefArray[0] = Mesh.Min(j => j.Vertex1.Y);
            minRefArray[1] = Mesh.Min(j => j.Vertex2.Y);
            minRefArray[2] = Mesh.Min(j => j.Vertex3.Y);
            minVec.Y = minRefArray.Min();
            minRefArray[0] = Mesh.Min(j => j.Vertex1.Z);
            minRefArray[1] = Mesh.Min(j => j.Vertex2.Z);
            minRefArray[2] = Mesh.Min(j => j.Vertex3.Z);
            minVec.Z = minRefArray.Min();
            return minVec;
        }


        public Vector3 GetMaxMeshPosition()
        {
            Vector3 maxVec = new Vector3();
            float[] maxRefArray = new float[3];
            maxRefArray[0] = Mesh.Max(j => j.Vertex1.X);
            maxRefArray[1] = Mesh.Max(j => j.Vertex2.X);
            maxRefArray[2] = Mesh.Max(j => j.Vertex3.X);
            maxVec.X = maxRefArray.Max();
            maxRefArray[0] = Mesh.Max(j => j.Vertex1.Y);
            maxRefArray[1] = Mesh.Max(j => j.Vertex2.Y);
            maxRefArray[2] = Mesh.Max(j => j.Vertex3.Y);
            maxVec.Y = maxRefArray.Max();
            maxRefArray[0] = Mesh.Max(j => j.Vertex1.Z);
            maxRefArray[1] = Mesh.Max(j => j.Vertex2.Z);
            maxRefArray[2] = Mesh.Max(j => j.Vertex3.Z);
            maxVec.Z = maxRefArray.Max();
            return maxVec;
        }
    }
}
