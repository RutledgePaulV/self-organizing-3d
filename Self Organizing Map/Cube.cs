using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK;

class Cube
{
    public Vector3d center;
    private Vector3d[] vertices;
    private Vector3d[] normals;
    private OpenTK.Graphics.Color4 color;
  
    public Cube(Vector3d center, double size, Color c)
    {
        this.center = center;
        vertices = new Vector3d[24];
        normals = new Vector3d[24];
        color = c;
        double s = size * 0.5;

        //front face - done
        vertices[0] = new Vector3d(-s + center.X, s + center.Y, s + center.Z);
        vertices[1] = new Vector3d(-s + center.X, -s + center.Y, s + center.Z);
        vertices[2] = new Vector3d(s + center.X, -s + center.Y, s + center.Z);
        vertices[3] = new Vector3d(s + center.X, s + center.Y, s + center.Z);
        normals[0] = new Vector3d(0, 0, 1);
        normals[1] = new Vector3d(0, 0, 1);
        normals[2] = new Vector3d(0, 0, 1);
        normals[3] = new Vector3d(0, 0, 1);

        //left face - done
        vertices[4] = new Vector3d(-s + center.X, s + center.Y, -s + center.Z);
        vertices[5] = new Vector3d(-s + center.X, -s + center.Y, -s + center.Z);
        vertices[6] = new Vector3d(-s + center.X, -s + center.Y, s + center.Z);
        vertices[7] = new Vector3d(-s + center.X, s + center.Y, s + center.Z);
        normals[4] = new Vector3d(-1, 0, 0);
        normals[5] = new Vector3d(-1, 0, 0);
        normals[6] = new Vector3d(-1, 0, 0);
        normals[7] = new Vector3d(-1, 0, 0);

        //right face - done
        vertices[8] = new Vector3d(s + center.X, s + center.Y, s + center.Z);
        vertices[9] = new Vector3d(s + center.X, -s + center.Y, s + center.Z);
        vertices[10] = new Vector3d(s + center.X, -s + center.Y, -s + center.Z);
        vertices[11] = new Vector3d(s + center.X, s + center.Y, -s + center.Z);
        normals[8] = new Vector3d(1, 0, 0);
        normals[9] = new Vector3d(1, 0, 0);
        normals[10] = new Vector3d(1, 0, 0);
        normals[11] = new Vector3d(1, 0, 0);

        //bottom face - done
        vertices[12] = new Vector3d(-s + center.X, -s + center.Y, s + center.Z);
        vertices[13] = new Vector3d(-s + center.X, -s + center.Y, -s + center.Z);
        vertices[14] = new Vector3d(s + center.X, -s + center.Y, -s + center.Z);
        vertices[15] = new Vector3d(s + center.X, -s + center.Y, s + center.Z);
        normals[12] = new Vector3d(0, -1, 0);
        normals[13] = new Vector3d(0, -1, 0);
        normals[14] = new Vector3d(0, -1, 0);
        normals[15] = new Vector3d(0, -1, 0);

        //top face - done
        vertices[16] = new Vector3d(-s + center.X, s + center.Y, -s + center.Z);
        vertices[17] = new Vector3d(-s + center.X, s + center.Y, s + center.Z);
        vertices[18] = new Vector3d(s + center.X, s + center.Y, s + center.Z);
        vertices[19] = new Vector3d(s + center.X, s + center.Y, -s + center.Z);
        normals[16] = new Vector3d(0, 1, 0);
        normals[17] = new Vector3d(0, 1, 0);
        normals[18] = new Vector3d(0, 1, 0);
        normals[19] = new Vector3d(0, 1, 0);

        //back face
        vertices[20] = new Vector3d(s + center.X, s + center.Y, -s + center.Z);
        vertices[21] = new Vector3d(s + center.X, -s + center.Y, -s + center.Z);
        vertices[22] = new Vector3d(-s + center.X, -s + center.Y, -s + center.Z);
        vertices[23] = new Vector3d(-s + center.X, s + center.Y, -s + center.Z);
        normals[20] = new Vector3d(0, 0, -1);
        normals[21] = new Vector3d(0, 0, -1);
        normals[22] = new Vector3d(0, 0, -1);
        normals[23] = new Vector3d(0, 0, -1);
    }

    public void Draw()
    {
         GL.Color4(color);
        for (int i = 0; i < vertices.Length; i++)
        {
            GL.Normal3(normals[i]);
            GL.Vertex3(vertices[i]);
        }
    }
}
