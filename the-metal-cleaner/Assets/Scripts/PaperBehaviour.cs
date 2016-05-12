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

public class PaperBehaviour : MonoBehaviour
{
    // Public variables.
    // Private variables.
    // Unity functions.
    void Update ()
    {
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            EventManager.gameEvent(GameEventType.PaperOnGround,1);
        }
    }
      
    // PaperBehaviour functions.
}
