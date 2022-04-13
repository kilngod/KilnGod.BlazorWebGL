using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Numerics;

namespace KilnGod.BlazorWebGL.WebGL3D.Mesh.STL
{
    public class STLReader
    {
        public string path; // file path
        private enum FileType { NONE, BINARY, ASCII }; // stl file type enumeration
        private bool processError;
        public STLReader(string filePath = "")
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            path = filePath;
            processError = false;
        }


        public bool Get_Process_Error()
        {
            return processError;
        }

        public TriangleMesh[]? ReadFile()
        {
            TriangleMesh[]? meshList;

            FileType stlFileType = GetFileType(path);

            if (stlFileType == FileType.ASCII)
            {
                meshList = ReadASCIIFile(path);
            }
            else if (stlFileType == FileType.BINARY)
            {
                meshList = ReadBinaryFile(path);
            }
            else
            {
                meshList = null;
            }

            return meshList;
        }


        private FileType GetFileType(string filePath)
        {
            FileType stlFileType = FileType.NONE;

            /* check path is exist */
            if (File.Exists(filePath))
            {
                int lineCount = 0;
                lineCount = File.ReadLines(filePath).Count(); // number of lines in the file

                string firstLine = File.ReadLines(filePath).First();

                string endLines = File.ReadLines(filePath).Skip(lineCount - 1).Take(1).First() +
                                  File.ReadLines(filePath).Skip(lineCount - 2).Take(1).First();

                /* check the file is ascii or not */
                if ((firstLine.IndexOf("solid") != -1) &
                    (endLines.IndexOf("endsolid") != -1))
                {
                    stlFileType = FileType.ASCII;
                }
                else
                {
                    stlFileType = FileType.BINARY;
                }

            }
            else
            {
                stlFileType = FileType.NONE;
            }


            return stlFileType;
        }

        private TriangleMesh[] ReadBinaryFile(string filePath)
        {
            List<TriangleMesh> meshList = new List<TriangleMesh>();
            int numOfMesh = 0;
            int i = 0;
            int byteIndex = 0;
            byte[] fileBytes = File.ReadAllBytes(filePath);

            byte[] temp = new byte[4];

            /* 80 bytes title + 4 byte num of triangles + 50 bytes (1 of triangular mesh)  */
            if (fileBytes.Length > 120)
            {

                temp[0] = fileBytes[80];
                temp[1] = fileBytes[81];
                temp[2] = fileBytes[82];
                temp[3] = fileBytes[83];

                numOfMesh = System.BitConverter.ToInt32(temp, 0);

                byteIndex = 84;

                for (i = 0; i < numOfMesh; i++)
                {
                    TriangleMesh newMesh = new TriangleMesh();

                    /* this try-catch block will be reviewed */
                    try
                    {
                        /* face normal */
                        newMesh.Normal1.X = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.Normal1.Y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.Normal1.Z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;

                        /* normals of vertex 2 and 3 equals to vertex 1's normals */
                        newMesh.Normal2 = newMesh.Normal1;
                        newMesh.Normal3 = newMesh.Normal1;

                        /* vertex 1 */
                        newMesh.Vertex1.X = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.Vertex1.Y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.Vertex1.Z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;

                        /* vertex 2 */
                        newMesh.Vertex2.X = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.Vertex2.Y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.Vertex2.Z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;

                        /* vertex 3 */
                        newMesh.Vertex3.X = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.Vertex3.Y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.Vertex3.Z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;

                        byteIndex += 2; // Attribute byte count
                    }
                    catch
                    {
                        processError = true;
                        break;
                    }

                    meshList.Add(newMesh);

                }

            }
            else
            {
                // nitentionally left blank
            }

            return meshList.ToArray();
        }



        private TriangleMesh[] ReadASCIIFile(string filePath)
        {
            List<TriangleMesh> meshList = new List<TriangleMesh>();

            StreamReader txtReader = new StreamReader(filePath);

            string lineString;

            while (!txtReader.EndOfStream)
            {
                lineString = txtReader.ReadLine().Trim(); /* delete whitespace in front and tail of the string */
                string[] lineData = lineString.Split(' ');

                if (lineData[0] == "solid")
                {
                    while (lineData[0] != "endsolid")
                    {
                        lineString = txtReader.ReadLine().Trim(); // facetnormal
                        lineData = lineString.Split(' ');

                        if (lineData[0] == "endsolid") // check if we reach at the end of file
                        {
                            break;
                        }

                        TriangleMesh newMesh = new TriangleMesh(); // define new mesh object

                        /* this try-catch block will be reviewed */
                        try
                        {
                            // FaceNormal 
                            newMesh.Normal1.X = float.Parse(lineData[2]);
                            newMesh.Normal1.Y = float.Parse(lineData[3]);
                            newMesh.Normal1.Z = float.Parse(lineData[4]);

                            /* normals of vertex 2 and 3 equals to vertex 1's normals */
                            newMesh.Normal2 = newMesh.Normal1;
                            newMesh.Normal3 = newMesh.Normal1;

                            //----------------------------------------------------------------------
                            lineString = txtReader.ReadLine(); // Just skip the OuterLoop line
                            //----------------------------------------------------------------------

                            // Vertex1
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.Vertex1.X = float.Parse(lineData[1]); // x1
                            newMesh.Vertex1.Y = float.Parse(lineData[2]); // y1
                            newMesh.Vertex1.Z = float.Parse(lineData[3]); // z1

                            // Vertex2
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.Vertex2.X = float.Parse(lineData[1]); // x2
                            newMesh.Vertex2.Y = float.Parse(lineData[2]); // y2
                            newMesh.Vertex2.Z = float.Parse(lineData[3]); // z2

                            // Vertex3
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.Vertex3.X = float.Parse(lineData[1]); // x3
                            newMesh.Vertex3.Y = float.Parse(lineData[2]); // y3
                            newMesh.Vertex3.Z = float.Parse(lineData[3]); // z3
                        }
                        catch
                        {
                            processError = true;
                            break;
                        }

                        //----------------------------------------------------------------------
                        lineString = txtReader.ReadLine(); // Just skip the endloop
                        //----------------------------------------------------------------------
                        lineString = txtReader.ReadLine(); // Just skip the endfacet

                        meshList.Add(newMesh); // add mesh to meshList

                    } // while linedata[0]
                } // if solid
            } // while !endofstream

            return meshList.ToArray();
        }

       

    }
}
