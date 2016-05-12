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

public class PaperSpawner : MonoBehaviour
{
    // Public variables.
    public GameObject paperPrefab;
    public Vector2 spawnXRange;
    public float timeBetweekSpawns = 4;
    public float paperBySpawnIncrease = 0.2f;
    public float gravitySpeedIncrease = 0.05f;
    // Private variables.
    float gravitySpeed = 0.05f;
    int paperBySpawn = 1;
    float paperBySpawnCounter = 1;
    float timecnt = 0;
    // Unity functions.
    void Start()
    {
        EventManager.gameEvent += EventHandler;
    }
    void Update ()
    {
        timecnt += Time.deltaTime;
        if (timecnt > timeBetweekSpawns)
        {
            for (int i=0;i<paperBySpawn; i++)
            {
                SpawnPaper();
            }
            timecnt = 0;
        }
    }
      
    // PaperSpawner functions.
    void EventHandler(GameEventType type, int val)
    {
        if (type == GameEventType.LevelUp)
        {
            paperBySpawnCounter += paperBySpawnIncrease;
            paperBySpawn = (int) paperBySpawnCounter;
            gravitySpeed = val * gravitySpeedIncrease;
        }
    }
    void SpawnPaper()
    {
        GameObject obj = Instantiate(paperPrefab,transform.position,Quaternion.identity) as GameObject;
        obj.transform.position = new Vector3(Random.Range(spawnXRange.x,spawnXRange.y),transform.position.y,0);;
        obj.GetComponent<Rigidbody2D>().gravityScale = gravitySpeed;
    }
}
