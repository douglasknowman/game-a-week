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
        if (x > -1 && x  < width && y > -1)
        {
            return false;
        }
        return true;
    }

    public void CheckFullRows()
    {
        int cleanedRows =0;
        for( int y=0; y<height; y++)
        {
            if (IsRowComplete(y))
            {
                DeleteRow(y);
                FallRowsAbove(y);
                y -= 1;
                cleanedRows += 1;
            }
        }
        // Send a Event int the way that more lines cleaned the event is different.
        switch (cleanedRows)
        {
        case 1:
            EventManager.gameEvent(GameEventType.OneLineClean);
            break;
        case 2:
            EventManager.gameEvent(GameEventType.TwoLineClean);
            break;
        case 3:
            EventManager.gameEvent(GameEventType.ThreeLineClean);
            break;
        case 4:
            EventManager.gameEvent(GameEventType.FourLineClean);
            break;
        default:
            break;
        }
    }

    bool IsRowComplete(int y)
    {
        for( int x=0; x<width; x++)
        {
            if (grid[x,y] == null) return false;
        }
        return true;
    }

    void DeleteRow (int y)
    {
        for( int x=0; x<width; x++)
        {
            //TODO good destroy system.
            if (grid[x,y] != null)
            {
                Destroy(grid[x,y].gameObject);
            }
        }
    }

    void FallRow (int y)
    {
        int yup = 0;
        for( int x=0; x<width; x++)
        {
            yup = y+1 == height ? y : y+1;

            grid[x,y] = grid[x,yup];
            grid[x,yup] = null;
            if (grid[x,y] != null)
            {
                grid[x,y].position = new Vector3(x,y,0);
            }
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
