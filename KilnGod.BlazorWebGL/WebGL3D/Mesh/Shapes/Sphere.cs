using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using KilnGod.BlazorWebGL.WebGL3D.MathAddendums;


namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.Shapes
{

    // similar to three.js -> SphereGeometery.js
    public class Sphere : MeshGenBase
    {
		public float Radius { get; set; }
		public float WidthSegments { get; set; }
		public float HeightSegments { get; set; }
		public float PhiStart { get; set; }
		public float PhiLength { get; set; }

		public float ThetaStart { get; set; }

		public float ThetaLength { get; set; }



		public Sphere(float radius = 1, int widthSegments = 8, int heightSegments = 6, float phiStart = 0, float phiLength = MathF.PI * 2, float thetaStart = 0, float thetaLength = MathF.PI)
        {

			
			Radius = radius;
			PhiStart = phiStart;
			PhiLength = phiLength;
			ThetaStart = thetaStart;
			ThetaLength = thetaLength;

			WidthSegments = Math.Max(3, widthSegments);
			HeightSegments = Math.Max(2, heightSegments);

			ComputeMesh();

		}

		public override bool ComputeMesh()
        {
			base.ComputeMesh();


			float thetaEnd = Math.Min(ThetaStart + ThetaLength, MathF.PI);



			int index = 0;
			List<List<int>> grid = new List<List<int>>();

		
			// buffers

		

			// generate vertices, normals and uvs

			for (int iy = 0; iy <= HeightSegments; iy++)
			{

				List<int> verticesRow = new List<int>();

				float v = iy / HeightSegments;

				// special case for the poles

				float uOffset = 0;

				if (iy == 0 && ThetaStart == 0)
				{

					uOffset = 0.5f / WidthSegments;

				}
				else if (iy == HeightSegments && thetaEnd == Math.PI)
				{

					uOffset = -0.5f / WidthSegments;

				}

				for (int ix = 0; ix <= WidthSegments; ix++)
				{

					float u = ix / WidthSegments;

					// vertex

					Vector3 vertex = new Vector3();
					Vector2 uv = new Vector2();

					vertex.X = -Radius * MathF.Cos(PhiStart + u * PhiLength) * MathF.Sin(ThetaStart + v * ThetaLength);
					vertex.Y = Radius * MathF.Cos(ThetaStart + v * ThetaLength);
					vertex.Z = Radius * MathF.Sin(PhiStart + u * PhiLength) * MathF.Sin(ThetaStart + v * ThetaLength);

					Vertices.Add(vertex);


					Vector3 normal = vertex.Normalize(); // normalize add
					Normals.Add(normal);

					uv.X = u + uOffset;
					uv.Y = 1 - v;
					// uv

					TextureCoords.Add(uv);

					verticesRow.Add(index++);

				}

				grid.Add(verticesRow);

			}

			// indices

			for (int iy = 0; iy < HeightSegments; iy++)
			{

				for (int ix = 0; ix < WidthSegments; ix++)
				{
					
					int a = grid[iy][ix + 1];
					int b = grid[iy][ix];
					int c = grid[iy + 1][ix];
					int d = grid[iy + 1][ix + 1];


					if (iy != 0 || ThetaStart > 0)
					{
						Vector3i indice = new Vector3i(a, b, d);
						Indices.Add(indice);
					}
					if (iy != HeightSegments - 1 || thetaEnd < MathF.PI)
					{
						Vector3i indice = new Vector3i(b, c, d);
						Indices.Add(indice);
					}
					
				}

			}


			return true;
        } 
    }
}
