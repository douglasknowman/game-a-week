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
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaveScoreDialog : MonoBehaviour
{
    // Public variables.
    public InputField inputField; 
    public HighScoreBoard highScoreBoard;
    // Private variables.
    GameController gameCtl;
    // Unity functions.
    void Start()
    {
        gameObject.SetActive(false);
        gameCtl = GameObject.Find("BoardController").GetComponent<GameController>();
        EventManager.gameEvent += EventHandler;
    }
      
    // SaveScoreDialog functions.
    public void OnSave()
    {
        highScoreBoard.SaveHighScoreBoard(inputField.text,gameCtl.GetAllScore().score);
        SceneManager.LoadScene(1);

    }
    public void OnCancel()
    {
        SceneManager.LoadScene(1);
    }

    void EventHandler(GameEventType type)
    {
        if (type == GameEventType.GameOver)
        {
            gameObject.SetActive(true);
        }
    }
}
