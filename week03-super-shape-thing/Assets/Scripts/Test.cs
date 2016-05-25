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

public class Test : MonoBehaviour
{
    // Public variables.
    public float wallWidth = 10;
    public float wallHeight = 10;
    public float holeWidth = 5;
    public float holeHeight = 5;
    public float holeDepth = 10;
    public Vector2 holePos;
    // Private variables.
    //
    // Unity functions.
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
    }
    void Update ()
    {
        Vector2 ws = new Vector2(wallWidth,wallHeight);
        Vector3 holeSize  = new Vector3(holeWidth,holeHeight,holeDepth);
        gameObject.GetComponent<MeshFilter>().mesh = GeometryUtils.CreateHoleWall(ws,holeSize,holePos);
    }
      
    // Test functions.
}
