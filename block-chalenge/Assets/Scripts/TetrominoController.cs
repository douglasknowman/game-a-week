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
using System.Collections.Generic;

public class TetrominoController : MonoBehaviour
{
    // Public variables.
    public Board board;
    public TetrominoSpawner spawner;

    public float normalFallSpeed = 2f;
    public float fastFallSpeed = 0.2f;

    // Private variables.
    Transform atualTetromino;
    List<Transform> parents = new List<Transform>();
    float timecnt = 0;
    float fallSpeed = 0;
    public bool fastFall = false;

    // Unity functions.
    void Start()
    {
        NextTetromino();
    }
    void Update ()
    {
        if (fastFall)
        {
            fallSpeed = fastFallSpeed;
        }
        else fallSpeed = normalFallSpeed;
        timecnt += Time.deltaTime;
        if (timecnt > fallSpeed)
        {
            timecnt = 0;
            atualTetromino.Translate(0,-1,0,Space.World);
            if (!IsPositionValid())
            {
                atualTetromino.Translate(0,1,0,Space.World);
                UpdateGrid();

                // Send PieceAcent Event.
                EventManager.gameEvent(GameEventType.PieceAccent);

                board.CheckFullRows();
                NextTetromino();
                ClearParents();
            }
        }
    }
      
    // TetrominoController functions.
    void ClearParents()
    {
        // This function will clear empty game objects in the game.
        foreach (Transform  parent in parents.ToArray())
        {
            if (parent.childCount == 0)
            {
                parents.Remove(parent);
                Destroy(parent.gameObject);
            }
        }
    }

    void NextTetromino()
    {
        atualTetromino = spawner.SpawnNext();
        parents.Add(atualTetromino);
    }

    public void HorizontalyMove(int direction)
    {
        atualTetromino.Translate(direction,0,0,Space.World);

        if (!IsPositionValid())
        {
            atualTetromino.Translate(-direction,0,0,Space.World);
        }
        else 
            EventManager.gameEvent(GameEventType.PieceMove);
    }
    public void Rotate()
    {
        Debug.Log(spawner.atualTetrominoIsLimitedRot);
        float rotAngle = -90;
        //Limiting the rotation for some tetrominos. when they reach the limit then return.
        if (spawner.atualTetrominoIsLimitedRot && (atualTetromino.eulerAngles.z-0.2f < 270 && atualTetromino.eulerAngles.z > 1)  )
        {
            rotAngle = 90;
        }
        atualTetromino.Rotate(new Vector3(0,0,rotAngle));

        if (!IsPositionValid())
        {
            atualTetromino.Rotate(new Vector3(0,0,-rotAngle));
        }
    }

    bool IsPositionValid()
    {
        
        foreach( Transform child in atualTetromino)
        {
            int x = Mathf.RoundToInt(child.position.x);
            int y = Mathf.RoundToInt(child.position.y);

            if (board.IsOutBoard(x,y)) return false;
            else if (board.grid[x,y] != null )
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
            int x = Mathf.RoundToInt(child.position.x);
            int y = Mathf.RoundToInt(child.position.y);
            board.grid[x,y] = child;
        }
    }
}
