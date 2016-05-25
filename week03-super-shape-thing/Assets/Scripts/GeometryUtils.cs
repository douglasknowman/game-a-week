/*****************************************************\
*
*  Copyright (C) 2016, Douglas Knowman 
*  douglasknowman@gmail.com
*
*  Distributed under the terms of GNU GPL v3 license.
*  Always KISS.
*
\*****************************************************/

using UnityEngine;
using System.Collections;

public static class GeometryUtils 
{
    public static Mesh CreateHoleWall(Vector2 wallSize, Vector3 holeSize, Vector2 holePos)
    {
        // declare vertices and uv vaiables.
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[16];
        Vector2[] uv = new Vector2[16];
        
        // define vertices position;
        // define plane wall position.
        vertices[0] = new Vector3(wallSize.x,wallSize.y,0);
        vertices[1] = new Vector3(0,wallSize.y,0);
        vertices[6] = new Vector3(wallSize.x,0,0);
        vertices[7] = new Vector3(0,0,0);
        // define hole position.
        vertices[2] = new Vector3(holePos.x + holeSize.x/2, holePos.y + holeSize.y/2);
        vertices[3] = new Vector3(holePos.x - holeSize.x/2, holePos.y + holeSize.y/2);
        vertices[4] = new Vector3(holePos.x + holeSize.x/2, holePos.y - holeSize.y/2);
        vertices[5] = new Vector3(holePos.x - holeSize.x/2, holePos.y - holeSize.y/2);
        // define inside hole deep.
        // same pos.
        vertices[8] = vertices[2];
        vertices[9] = vertices[3];
        vertices[14] = vertices[4];
        vertices[15] = vertices[5];
        
        vertices[10] = vertices[2] + Vector3.forward * holeSize.z;
        vertices[11] = vertices[3] + Vector3.forward * holeSize.z;
        vertices[12] = vertices[4] + Vector3.forward * holeSize.z;
        vertices[13] = vertices[5] + Vector3.forward * holeSize.z;

        // define triangles
        int[] triangles = new int[48]
        {
            0,1,2, 1,3,2, 1,7,3 ,3,7,5, 5,7,4, 7,6,4, 2,4,6, 0,2,6, 
            8,10,11, 9,8,11, 9,11,15, 11,13,15, 13,14,15, 12,13,14, 8,12,14,  8,10,12
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();
        return mesh;
    }
}
