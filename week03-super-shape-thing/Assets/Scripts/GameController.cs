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
    public float maxHealthPoints = 100;
    public float healthDecreaseBySecond = 1;
    public GameObject gameOverScreen;

    public float HealthPoints 
    {
        get {return healthPoints;}
        set {
            if (value < 0)
            {
                GameOver();
            }else if (value > maxHealthPoints)
            {
                healthPoints = maxHealthPoints;
            }
            else 
            {
                healthPoints = value;
            }
        }
    }
    public int Points
    {
        get{return points;}
        set{points = value;}
    }
    // Private variables.
    private float healthPoints;
    private int points;
    // Unity functions.
    void Start()
    {
        gameOverScreen.SetActive(false);
        healthPoints = maxHealthPoints;
    }

    void Update ()
    {
        HealthPoints -= Time.deltaTime * healthDecreaseBySecond;
    }
      
    // GameController functions.
    void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
