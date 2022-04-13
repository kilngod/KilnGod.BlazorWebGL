using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public enum DrawMode
    {
        POINTS = 0x0000,
        LINES = 0x0001,
        LINE_LOOP = 0x0002,
        LINE_STRIP = 0x0003,
        TRIANGLES = 0x0004,
        TRIANGLE_FAN = 0x0006,
        TRIANGLE_STRIP = 0x0005
    }

    public enum Enable
    {
        BLEND = 0x0BE2,
        CULL_FACE = 0x0B44,
        DEPTH_TEST = 0x0B71,
        DITHER = 0x0BD0,
        POLYGON_OFFSET_FILL = 0x8037,
        SAMPLE_ALPHA_TO_COVERAGE = 0x809E,
        SAMPLE_COVERAGE = 0x80A0,
        SCISSOR_TEST = 0x0C11,
        STENCIL_TEST = 0x0B90

    }
}
