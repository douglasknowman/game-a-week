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
    public float timeBetweenMovement = 0.1f;
    // Private variables.
    TetrominoController tetrominoCtl;
    float timecnt = 0;
    // Unity functions.
    void Start()
    {
        tetrominoCtl = GetComponent<TetrominoController>();
    }
    void Update ()
    {
        timecnt += timecnt > 20 ? 0 : Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && timecnt > timeBetweenMovement)
        {
            timecnt = 0;
            tetrominoCtl.HorizontalyMove(-1);
        }

        if (Input.GetKey(KeyCode.D) && timecnt > timeBetweenMovement)
        {
            timecnt = 0;
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
