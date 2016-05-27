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

public class HUDController : MonoBehaviour
{
    // Public variables.
    public float healthBarSmooth = 3;
    public Text scoreText;
    public RectTransform healthBar;

    // Private variables.
    private GameController gc;
    // Unity functions.
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update ()
    {
        scoreText.text = gc.Points.ToString();
        float health = gc.HealthPoints / gc.maxHealthPoints;
        healthBar.localScale = new Vector3(Mathf.Lerp(healthBar.localScale.x,health,healthBarSmooth * Time.deltaTime),1,1);
    }
      
    // HUDController functions.
    public void OnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
