using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCast : MonoBehaviour
{
    private int numberOfObjects;
    public LayerMask lm;

    // Update is called once per frame
    void Update()
    {
        CheckForNPC();
    }

    private void CheckForNPC()
    {
        RaycastHit2D[] boxResult;
        boxResult = Physics2D.BoxCastAll(gameObject.transform.position, new Vector2(10, 10), 0f, new Vector2(0, 1f), 10f, lm);
        for (int i = 0; i < boxResult.Length; i++)
        {
            Debug.Log(boxResult[i].collider.name);
        }
            
    }
}
