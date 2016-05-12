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

public class SpearBehaviour : MonoBehaviour
{
    // Public variables.
    public int PaperCount { get{return paperCount;}}

    // Private variables.
    int paperCount = 0;
    bool isOnGround = false;

    // Unity functions.
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            GetComponents<Collider2D>()[0].enabled = false;
            GetComponents<Collider2D>()[1].enabled = true;
            Destroy(GetComponent<FixedJoint2D>());
            Destroy(GetComponent<Rigidbody2D>());
            isOnGround =true;
        }
        else if (col.gameObject.tag == "Paper")
        {
            if (isOnGround)
            {
                Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(),gameObject.GetComponents<Collider2D>()[1]);
            }
            else
            {
                Destroy(col.gameObject.GetComponent<Rigidbody2D>());
                Destroy(col.gameObject.GetComponent<Collider2D>());
                col.transform.SetParent(transform);
                paperCount++;
            }

        }
    }
      
    // SpearBehaviour functions.
}
