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

public class ScorePanelGUI : MonoBehaviour
{
    // Public variables.
    public Text scoreText;
    public Text paperTakedText;
    public Text lifesText;
    public Text levelText;

    // Private variables.
    // Unity functions.
    
    void Start()
    {
        EventManager.gameEvent += EventHandler;
    }
    void Update ()
    {

    }
      
    // ScorePanelGUI functions.
    void EventHandler(GameEventType type, int val)
    {
        if (type == GameEventType.ScoreUp)
        {
            scoreText.text = val.ToString();
        }
        else if( type == GameEventType.LevelUp)
        {
            levelText.text = val.ToString();
        }
        else if (type == GameEventType.LifesUp)
        {
            lifesText.text = val.ToString();
        }
        else if (type == GameEventType.PapersUp)
        {
            paperTakedText.text = val.ToString();
        }
    }
}
