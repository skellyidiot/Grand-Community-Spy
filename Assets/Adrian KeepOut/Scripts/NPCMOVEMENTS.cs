using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCMOVEMENTS : MonoBehaviour
{
    Rigidbody npc;
    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<Rigidbody>();
        
    }

   
    

    // Update is called once per frame
    void Update()
    {
        while (true)
        {
            npc.AddForce(0, 1, 0);
        }
        
    }
}
