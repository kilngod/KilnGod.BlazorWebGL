using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum EnumSamplerInt 
    {
        
        TEXTURE_COMPARE_FUNC = 0x884D,
        TEXTURE_COMPARE_MODE= 0x884C,
        TEXTURE_BASE_LEVEL = 0x813C,
        TEXTURE_MAX_LEVEL = 0x813D,
        TEXTURE_MAG_FILTER = 0x2800,
        TEXTURE_MIN_FILTER = 0x2801,
        TEXTURE_WRAP_R = 0x8072,
        TEXTURE_WRAP_S = 0x2802,
        TEXTURE_WRAP_T = 0x2803
    }

    public enum EnumSamplerFloat
    {
        TEXTURE_MAX_LOD = 0x813B,
        TEXTURE_MIN_LOD = 0x813A        
    }

    public enum EnumSamplerBool
    {
        TEXTURE_IMMUTABLE_FORMAT = 0x912F       
    }

    public enum EnumSamplerUInt
    {
        TEXTURE_IMMUTABLE_LEVELS = 0x82DF
    }
}
