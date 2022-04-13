using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Reflection;


namespace KilnGod.BlazorWebGL.WebGL3D.MathAddendums
{
    public enum VectorComponent
    {
        X, Y, Z, W
    }

    public static class MathHelper
    {
        /// <summary>
        /// Clamps a number between a minimum and a maximum.
        /// </summary>
        /// <param name="n">The number to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>min, if n is lower than min; max, if n is higher than max; n otherwise.</returns>
        [Pure]
        public static int Clamp(int n, int min, int max)
        {
            return Math.Max(Math.Min(n, max), min);
        }


        [Pure]
        public static float Clamp(float n, float min, float max)
        {
            return MathF.Max(MathF.Min(n, max), min);
        }

        public static void Copy(ref this Vector2 target, Vector2 value)
        {
            target.X = value.X;
            target.Y = value.Y;
        }

        public static int Floor(this float value)
        {
            return Convert.ToInt32(MathF.Round(value, MidpointRounding.ToZero));
        }

        public static float ToFloat(this int value)
        {
            return Convert.ToSingle(value);
        }

        internal static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;




        public static void Set(ref this Vector2 value, Vector2 vec)
        {
            value.X = vec.X;
            value.Y = vec.Y;
        }

        public static void Set(ref this Vector2 value, float x, float y)
        {
            value.X = x;
            value.Y = y;
        }

        public static void Set(ref this Vector3 value, Vector3 vec)
        {
            value.X = vec.X;
            value.Y = vec.Y;
            value.Z = vec.Z;
        }

        public static void Set(ref this Vector3 value, float x, float y, float z)
        {
            value.X = x;
            value.Y = y;
            value.Z = z;
        }

        public static Vector3 CrossVectors(this Vector3 a, Vector3 b)
        {

            Vector3 result = new Vector3();

            result.X = a.Y * b.Z - a.Z * b.Y;
            result.Y = a.Z * b.X - a.X * b.Z;
            result.Z = a.X * b.Y - a.Y * b.X;

            return result;

        }

        public static Vector3 Normalize(this Vector3 value)
        {
            Vector3 result = new Vector3();
            float length = value.Length();
            if (length > 0)
            {
                result.X = value.X / length;
                result.Y = value.Y / length;
                result.Z = value.Z / length;
            }
            else // can't normalize
            {
                result.X = value.X;
                result.Y = value.Y;
                result.Z = value.Z;
            }
            return result;
        }

        public static void SelfNormalize(ref this Vector3 value)
        {

            float length = value.Length();
            if (length > 0)
            {
                value.X = value.X / length;
                value.Y = value.Y / length;
                value.Z = value.Z / length;
            }

        }

        public static void SelfNormalize(ref this Vector2 value)
        {

            float length = value.Length();
            if (length > 0)
            {
                value.X = value.X / length;
                value.Y = value.Y / length;
            }

        }

        public static float DistanceTo(ref this Vector2 value, Vector2 target)
        {
            Vector2 result = target - value;
            return result.Length();
        }


        public static void SetComponent(ref this Vector3 vec, VectorComponent component, float value)
        {
            switch (component)
            {
                case VectorComponent.X:
                    vec.X = value;
                    break;
                case VectorComponent.Y:
                    vec.Y = value;
                    break;
                case VectorComponent.Z:
                    vec.Z = value;
                    break;

            }

        }


        public static Matrix4x4 MakeRotationAxis(Vector3 axis, float angle)
        {

            // Based on http://www.gamedev.net/reference/articles/article1199.asp


            float c = MathF.Cos(angle);
            float s = MathF.Sin(angle);
            float t = 1 - c;
            float x = axis.X, y = axis.Y, z = axis.Z;
            float tx = t * x, ty = t * y;
            Matrix4x4 result = new Matrix4x4(
                tx * x + c, tx * y - s * z, tx * z + s * y, 0,
                tx * y + s * z, ty * y + c, ty * z - s * x, 0,
                tx * z - s * y, ty * z + s * x, t * z * z + c, 0,
                0, 0, 0, 1

            );

            return result;

        }



        public static void ApplyMatrix4(ref this Vector3 vec, Matrix4x4 m)
        {

            float x = vec.X, y = vec.Y, z = vec.Z;
            /*
            const e = m.elements;
            
            const w = 1 / (e[3] * x + e[7] * y + e[11] * z + e[15]);

            vec.x = (e[0] * x + e[4] * y + e[8] * z + e[12]) * w;
            vec.y = (e[1] * x + e[5] * y + e[9] * z + e[13]) * w;
            vec.z = (e[2] * x + e[6] * y + e[10] * z + e[14]) * w;
            */
            // I hope I got the orientation right
            float w = 1 / (m.M14 * x + m.M42 * y + m.M43 * z + m.M44);

            vec.X = (m.M11 * x + m.M12 * y + m.M13 * z + m.M14) * w;
            vec.Y = (m.M21 * x + m.M22 * y + m.M23 * z + m.M24) * w;
            vec.Z = (m.M31 * x + m.M32 * y + m.M33 * z + m.M34) * w;

        }
    }
}
