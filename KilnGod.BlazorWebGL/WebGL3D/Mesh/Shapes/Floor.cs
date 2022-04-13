using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using KilnGod.BlazorWebGL.WebGL3D.MathAddendums;

namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.Shapes
{
	// similar to three.js -> ConeGeometery.js
	public class Floor : MeshGenBase
	{
		float Width { get; set; }
		float Height { get; set; }
		int WidthSegments { get; set; }
		int HeightSegments { get; set; }

		public Floor(float width = 1, float height = 1, int widthSegments = 1, int heightSegments = 1)
		{
			Width = width;
			Height = height;
			WidthSegments = widthSegments;
			HeightSegments = heightSegments;

			ComputeMesh();
		}

		public override bool ComputeMesh()
		{
			base.ComputeMesh();

			float width_half = Width / 2;
			float height_half = Height / 2;

			int gridX = WidthSegments;
			int gridY = HeightSegments;

			int gridX1 = gridX + 1;
			int gridY1 = gridY + 1;

			float segment_width = Width / gridX;
			float segment_height = Height / gridY;




			for (int iy = 0; iy < gridY1; iy++)
			{

				float y = iy * segment_height - height_half;

				for (int ix = 0; ix < gridX1; ix++)
				{

					float x = ix * segment_width - width_half;

					Vertices.Add(new Vector3(x, -y, 0));

					Normals.Add(new Vector3(0, 0, 1));

					TextureCoords.Add(new Vector2(ix / gridX, 1 - (iy / gridY)));

				}

			}

			for (int iy = 0; iy < gridY; iy++)
			{

				for (int ix = 0; ix < gridX; ix++)
				{

					int a = ix + gridX1 * iy;
					int b = ix + gridX1 * (iy + 1);
					int c = (ix + 1) + gridX1 * (iy + 1);
					int d = (ix + 1) + gridX1 * iy;

					Indices.Add(new Vector3i(a, b, d));
					Indices.Add(new Vector3i(b, c, d));

				}

			}


			return true;
		}
	}
}
