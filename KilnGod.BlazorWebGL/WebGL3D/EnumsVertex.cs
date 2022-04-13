using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum VertexAttribute
    {
        CURRENT_VERTEX_ATTRIB = 0x8626,
        VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622,
        VERTEX_ATTRIB_ARRAY_SIZE = 0x8623,
        VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624,
        VERTEX_ATTRIB_ARRAY_TYPE = 0x8625,
        VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A,
        VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F
    }

    public enum VertexAttributePointer
    {
        VERTEX_ATTRIB_ARRAY_POINTER = 0x8645
    }
}
