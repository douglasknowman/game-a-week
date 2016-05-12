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
    public int paperBySpawn = 4;
    // Private variables.
    float gravitySpeed = 0.1f;
    float timecnt = 0;
    // Unity functions.
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
    void SpawnPaper()
    {
        GameObject obj = Instantiate(paperPrefab,transform.position,Quaternion.identity) as GameObject;
        obj.transform.position = new Vector3(Random.Range(spawnXRange.x,spawnXRange.y),transform.position.y,0);;
        obj.GetComponent<Rigidbody2D>().gravityScale = gravitySpeed;
    }
}
