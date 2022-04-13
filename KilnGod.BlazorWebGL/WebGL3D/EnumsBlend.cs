using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum BlendingEquation
    {
        FUNC_ADD = 0x8006,
        FUNC_SUBTRACT = 0x800A,
        FUNC_REVERSE_SUBTRACT = 0x800B,
        
    }

    public enum BlendFactor
    {
        ZERO = 0,
        ONE = 1,
        SRC_COLOR = 0x300,
        ONE_MINUS_SRC_COLOR = 0x301,
        SRC_ALPHA = 0x302,
        ONE_MINUS_SRC_ALPHA = 0x303,
        DST_ALPHA = 0x304,
        ONE_MINUS_DST_ALPHA = 0x305,
        DST_COLOR = 0x306,
        ONE_MINUS_DST_COLOR = 0x307,
        SRC_ALPHA_SATURATE = 0x308,
        CONSTANT_COLOR = 0x8001,
        ONE_MINUS_CONSTANT_COLOR = 0x8002,
        CONSTANT_ALPHA = 0x8003,
        ONE_MINUS_CONSTANT_ALPHA = 0x8004,
        BLEND_COLOR = 0x8005
    }

    public enum BlendParameter
    {
        BLEND_EQUATION_RGB = 0x8009,
        BLEND_DST_RGB = 0x80C8,
        BLEND_SRC_RBG = 0x80C9,
        BLEND_DST_ALPHA = 0x80CA,
        BLEND_SRC_ALPHA = 0x80CB,
        BLEND_EQUATION_ALPHA = 0x883D
    }

}
