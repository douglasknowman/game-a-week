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
using UnityEngine.SceneManagement;

public class GameOverPanelGUI : MonoBehaviour
{
    // Public variables.
    public Text lScore;
    public Text aScore;
    public GameObject newRecord;
    // Private variables.
    int atualScore;
    // Unity functions.
    void Start()
    {
        EventManager.gameEvent += EventHandler;
        gameObject.SetActive(false);
    }
    void Update ()
    {
    }
      
    // GameOverPanelGUI functions.
    void EventHandler(GameEventType type, int val)
    {
        Debug.Log("Game Over");
        if (type == GameEventType.GameOver)
        {
            gameObject.SetActive(true);
            atualScore = val;
            SaveScore();
        }
    }
    void SaveScore()
    {
        int lastScore = 0;
        if (PlayerPrefs.HasKey("_player_score"))
        {
            lastScore = PlayerPrefs.GetInt("_player_score");
        }
        if (atualScore > lastScore)
        {
            newRecord.SetActive(true);
            PlayerPrefs.SetInt("_player_score",atualScore);
            PlayerPrefs.Save();
        }
        lScore.text = lastScore.ToString();
        aScore.text = atualScore.ToString();
    }
    public void OnRestart()
    {
        EventManager.ClearAll();
        SceneManager.LoadScene(1);
    }
}
