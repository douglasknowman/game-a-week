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
using UnityEngine.UI;

public class PauseGameController : MonoBehaviour
{
    // Public variables.
    public TetrominoController tetrominoCtl;
    // Private variables.
    Text pauseButtonText;
    // Unity functions.
    void Start()
    {
        pauseButtonText = gameObject.GetComponentInChildren<Text>();
    }
    // PauseGameController functions.
    public void OnPause()
    {
        tetrominoCtl.TogglePause();
        if (pauseButtonText.text == "Pause")
        {
            pauseButtonText.text = "Continue";
        }
        else pauseButtonText.text = "Pause";
    }
}
