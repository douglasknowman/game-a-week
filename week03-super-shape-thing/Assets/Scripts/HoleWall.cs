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

public class HoleWall : MonoBehaviour
{
    // Public variables.
    public Vector2 wallSize = new Vector2(20,15);
    public float holeDepth = -2f;
    public float maxHoleSize = 5f;
    public float minHoleSize = 1f;
    [Range(0.5f,10)]
    public float uvMultiplier = 2;
    public Material material;
    public float timeToDestroy = 4f;
    [Range(0.0f,1.0f)]
    public float relativeNoHoleBoader = 0.2f;

    // debug variables
    // Private variables.
    private Vector3 holeSize;
    private Vector2 holePos;
    // Unity functions.
    void Start()
    {
        // Calculate hole size.
        
        holeSize = new Vector3(Random.Range(minHoleSize,maxHoleSize),Random.Range(minHoleSize,maxHoleSize),holeDepth);


        // Calculate random position for the hole.
        float xBound = relativeNoHoleBoader * wallSize.x;
        float yBound = relativeNoHoleBoader * wallSize.y;

        float px = Random.Range(xBound + holeSize.x/2, wallSize.x - (xBound + holeSize.x/2));
        float py = Random.Range(yBound + holeSize.y/2, wallSize.y - (yBound + holeSize.y/2));
        holePos = new Vector2(px,py); 

        // put the mesh on MeshFilter component
        Mesh mesh = GeometryUtils.CreateHoleWall(wallSize,holeSize,holePos,uvMultiplier);
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        gameObject.AddComponent<BoxCollider>().isTrigger = true;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //TODO supermaster check of collision here.
            transform.root.GetComponent<ScenarySpawner>().passThrough = true;
            col.gameObject.GetComponent<CharacterController>().isInput  = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.root.GetComponent<ScenarySpawner>().passThrough = false;
            col.gameObject.GetComponent<CharacterController>().isInput = true;
            StartCoroutine(DelayDestroy());
        }
    }

    // HoleWall functions.
    IEnumerator DelayDestroy()
    {
        float timecnt = 0;
        while (timecnt < timeToDestroy)
        {
            timecnt += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
