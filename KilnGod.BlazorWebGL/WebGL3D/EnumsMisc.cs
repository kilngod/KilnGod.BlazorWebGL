using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum Error
    {
        NO_ERROR = 0,
        INVALID_ENUM = 0x0500,
        INVALID_VALUE = 0x0501,
        INVALID_OPERATION = 0x0502,
        OUT_OF_MEMORY = 0x0505,
        CONTEXT_LOST_WEBGL = 0x9242
    }

    public enum CompareFunction
    {
        NEVER = 0x0200,
        ALWAYS = 0x0207,
        LESS = 0x0201,
        EQUAL = 0x0202,
        LEQUAL = 0x0203,
        GREATER = 0x0204,
        GEQUAL = 0x0206,
        NOTEQUAL = 0x0205
    }
    public enum NumberType
    {
        BYTE = 0x1400,
        UNSIGNED_BYTE = 0x1401,
        SHORT = 0x1402,
        UNSIGNED_SHORT = 0x1403,
        INT = 0x1404,
        UNSIGNED_INT = 0x1405,
        FLOAT = 0x1406,
        FLOAT64 = 0x140A,
        HALF_FLOAT = 0x140B,
        INT64 =0,
        UNSIGNED_INT64=0
    }

   

    public enum UniformType
    {
        FLOAT_VEC2 = 0x8B50,
        FLOAT_VEC3 = 0x8B51,
        FLOAT_VEC4 = 0x8B52,
        INT_VEC2 = 0x8B53,
        INT_VEC3 = 0x8B54,
        INT_VEC4 = 0x8B55,
        BOOL = 0x8B56,
        BOOL_VEC2 = 0x8B57,
        BOOL_VEC3 = 0x8B58,
        BOOL_VEC4 = 0x8B59,
        FLOAT_MAT2 = 0x8B5A,
        FLOAT_MAT3 = 0x8B5B,
        FLOAT_MAT4 = 0x8B5C,
        SAMPLER_2D = 0x8B5E,
        SAMPLER_CUBE = 0x8B60
    }

  

}
