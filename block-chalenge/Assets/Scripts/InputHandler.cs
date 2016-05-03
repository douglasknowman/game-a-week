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

public class InputHandler : MonoBehaviour
{
    // Public variables.
    // Private variables.
    TetrominoController tetrominoCtl;
    // Unity functions.
    void Start()
    {
        tetrominoCtl = GetComponent<TetrominoController>();
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tetrominoCtl.HorizontalyMove(-1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            tetrominoCtl.HorizontalyMove(1);
        }
        tetrominoCtl.fastFall = Input.GetKey(KeyCode.S);

        if (Input.GetKeyDown(KeyCode.W))
        {
            tetrominoCtl.Rotate();
        }
    }
      
    // InputHandler functions.
}
