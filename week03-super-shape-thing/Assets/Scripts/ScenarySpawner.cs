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
    public GameObject backgroundPrefab;
    public float wallDistance = 10f;
    public float moveSpeed = 3f;
    public float passThroughSpeed =2f;
    public bool passThrough = false;

    // Private variables.
    private Transform wallx;
    private Transform wally;
    private Transform bgx;
    private Transform bgy;
    private Transform bgz;
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

    }
      
    // ScenarySpawner functions.
    
    Transform WallInstantiate(Transform basedOn)
    {
        Transform x =   (Instantiate(wallPrefab,basedOn.position - Vector3.forward * wallDistance,Quaternion.identity) as GameObject).transform;
        x.SetParent(transform);
        return x;
    }
}
