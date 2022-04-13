using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum Face
    {
        FRONT = 0x0404,
        BACK = 0x0405,
        FRONT_AND_BACK = 0x0408
    }

    public enum FrontFaceDirection
    {
        CW = 0x0900,
        CCW = 0x0901
    }
}
