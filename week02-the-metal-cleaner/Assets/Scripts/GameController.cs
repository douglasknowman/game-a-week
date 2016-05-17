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

public class GameController : MonoBehaviour
{
    // Public variables.
    public int basePoints = 100;
    public int maxLifes = 5;
    public int paperToNextLevel = 15;
    public int Score {get{return score;}}
    // Private variables.
    int atualLevel = 1;
    int score = 0;
    int lifes;
    int papersTaked = 0;
    bool paused = false;
    // Unity functions.
    void Awake()
    {
        EventManager.gameEvent += EventHandler;
        lifes = maxLifes;

    }
    void Start()
    {
        EventManager.gameEvent(GameEventType.LevelUp,atualLevel);
        EventManager.gameEvent(GameEventType.PapersUp,papersTaked);
        EventManager.gameEvent(GameEventType.LifesUp,lifes);
        EventManager.gameEvent(GameEventType.ScoreUp,score);
    }
    void Update ()
    {
    }
      
    // GameController functions.
    public void TogglePause()
    {
        // Pause the game.
        paused = !paused;
        Time.timeScale = 1f-Time.timeScale;
    }

    void EventHandler(GameEventType type, int val)
    {
        if (type == GameEventType.PapersTaked)
        {
            // calculating the points earn by the player.
            score += (val * val ) * basePoints;
            papersTaked += val;
            EventManager.gameEvent(GameEventType.ScoreUp,score);
            EventManager.gameEvent(GameEventType.PapersUp,papersTaked);
        }
        else if (type == GameEventType.PaperOnGround)
        {
            lifes--;
            EventManager.gameEvent(GameEventType.LifesUp,lifes);

            if (lifes == 0)
            {
                GameOver();
            }
        }

        // level up
        if (atualLevel < ((int)papersTaked/paperToNextLevel) + 1)
        {
            atualLevel++;
            EventManager.gameEvent(GameEventType.LevelUp,atualLevel);
        }
    }


    //GameOver
    void GameOver()
    {
        EventManager.gameEvent(GameEventType.GameOver,score);
        TogglePause();
    }
}
