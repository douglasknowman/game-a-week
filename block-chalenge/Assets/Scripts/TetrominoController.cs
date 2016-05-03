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

public class TetrominoController : MonoBehaviour
{
    // Public variables.
    public Board board;
    //public TetrominoSpawner spawner;

    public float fallSpeed = 2f;

    // Private variables.
    public Transform atualTetromino;
    float timecnt = 0;

    // Unity functions.
    void Update ()
    {
        timecnt += Time.deltaTime;
        if (timecnt > fallSpeed)
        {
            timecnt = 0;
            Debug.Log("Fallig...");
            ClearGrid();
            atualTetromino.Translate(0,-1,0);
            if (!IsPositionValid())
            {
                atualTetromino.Translate(0,1,0);
            }
            UpdateGrid();
        }
    }
      
    // TetrominoController functions.
    public void HorizontalyMove(int direction)
    {
        ClearGrid();
        atualTetromino.Translate(direction,0,0);

        if (!IsPositionValid())
        {
            atualTetromino.Translate(-direction,0,0);
        }
        UpdateGrid();
    }
    bool IsPositionValid()
    {
        
        foreach( Transform child in atualTetromino)
        {
            int x = (int) child.position.x;
            int y = (int) child.position.y;
            if (board.grid[x,y] != null || board.IsOutBoard(x,y))
            {
                return false;
            }
        }
        return true;
    }

    void UpdateGrid()
    {
        foreach( Transform child in atualTetromino)
        {
            int x = (int) child.position.x;
            int y = (int) child.position.y;
            board.grid[x,y] = child;
        }
    }
    void ClearGrid()
    {
        foreach (Transform child in atualTetromino)
        {
            int x = (int) child.position.x;
            int y = (int) child.position.y;
            if (board.grid[x,y] != null)
            {
                board.grid[x,y] = null;
            }
        }
    }
}
