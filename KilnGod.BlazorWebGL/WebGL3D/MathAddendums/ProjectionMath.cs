using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace KilnGod.BlazorWebGL.WebGL3D.MathAddendums
{
    public class ProjectionMath
    {
        public static (int x, int y, float depth) ProjectToScreen(
            float near,
            Vector2 imageSize,
            Vector3 worldPos,
        Matrix4x4 worldViewProjectionMatrix)
        {
            worldPos = Vector3.Transform(worldPos, worldViewProjectionMatrix);

            float x = near * worldPos.X / -worldPos.Z;
            float y = near * worldPos.Y / -worldPos.Z;
            x = (x + 1.0f) * 0.5f * imageSize.X;
            y = (1.0f - y) * 0.5f * imageSize.Y;
            return ((int)x, (int)y, -worldPos.Z);
        }
    }
}
