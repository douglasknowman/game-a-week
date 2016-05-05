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

public class HUDController : MonoBehaviour
{
    // Public variables.
    public GameController gameCtl;
    public Text score;
    public Text oneLine;
    public Text twoLine;
    public Text threeLine;
    public Text fourLine;
    public Text allLine;
    public RectTransform nextTetrominoPanel;
    // Private variables.
    TetrominoSpawner spawner;
    // Unity functions.
    void Awake()
    {
        EventManager.guiUpdate += UpdateGUI;
        EventManager.gameEvent += EventHandler;
    }
    void Start()
    {
        spawner = gameCtl.gameObject.GetComponent<TetrominoSpawner>();
    }
      
    // HUDController functions.
    void UpdateGUI()
    {
        score.text = gameCtl.GetAllScore().score.ToString();
        oneLine.text = gameCtl.GetAllScore().oneLinesCleaned.ToString();
        twoLine.text = gameCtl.GetAllScore().twoLinesCleaned.ToString();
        threeLine.text = gameCtl.GetAllScore().threeLinesCleaned.ToString();
        fourLine.text = gameCtl.GetAllScore().fourLinesCleaned.ToString();
        allLine.text = gameCtl.GetAllScore().allLinesCleaned.ToString();
    }
    void EventHandler(GameEventType type)
    {
        if (type == GameEventType.SpawnNewPiece)
        {
            spawner.nextTetromino.position = Camera.main.ScreenToWorldPoint(nextTetrominoPanel.position);
            spawner.nextTetromino.Translate(0,0,10);
            spawner.nextTetromino.gameObject.SetActive(true);
        }
    }

}
