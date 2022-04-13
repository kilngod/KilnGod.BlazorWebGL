using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum HintMode
    {
        DONT_CARE = 0x1100,
        FASTEST = 0x1101,
        NICEST = 0x1102
    }

    public enum HintTarget
    {
        GENERATE_MIPMAP_HINT = 0x8192
    }
}
