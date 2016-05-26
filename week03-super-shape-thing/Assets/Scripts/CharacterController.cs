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

public class CharacterController : MonoBehaviour
{
    // Public variables.
    public float moveSpeed = 3;
    public float changeShapeSpeed = 2;
    public float maxCharSize = 5;
    public float minCharSize = 1;
    public Vector2 minCharPos = new Vector2(1,1);
    public Vector2 maxCharPos = new Vector2(12,12);
    public bool isInput = true;
    // Private variables.
    // Unity functions.
    void Update ()
    {
        if (!isInput) return;

        float mv = Input.GetAxis("Vertical");
        float mh = Input.GetAxis("Horizontal");

        float sv = Input.GetAxis("VerticalS");
        float sh = Input.GetAxis("HorizontalS");

        // Movimentation
        Vector3 pos = transform.position + new Vector3(mh * moveSpeed * Time.deltaTime,mv * moveSpeed * Time.deltaTime, 0);
        pos.x = pos.x > maxCharPos.x ? maxCharPos.x : pos.x;
        pos.x = pos.x < minCharPos.x ? minCharPos.x : pos.x;
        pos.y = pos.y > maxCharPos.y ? maxCharPos.y : pos.y;
        pos.y = pos.y < minCharPos.y ? minCharPos.y : pos.y;
        transform.position = pos;

        // Shape Change
        Vector3 scale = transform.localScale + new Vector3(sh * changeShapeSpeed * Time.deltaTime,sv * changeShapeSpeed * Time.deltaTime,0);
        scale.x = scale.x > maxCharSize ? maxCharSize : scale.x;
        scale.x = scale.x < minCharSize ? minCharSize : scale.x;
        scale.y = scale.y > maxCharSize ? maxCharSize : scale.y;
        scale.y = scale.y < minCharSize ? minCharSize : scale.y;
        transform.localScale = scale;
    }
      
    // CharacterController functions.
}
