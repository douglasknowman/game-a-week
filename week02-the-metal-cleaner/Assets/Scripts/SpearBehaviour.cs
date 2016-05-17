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
            // send sound effect event
            EventManager.sfxEvent(SfxEventType.SpearColl);

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
                col.transform.localPosition = new Vector3(paperCount * 0.4f, 0,0);

                // stoping the animation
                col.gameObject.GetComponent<Animator>().SetBool("isFalling",false);
                paperCount++;
                // sound effect event
                EventManager.sfxEvent(SfxEventType.PaperTake);
            }

        }
        else if (col.gameObject.tag != "Player")  EventManager.sfxEvent(SfxEventType.SpearColl);
    }
      
    // SpearBehaviour functions.
}
