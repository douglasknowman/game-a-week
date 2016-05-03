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

public class TetrominoSpawner : MonoBehaviour
{
    // Public variables.
    public GameObject[] tetrominos;
    public Vector3 posToSpawn = new Vector3(5,10,0);
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
            atualTetromino = (Instantiate(tetrominos[index],posToSpawn,Quaternion.identity) as GameObject).transform;
        }
        atualTetromino.gameObject.SetActive(true);
        nextTetromino = (Instantiate(tetrominos[index],posToSpawn,Quaternion.identity) as GameObject).transform;
        nextTetromino.gameObject.SetActive(false);
        return atualTetromino;
    }
    

}
