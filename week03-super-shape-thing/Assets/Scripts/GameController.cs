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
    public float HealthPoints 
    {
        get {return healthPoints;}
        set {
            healthPoints = value < 0 ? 0 : value;
            healthPoints = value > maxHealthPoints ? maxHealthPoints : value;
            if (value < 0) GameOver();
        }
    }
    // Private variables.
    private float healthPoints;
    // Unity functions.
    void Start()
    {
        healthPoints = maxHealthPoints;
    }

    void Update ()
    {
        Debug.Log(healthPoints);
    }
      
    // GameController functions.
    void GameOver()
    {
        
    }
}
