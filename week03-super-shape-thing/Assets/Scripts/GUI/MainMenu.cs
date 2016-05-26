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
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Public variables.
    // Private variables.
    // Unity functions.
    void Update ()
    {
    }
      
    // MainMenu functions.
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }
}
