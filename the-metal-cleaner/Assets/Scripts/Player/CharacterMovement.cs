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

public class CharacterMovement : MonoBehaviour
{
    // Public variables.
    public float moveForce = 300;
    public float moveMaxSpeed =8;
    public float jumpForce = 400;
    public bool jump;
    public float moveDir;
    // Private variables.
    bool onGround = false;
    Rigidbody2D rb;
    // Unity functions.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update ()
    {
    }
    void FixedUpdate()
    {
        onGround = Physics2D.Raycast(transform.position,Vector2.down,0.7f,1<<8);
        if (onGround && jump)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jump = false;
        }
        else if (!onGround && jump)
        {
            jump = false;
        }

        // moving the character to right and left. 

        if (Mathf.Abs(rb.velocity.x ) > moveMaxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * moveMaxSpeed,rb.velocity.y);
        }

        else 
        {
            rb.AddForce(Vector2.right * moveDir * moveForce);
        }
    }
    // CharacterMovement functions.
}
