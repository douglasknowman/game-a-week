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

public class Board : MonoBehaviour
{
    // Public variables.
    public int width = 14;
    public int height = 20;

    public Transform[,] grid;
    // Private variables.

    // Unity functions.
    void Awake()
    {
        grid = new Transform[width,height];
        for( int y=0; y<height; y++)
        {
            for( int x=0; x<width; x++)
            {
                grid[x,y] = null;
            }
        }
    }
      
    // Board functions.
    public bool IsOutBoard(int x,int y)
    {
        if (x > 0 || x  < width || y > 0)
        {
            return false;
        }
        return true;
    }

    void DeleteRow (int y)
    {
        for( int x=0; x<width; x++)
        {
            //TODO good destroy system.
            Destroy(grid[x,y].gameObject);
        }
    }

    void FallRow (int y)
    {
        for( int x=0; x<width; x++)
        {
            grid[x,y] = grid[x,y+1];
            DeleteRow(y+1);
        }
    }

    void FallRowsAbove(int y)
    {
        for( int i=y; i<height; i++)
        {
            FallRow(i);
        }
    }
}
