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
    // Private variables.
    Transform atualTetromino = null;
    Transform nextTetromino = null;
    // Unity functions.
    void Start()
    {
        
    }
    void Update ()
    {
    }
      
    // TetrominoSpawner functions.
    public Transform SpawnNext()
    {
        int index = Random.Range(0,tetrominos.Length);

        atualTetromino = nextTetromino;
        if (atualTetromino == null)
        {
            atualTetromino = (Instantiate(tetrominos[index].tetromino,posToSpawn,Quaternion.identity) as GameObject).transform;
        }
        atualTetromino.gameObject.SetActive(true);
        atualTetrominoIsLimitedRot = tetrominos[index].limitedRotation;
        nextTetromino = (Instantiate(tetrominos[index].tetromino,posToSpawn,Quaternion.identity) as GameObject).transform;
        nextTetromino.gameObject.SetActive(false);
        return atualTetromino;
    }
    

}
