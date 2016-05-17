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

public class SpearLauncher : MonoBehaviour
{
    // Public variables.
    public GameObject spearPrefab;
    public float shootForce = 1000;
    public bool shoot;
    public int maxSpears = 2;
    // Private variables.
    int atualSpears;
    // Unity functions.
    void Start()
    {
        atualSpears = maxSpears;
    }
    void Update ()
    {
        if (shoot)
        {
            if (atualSpears > 0)
            {
                // send sound effect event
                EventManager.sfxEvent(SfxEventType.Shoot);
                Launch();
                atualSpears -= 1;
            }
            shoot = false;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spear")
        {
            Destroy(col.gameObject);
            atualSpears++;
            SpearBehaviour spear = col.gameObject.GetComponent<SpearBehaviour>();
            if (spear.PaperCount > 0 )
            {
                EventManager.sfxEvent(SfxEventType.SpearTake);
                EventManager.gameEvent(GameEventType.PapersTaked,spear.PaperCount);
            }
        }
    }
    // SpearLauncher functions.
    void Launch()
    {
        Vector3 dir =Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.Normalize();
        GameObject obj = Instantiate(spearPrefab,transform.position + dir * 3 ,Quaternion.identity) as GameObject;

        // calculating the rotation of the spear before launch.
        float angle = Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg ;
        angle = (360 - angle) + 90;
        obj.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        // Apply the force to the tip of the spear.
        obj.GetComponentInChildren<Rigidbody2D>().AddForce(obj.transform.right * shootForce);
        Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(),gameObject.GetComponent<Collider2D>());
    }
      
}
