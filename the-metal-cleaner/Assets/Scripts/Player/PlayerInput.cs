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

public class PlayerInput : MonoBehaviour
{
    // Public variables.
    // Private variables.
    CharacterMovement charMove;
    // Unity functions.
    void Start()
    {
        charMove = GetComponent<CharacterMovement>();
    }
    void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            charMove.jump = true;
        }
        charMove.moveDir = h;

    }
      
    // PlayerInput functions.
}
