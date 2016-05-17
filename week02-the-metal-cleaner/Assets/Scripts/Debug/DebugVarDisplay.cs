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

public class DebugVarDisplay : MonoBehaviour
{
    // Public variables.
    // Private variables.
    int level = 1;
    int score = 0;
    int papersTaked = 0;
    int lifes = 5;

    // Unity functions.
    void Start()
    {
        EventManager.gameEvent += EventHandler;
    }
    void Update ()
    {
    }
    void OnGUI()
    {
        GUI.Label(new Rect(20,10,300,50),"score: " + score.ToString());
        GUI.Label(new Rect(20,40,300,50),"level: " + level.ToString());
        GUI.Label(new Rect(20,70,300,50),"papersTaked: " + papersTaked.ToString());
        GUI.Label(new Rect(20,100,300,50),"lifes: " + lifes.ToString());
    }
      
    // DebugVarDisplay functions.
    void EventHandler(GameEventType type, int val)
    {
        if (type == GameEventType.LevelUp)
        {
            level = val;
        }
        else if (type == GameEventType.ScoreUp)
        {
            score = val;
        }
        else if (type == GameEventType.PapersUp)
        {
            papersTaked = val;
        }
        else if (type == GameEventType.LifesUp)
        {
            lifes = val;
        }
    }
}
