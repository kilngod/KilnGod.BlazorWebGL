using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.Shapes
{
    public struct MaterialGroup
    {
        public int Start { get; set; }
        public int Count { get; set; }
        public int MaterialIndex { get; set; }

        public MaterialGroup(int start, int count, int materialIndex)
        {
            Start = start;
            Count = count;
            MaterialIndex = materialIndex;
        }
    }
}
