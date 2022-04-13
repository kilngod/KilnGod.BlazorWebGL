using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace KilnGod.BlazorWebGL.WebGL3D
{
    [DataContract]
    public struct GLColor
    {
        [DataMember] public float R { get; set; }
        [DataMember] public float G { get; set; }
        [DataMember] public float B { get; set; }
        [DataMember] public float A { get; set; }

        public GLColor(float r, float g, float b, float a)
            : this()
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        
    }
}
