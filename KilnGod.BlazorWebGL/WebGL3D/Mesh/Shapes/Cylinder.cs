using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using KilnGod.BlazorWebGL.WebGL3D.MathAddendums;

namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.Shapes
{

    // similar to three.js -> CylinderGeometery.js
    public class Cylinder : MeshGenBase
    {

        public float RadiusTop { get; set; }
        public float RadiusBottom { get; set; }
        public float Height { get; set; }
        public int RadialSegments { get; set; }
        public int HeightSegments { get; set; }
        public bool OpenEnded { get; set; }
        public float ThetaStart { get; set; }
        public float ThetaLength { get; set; }


        public Cylinder(float radiusTop = 1, float radiusBottom = 1, float height = 1, int radialSegments = 8, int heightSegments = 1, bool openEnded = false, float thetaStart = 0, float thetaLength = MathF.PI * 2)
        {
            RadiusTop = radiusTop;
            RadiusBottom = radiusBottom;
            Height = height;
            RadialSegments = radialSegments;
            HeightSegments = heightSegments;
            OpenEnded = openEnded;
            ThetaStart = thetaStart;
            ThetaLength = thetaLength;

            ComputeMesh();
        }


		private int index;
		private float halfHeight;
		private int groupStart;
		private List<List<int>> indexArray = new List<List<int>>();

		public override bool ComputeMesh()
		{
			base.ComputeMesh();

			index = 0;
			indexArray.Clear();
			halfHeight = Height / 2;
			groupStart = 0;

			// generate geometry

			generateTorso();

			if (OpenEnded == false)
			{

				if (RadiusTop > 0) generateCap(true);
				if (RadiusBottom > 0) generateCap(false);

			}
			return true;
		}

		private void generateTorso()
		{

			int groupCount = 0;

			// this will be used to calculate the normal
			float slope = (RadiusBottom - RadiusTop) / Height;

			// generate vertices, normals and uvs

			for (int y = 0; y <= HeightSegments; y++)
			{

				List<int> indexRow = new List<int>();

				float v = y / HeightSegments;

				// calculate the radius of the current row

				float radius = v * (RadiusBottom - RadiusTop) + RadiusTop;

				for (int x = 0; x <= RadialSegments; x++)
				{

					float u = x.ToFloat() / RadialSegments.ToFloat();

					float theta = u * ThetaLength + ThetaStart;

					float sinTheta = MathF.Sin(theta);
					float cosTheta = MathF.Cos(theta);

					// vertex
					Vector3 vertex = new Vector3();
					vertex.X = radius * sinTheta;
					vertex.Y = -v * Height + halfHeight;
					vertex.Z = radius * cosTheta;
					Vertices.Add(vertex);

					// normal
					Vector3 normal = new Vector3(sinTheta, slope, cosTheta);
					normal.SelfNormalize();
					Normals.Add(normal);

					// uv

					TextureCoords.Add(new Vector2(u, 1 - v));

					// save index of vertex in respective row

					indexRow.Add(index++);

				}

				// now save vertices of the row in our index array

				indexArray.Add(indexRow);

			}

			// generate indices

			for (int x = 0; x < RadialSegments; x++)
			{

				for (int y = 0; y < HeightSegments; y++)
				{

					// we use the index array to access the correct indices

					int a = indexArray[y][x];
					int b = indexArray[y + 1][x];
					int c = indexArray[y + 1][x + 1];
					int d = indexArray[y][x + 1];

					// faces

					Indices.Add(new Vector3i( a, b, d));
					Indices.Add(new Vector3i(b, c, d));

					// update group counter

					groupCount += 6;

				}

			}

			// add a group to the geometry. this will ensure multi material support

			Groups.Add(new MaterialGroup( groupStart, groupCount, 0 ));

			// calculate new start value for groups

			groupStart += groupCount;

		
			
        }

		private void generateCap(bool top)
		{

			// save the index of the first center vertex
			int centerIndexStart = index;

		

			int groupCount = 0;

			float radius = (top == true) ? RadiusTop : RadiusBottom;
			int sign = (top == true) ? 1 : -1;

			// first we generate the center vertex data of the cap.
			// because the geometry needs one set of uvs per face,
			// we must generate a center vertex per face/segment

			for (int x = 1; x <= RadialSegments; x++)
			{

				// vertex

				Vertices.Add(new Vector3( 0, halfHeight * sign, 0));

				// normal

				Normals.Add(new Vector3( 0, sign, 0));

				// uv

				TextureCoords.Add(new Vector2(0.5f, 0.5f));

				// increase index

				index++;

			}

			// save the index of the last center vertex
			int centerIndexEnd = index;

			// now we generate the surrounding vertices, normals and uvs

			for (int x = 0; x <= RadialSegments; x++)
			{

				float u = x.ToFloat() / RadialSegments.ToFloat();
				float theta = u * ThetaLength + ThetaStart;

				float cosTheta = MathF.Cos(theta);
				float sinTheta = MathF.Sin(theta);

				// vertex
				Vector3 vertex = new Vector3();
				vertex.X = radius * sinTheta;
				vertex.Y = halfHeight * sign;
				vertex.Z = radius * cosTheta;
				Vertices.Add(vertex);

				// normal

				Normals.Add(new Vector3(0, sign, 0));

				// uv
				Vector2 uv = new Vector2();
				uv.X = (cosTheta * 0.5f) + 0.5f;
				uv.Y = (sinTheta * 0.5f * sign) + 0.5f;
				TextureCoords.Add(uv);

				// increase index

				index++;

			}

			// generate indices

			for (int x = 0; x < RadialSegments; x++)
			{

				int c = centerIndexStart + x;
				int i = centerIndexEnd + x;

				if (top == true)
				{

					// face top

					Indices.Add(new Vector3i( i, i + 1, c));

				}
				else
				{

					// face bottom

					Indices.Add(new Vector3i(i + 1, i, c));

				}

				groupCount += 3;

			}

			// add a group to the geometry. this will ensure multi material support

			Groups.Add(new MaterialGroup(groupStart, groupCount, top == true ? 1 : 2));

			// calculate new start value for groups

			groupStart += groupCount;

		}

	}
}

