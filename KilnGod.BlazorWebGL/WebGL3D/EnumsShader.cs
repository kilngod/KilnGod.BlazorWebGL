using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum ShaderParameter
    {
        COMPILE_STATUS = 0x8B81,
        DELETE_STATUS = 0x8B80,
        SHADER_TYPE = 0x8B4F
    }

    public enum ShaderType
    {
        FRAGMENT_SHADER = 0x8B30,
        VERTEX_SHADER = 0x8B31
    }

    public enum ShaderPrecision
    {
        LOW_FLOAT = 0x8DF0,
        MEDIUM_FLOAT = 0x8DF1,
        HIGH_FLOAT = 0x8DF2,
        LOW_INT = 0x8DF3,
        MEDIUM_INT = 0x8DF4,
        HIGH_INT = 0x8DF5
    }
}
