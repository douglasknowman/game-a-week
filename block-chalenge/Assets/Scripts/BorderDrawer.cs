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

public class BorderDrawer : MonoBehaviour
{
    // Public variables.
    public float posBehind = -2; 
    public GameObject top;
    public GameObject bottom;
    public GameObject right;
    public GameObject left;
    public GameObject topLeft;
    public GameObject topRight;
    public GameObject bottomRight;
    public GameObject bottomLeft;
    public GameObject center;
    // Private variables.
    Board board;
    int width;
    int height;
    // Unity functions.
    void Start()
    {
        board = GetComponent<Board>();
        width = board.width;
        height = board.height;
        DrawBorders();
    }

    // BorderDrawer functions.
    void DrawBorders()
    {
        int ypos = 0;
        int xpos = 0;
        for( int y=0; y<height+2; y++)
        {
            for( int x=0; x<width+2; x++)
            {
                xpos = x-1;
                ypos = y-1;
                GameObject obj;
                if (xpos < 0 && ypos < 0)
                {
                    obj = Instantiate(bottomLeft,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                else if (xpos<0 && ypos>=0 && ypos < height)
                {
                    obj = Instantiate(left,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                else if (xpos>=0 && ypos<0 && xpos< width)
                {
                    obj = Instantiate(bottom,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                else if (xpos==width && ypos==height)
                {
                    obj = Instantiate(topRight,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                else if (xpos==width && ypos < 0)
                {
                    obj = Instantiate(bottomRight,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                else if (xpos<0 && ypos==height)
                {
                    obj = Instantiate(topLeft,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                else if (xpos>=0 && ypos==height)
                {
                    obj = Instantiate(top,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                else if (xpos==width && ypos >=0)
                {
                    obj = Instantiate(right,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                else 
                {
                    obj = Instantiate(center,new Vector3(xpos,ypos,posBehind),Quaternion.identity) as GameObject;
                }
                obj.transform.SetParent(transform);
            }
        }
    }
}
