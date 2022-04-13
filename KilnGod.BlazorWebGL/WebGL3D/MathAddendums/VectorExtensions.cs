using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace KilnGod.BlazorWebGL.WebGL3D.MathAddendums
{
    public static class VectorExtensions
    {
        public static readonly Vector2[] NullVector2x2 = new Vector2[2] { Vector2.Zero, Vector2.Zero };

        public static readonly Vector3[] NullVector3x3 = new Vector3[3] { Vector3.Zero, Vector3.Zero, Vector3.Zero };

        public static readonly Vector4[] NullVector4x4 = new Vector4[4] { Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero };

        public static Vector2[] NewVector2x2 = new Vector2[2] { Vector2.Zero, Vector2.Zero };

        public static Vector3[] NewVector3x3 = new Vector3[3] { Vector3.Zero, Vector3.Zero, Vector3.Zero };

        public static Vector4[] NewVector4x4 = new Vector4[4] { Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero };
    }
}
