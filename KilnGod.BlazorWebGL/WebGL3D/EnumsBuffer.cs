using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{

    public enum ArrayCap
    {
        VertexArray = 32884,
        NormalArray = 32885,
        ColorArray = 32886,
        IndexArray = 32887,
        TextureCoordArray = 32888,
        EdgeFlagArray = 32889,
        FogCoordArray = 33879,
        SecondaryColorArray = 33886
    }


    public enum BufferType
    {
        RENDERBUFFER = 0x8D41,    
        FRAMEBUFFER = 0x8D40
    }

    public enum BufferTargetType
    {
        ARRAY_BUFFER = 0x8892,
        ELEMENT_ARRAY_BUFFER = 0x8893,
        COPY_READ_BUFFER = 0x8F36,
        COPY_WRITE_BUFFER = 0x8F37,
        TRANSFORM_FEEDBACK_BUFFER = 0x8C8E,
        UNIFORM_BUFFER = 0x8A11,
        PIXEL_PACK_BUFFER = 0x88EB,
        PIXEL_UNPACK_BUFFER = 0x88EC
    }

    public enum BufferUsage
    {
        STATIC_DRAW = 0x88E4,
        STREAM_DRAW = 0x88E0,
        DYNAMIC_DRAW = 0x88E8,
        STATIC_READ = 0x88E5,
        DYNAMIC_READ = 0x88E9,
        STREAM_READ = 0x88E1,
        STATIC_COPY = 0x88E6,
        DYNAMIC_COPY = 0x88EA,
        STREAM_COPY= 0x88E2

    }

    public enum BufferParameter
    {
        BUFFER_SIZE = 0x8764,
        BUFFER_USAGE = 0x8765
    }

    public enum BufferMask
    {
        COLOR_BUFFER_BIT = 0x00004000,
        DEPTH_BUFFER_BIT = 0x00000100,
        STENCIL_BUFFER_BIT = 0x00000400
    }




    public enum RenderbufferParameter
    {
        RENDERBUFFER_WIDTH = 0x8D42,
        RENDERBUFFER_HEIGHT = 0x8D43,
        RENDERBUFFER_INTERNAL_FORMAT = 0x8D44,
        RENDERBUFFER_RED_SIZE = 0x8D50,
        RENDERBUFFER_GREEN_SIZE = 0x8D51,
        RENDERBUFFER_BLUE_SIZE = 0x8D52,
        RENDERBUFFER_ALPHA_SIZE = 0x8D53,
        RENDERBUFFER_DEPTH_SIZE = 0x8D54,
        RENDERBUFFER_STENCIL_SIZE = 0x8D55,
        RENDERBUFFER_SAMPLES = 0x8CAB
    }

   
    public enum RenderbufferFormat
    {
        RGBA4 = 0x8056,
        RGB5_A1 = 0x8057,
        RGB565 = 0x8D62,
        DEPTH_COMPONENT16 = 0x81A5,
        STENCIL_INDEX8 = 0x8D48,
        DEPTH_STENCIL = 0x84F9
    }
}
