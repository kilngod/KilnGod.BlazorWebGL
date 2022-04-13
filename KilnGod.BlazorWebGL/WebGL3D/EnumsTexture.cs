using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum TextureSlot
    {
        TEXTURE0 = 0x84C0,
        TEXTURE1,
        TEXTURE2,
        TEXTURE3,
        TEXTURE4,
        TEXTURE5,
        TEXTURE6,
        TEXTURE7,
        TEXTURE8,
        TEXTURE9,
        TEXTURE10,
        TEXTURE11,
        TEXTURE12,
        TEXTURE13,
        TEXTURE14,
        TEXTURE15,
        TEXTURE16,
        TEXTURE17,
        TEXTURE18,
        TEXTURE19,
        TEXTURE20,
        TEXTURE21,
        TEXTURE22,
        TEXTURE23,
        TEXTURE24,
        TEXTURE25,
        TEXTURE26,
        TEXTURE27,
        TEXTURE28,
        TEXTURE29,
        TEXTURE30,
        TEXTURE31
    }

    public enum TextureTarget
    {
        TEXTURE_2D = 0x0DE1,
        TEXTURE_CUBE_MAP = 0x8513,
    }

    public enum Texture2DType
    {
        TEXTURE_2D = 0x0DE1,
        TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515,
        TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516,
        TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517,
        TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518,
        TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519,
        TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A
    }

    public enum TextureParameter
    {
        TEXTURE_MAG_FILTER = 0x2800,
        TEXTURE_MIN_FILTER = 0x2801,
        TEXTURE_WRAP_R = 0x8072,
        TEXTURE_WRAP_S = 0x2802,
        TEXTURE_WRAP_T = 0x2803
    }

    public enum TextureParameterValue
    {
        NEAREST = 0x2600,
        LINEAR = 0x2601,
        NEAREST_MIPMAP_NEAREST = 0x2700,
        LINEAR_MIPMAP_NEAREST = 0x2701,
        NEAREST_MIPMAP_LINEAR = 0x2702,
        LINEAR_MIPMAP_LINEAR = 0x2703,
        REPEAT = 0x2901,
        CLAMP_TO_EDGE = 0x812F,
        MIRRORED_REPEAT = 0x8370
    }
}
