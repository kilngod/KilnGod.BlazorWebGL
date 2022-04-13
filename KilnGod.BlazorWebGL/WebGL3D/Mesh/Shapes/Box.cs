using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using KilnGod.BlazorWebGL.WebGL3D.MathAddendums;

namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.Shapes
{
    // similar to three.js -> BoxGeometery.js
    public class Box : MeshGenBase
	{

		public float Width { get; set; }
		public float Height { get; set; }
		public float Depth { get; set; }
		public int WidthSegments { get; set; }
		public int HeightSegments { get; set; }
		public int DepthSegments { get; set; }


		public Box(float width = 1, float height = 1, float depth = 1, int widthSegments = 1, int heightSegments = 1, int depthSegments = 1)
		{
			Width = width;
			Height = height;
			Depth = depth;
			WidthSegments = widthSegments;
			HeightSegments = heightSegments;
			DepthSegments = depthSegments;

			ComputeMesh();

		}

		public override bool ComputeMesh()
		{
			base.ComputeMesh();
			

			numberOfVertices = 0;
			groupStart = 0;

			buildPlane(VectorComponent.Z, VectorComponent.Y, VectorComponent.X, -1, -1, Depth, Height, Width, DepthSegments, HeightSegments, 0); // px
			buildPlane(VectorComponent.Z, VectorComponent.Y, VectorComponent.X, 1, -1, Depth, Height, -Width, DepthSegments, HeightSegments, 1); // nx
			buildPlane(VectorComponent.X, VectorComponent.Z, VectorComponent.Y, 1, 1, Width, Depth, Height, WidthSegments, DepthSegments, 2); // py
			buildPlane(VectorComponent.X, VectorComponent.Z, VectorComponent.Y, 1, -1, Width, Depth, -Height, WidthSegments, DepthSegments, 3); // ny
			buildPlane(VectorComponent.X, VectorComponent.Y, VectorComponent.Z, 1, -1, Width, Height, Depth, WidthSegments, HeightSegments, 4); // pz
			buildPlane(VectorComponent.X, VectorComponent.Y, VectorComponent.Z, -1, -1, Width, Height, -Depth, WidthSegments, HeightSegments, 5); // nz

			return true;
		}

		int numberOfVertices;
		int groupStart;
		private void buildPlane(VectorComponent u, VectorComponent v, VectorComponent w, int udir, int vdir, float width, float height, float depth, int gridX, int gridY, int materialIndex)
		{

			float segmentWidth = width / gridX;
			float segmentHeight = height / gridY;

			float widthHalf = width / 2;
			float heightHalf = height / 2;
			float depthHalf = depth / 2;

			int gridX1 = gridX + 1;
			int gridY1 = gridY + 1;

			int vertexCounter = 0;
			int groupCount = 0;



			// generate vertices, normals and uvs

			for (int iy = 0; iy < gridY1; iy++)
			{

				float y = iy * segmentHeight - heightHalf;

				for (int ix = 0; ix < gridX1; ix++)
				{

					float x = ix * segmentWidth - widthHalf;

					// set values to correct vector component
					Vector3 vector = new Vector3();
					vector.SetComponent(u, x * udir);

					vector.SetComponent(v, y * vdir);

					vector.SetComponent(w, depthHalf);


					// now apply vector to vertex buffer

					Vertices.Add(vector);

					// set values to correct vector component
					Vector3 normal = new Vector3();
					normal.SetComponent(u, 0);

					normal.SetComponent(v, 0);

					normal.SetComponent(w, depth > 0 ? 1 : -1);

					// now apply vector to normal buffer

					Normals.Add(normal);

					// uvs

					TextureCoords.Add(new Vector2(ix / gridX, 1 - (iy / gridY)));

					// counters

					vertexCounter += 1;

				}

			}

			// indices

			// 1. you need three indices to draw a single face
			// 2. a single segment consists of two faces
			// 3. so we need to generate six (2*3) indices per segment

			for (int iy = 0; iy < gridY; iy++)
			{

				for (int ix = 0; ix < gridX; ix++)
				{

					int a = numberOfVertices + ix + gridX1 * iy;
					int b = numberOfVertices + ix + gridX1 * (iy + 1);
					int c = numberOfVertices + (ix + 1) + gridX1 * (iy + 1);
					int d = numberOfVertices + (ix + 1) + gridX1 * iy;

					// faces

					Indices.Add(new Vector3i(a, b, d));
					Indices.Add(new Vector3i(b, c, d));

					// increase counter

					groupCount += 6;

				}

			}

			// add a group to the geometry. this will ensure multi material support

			Groups.Add(new MaterialGroup(){ Start=  groupStart, Count= groupCount, MaterialIndex= materialIndex});

			// calculate new start value for groups

			groupStart += groupCount;

			// update total number of vertices

			numberOfVertices += vertexCounter;

		}

	}


}
