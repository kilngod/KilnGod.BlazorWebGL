using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.STL
{
    public class TriangleMesh
    {
        public Vector3 Normal1;
        public Vector3 Normal2;
        public Vector3 Normal3;
        public Vector3 Vertex1;
        public Vector3 Vertex2;
        public Vector3 Vertex3;
     

        public TriangleMesh()
        {

            Normal1 = new Vector3();
            Normal2 = new Vector3();
            Normal3 = new Vector3();
            Vertex1 = new Vector3();
            Vertex2 = new Vector3();
            Vertex3 = new Vector3();
          
            
        }



    }

}
