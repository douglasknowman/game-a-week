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

public class TetrominoColorChanger : MonoBehaviour
{
    // Public variables.
    public Color tetrominoColor = Color.white;
    // Private variables.
    // Unity functions.
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().color = tetrominoColor;
        }
    }
    // TetrominoColorChanger functions.
}
