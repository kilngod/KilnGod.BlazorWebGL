using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    public static class ColorExtensions
    {
        public const float max = 255;

        public static float toGLRed(this Color color)
        {
           return Convert.ToInt32(color.R) / max;
        }

        public static float toGLGreen(this Color color)
        {
           return Convert.ToInt32(color.G) / max;
        }

        public static float toGLBlue(this Color color)
        {
            return Convert.ToInt32(color.B) / max;
        }
        public static float toGLAlpha(this Color color)
        {
            return Convert.ToInt32(color.A) / max;
        }

        public static GLColor FromColor(this Color color)
        {
            return new GLColor() { R = color.toGLRed(), G = color.toGLGreen(), B = color.toGLBlue(), A = color.toGLAlpha() };
        }

        public static Color ToColor(this GLColor color)
        {
            return Color.FromArgb((int)((uint)(color.R * ColorExtensions.max) | ((uint)(color.G * ColorExtensions.max) << 8) | ((uint)(color.B * ColorExtensions.max) << 16) | ((uint)(color.A * ColorExtensions.max) << 24)));
        }

        public static uint ToRGBA(this Color color)
        {
            uint u = (UInt32)color.R << 24 | (UInt32)color.G << 16| (UInt32)color.B << 8| color.A;
            return u;

           
        }

        public static uint ToUInt32(this Color color)
        {
            return (uint)(color.R * 255) | ((uint)(color.G * 255) << 8) | ((uint)(color.B * 255) << 16) | ((uint)(color.A * 255) << 24);
        }

        public static uint ToUInt32(this GLColor color)
        {
            return (uint)(color.R * ColorExtensions.max) | ((uint)(color.G * ColorExtensions.max) << 8) | ((uint)(color.B * ColorExtensions.max) << 16) | ((uint)(color.A * ColorExtensions.max) << 24);
        }
    }
}
