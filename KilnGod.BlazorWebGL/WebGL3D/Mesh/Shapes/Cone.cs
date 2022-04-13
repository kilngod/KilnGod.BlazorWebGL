using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.Shapes
{

    // similar to three.js -> ConeGeometery.js
    public class Cone : Cylinder
    {

        public Cone(float radius = 1, float height = 1, int radialSegments = 8, int heightSegments = 1, bool openEnded = false, float thetaStart = 0, float thetaLength = MathF.PI * 2)
            : base(0, radius, height, radialSegments, heightSegments, openEnded, thetaStart, thetaLength)
        {
           
        }

    }
}
