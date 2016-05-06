/*****************************************************\ *
*  Copyright (C) 2016, Douglas Knowman 
*  douglasknowman@gmail.com
*
*  Distributed under the terms of GNU GPL v3 license.
*  Always KISS.
*
\*****************************************************/

using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Tetromino
{
    public GameObject tetromino;
    public bool limitedRotation;
}

public class TetrominoSpawner : MonoBehaviour
{
    // Public variables.
    public Tetromino[] tetrominos;
    public Vector3 posToSpawn = new Vector3(5,10,0);
    public bool atualTetrominoIsLimitedRot = false;
    public bool nextTetrominoIsLimitedRot = false;
    public Transform nextTetromino;
    // Private variables.
    Transform atualTetromino = null;
    // Unity functions.

    // TetrominoSpawner functions.
    public Transform SpawnNext()
    {
        //Random selected tetromino;
        int index = 0;
        atualTetromino = nextTetromino;
        //update if the tetromino can rotate all 360 degress or not.
        atualTetrominoIsLimitedRot = nextTetrominoIsLimitedRot;

        if (atualTetromino == null)
        {
            index = Random.Range(0,tetrominos.Length);
            atualTetromino = (Instantiate(tetrominos[index].tetromino,posToSpawn,Quaternion.identity) as GameObject).transform;
            atualTetrominoIsLimitedRot = tetrominos[index].limitedRotation;
        }
        atualTetromino.position = posToSpawn;

        index = Random.Range(0,tetrominos.Length);
        atualTetromino.gameObject.SetActive(true);

        nextTetromino = (Instantiate(tetrominos[index].tetromino,posToSpawn,Quaternion.identity) as GameObject).transform;
        nextTetrominoIsLimitedRot = tetrominos[index].limitedRotation;
        nextTetromino.gameObject.SetActive(false);
        //Send Event
        EventManager.gameEvent(GameEventType.SpawnNewPiece);
        return atualTetromino;
    }
    

}
