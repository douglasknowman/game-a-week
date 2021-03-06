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

public class GUIMenuCalls : MonoBehaviour
{
    // Public variables.
    // Private variables.
    // Unity functions.
    // GUIMenuCalls functions.
    void ClearEventManager()
    {
        EventManager.gameEvent = null;
        EventManager.guiUpdate = null;
        EventManager.levelUpEvent = null;
    }
    public void OnLoadMainMenu()
    {
        SceneManager.LoadScene(0);
        ClearEventManager();

    }

    public void OnClearHighScoreBoard()
    {
        GameObject.Find("HighScorePanel").GetComponent<HighScoreBoard>().DeleteAllRecords();
    }

    public void OnLoadHighScoreBoard()
    {
        SceneManager.LoadScene(1);
        ClearEventManager();
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(2);
        ClearEventManager();
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void CangeVolume(float val)
    {
        AudioListener.volume = val;
    }
}
