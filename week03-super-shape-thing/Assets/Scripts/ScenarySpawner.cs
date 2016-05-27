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

public class ScenarySpawner : MonoBehaviour
{
    // Public variables.
    public GameObject wallPrefab;
    public float wallDistance = 10f;
    public float moveSpeed = 3f;
    public float passThroughSpeed =2f;
    public bool passThrough = false;
    public  Transform bgx;
    public  Transform bgy;
    public  Transform bgz;

    // Private variables.
    private Transform wallx;
    private Transform wally;
    // Unity functions.
    void Start()
    {
        wally = (Instantiate(wallPrefab, -wallDistance*Vector3.forward,Quaternion.identity) as GameObject).transform;
        wally.SetParent(transform);
        wallx = WallInstantiate(wally);
    }

    void Update ()
    {
        float speed = passThrough ? passThroughSpeed : moveSpeed;
        if (wallx != null)
        {
            wallx.Translate(0,0,speed * Time.deltaTime);
        }else
        {
            wallx = WallInstantiate(wally);
        }

        if (wally != null)
        {
            wally.Translate(0,0,speed * Time.deltaTime);
        }else
        {
            wally = WallInstantiate(wallx);
        }

        // moving background
        if (bgx.position.z >16)
        {
            bgx.position = new Vector3(bgx.position.x,bgx.position.y,-32);
        }
        if (bgy.position.z >16)
        {
            bgy.position = new Vector3(bgy.position.x,bgy.position.y,-32);
        }
        if (bgz.position.z >16)
        {
            bgz.position = new Vector3(bgz.position.x,bgz.position.y,-32);
        }
        bgx.Translate(0,0,speed * Time.deltaTime);
        bgy.Translate(0,0,speed * Time.deltaTime);
        bgz.Translate(0,0,speed * Time.deltaTime);
    }
      
    // ScenarySpawner functions.
    
    Transform WallInstantiate(Transform basedOn)
    {
        Transform x =   (Instantiate(wallPrefab,basedOn.position - Vector3.forward * wallDistance,Quaternion.identity) as GameObject).transform;
        x.SetParent(transform);
        return x;
    }
}
