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
    public float frictionHealthGenerated = 30f;
    public Vector2 wallSize = new Vector2(20,15);
    public float holeDepth = -2f;
    public float maxHoleSize = 5f;
    public float minHoleSize = 1f;
    [Range(0.1f,10)]
    public float uvMultiplier = 2;
    public Material material;
    public float timeToDestroy = 4f;
    [Range(0.0f,1.0f)]
    public float relativeNoHoleBoader = 0.2f;

    public AudioClip good;
    public AudioClip fail;

    // Private variables.
    private AudioSource audioSource;
    private Vector3 holeSize;
    private Vector2 holePos;
    private GameController gc;
    // Unity functions.
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        audioSource = GetComponent<AudioSource>();
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
            // calculate frication by hole and player size.
            float xFactor = holeSize.x - col.transform.localScale.x ;
            float yFactor = holeSize.y - col.transform.localScale.y ;
            yFactor = Mathf.Abs(yFactor);
            yFactor = 1 - yFactor;
            xFactor = Mathf.Abs(xFactor);
            xFactor = 1 - xFactor;
            float factor = (yFactor + xFactor)/2 ;
            gc.HealthPoints += Mathf.Clamp(factor,-0.2f,1f) * frictionHealthGenerated;
            //Debug.Log(yFactor.ToString() + " x " + xFactor.ToString());

            // calculate damage
            float distance = Vector3.Distance(new Vector3(holePos.x,holePos.y,0),new Vector3(col.transform.position.x,col.transform.position.y,0));

            float averageDistance = (holeSize.x + holeSize.y) /2;
            float damage = distance/ averageDistance;
            damage = damage/2;
            damage = damage > 1?1:damage;

            gc.HealthPoints -= (damage * gc.maxHealthPoints);
            Debug.DrawLine(new Vector3(holePos.x,holePos.y,transform.position.z),col.transform.position,Color.red,1);
            // Playing audio
            if (damage > 0.15f || factor < 0.0f)
            {
                audioSource.clip = fail;
            }
            else audioSource.clip = good;

            audioSource.Play();
            //Debug.Log(factor);

            // Apply score points
            gc.Points += 1;
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
