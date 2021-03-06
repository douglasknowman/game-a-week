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
    public static Mesh CreateHoleWall(Vector2 wallSize, Vector3 holeSize, Vector2 holePos,float uvMultiplier)
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

        // define uv coordenates.
        for (int i = 0; i < 8; i++)
        {
            uv[i] = uvMultiplier * vertices[i];
        }
        uv[8] = new Vector2(1,0);
        uv[9] =  new Vector2(1,1);
        uv[10] =  new Vector2(0,0);
        uv[11] =  new Vector2(0,1);
        uv[12] =  new Vector2(0,1);
        uv[13] =  new Vector2(0,0);
        uv[14] =  new Vector2(1,1);
        uv[15] =  new Vector2(1,0);
        for (int i = 8; i < 16; i++)
        {
            uv[i]  = 2 * uvMultiplier * uv[i];
        }

        // define triangles
        int[] triangles = new int[48]
        {
            0,1,2, 1,3,2, 1,7,3 ,3,7,5, 5,7,4, 7,6,4, 2,4,6, 0,2,6, 
            8,11,10, 8,9,11, 9,15,11, 11,15,13, 13,15,14, 12,13,14, 8,12,14,  8,10,12
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();
        return mesh;
    }
}
