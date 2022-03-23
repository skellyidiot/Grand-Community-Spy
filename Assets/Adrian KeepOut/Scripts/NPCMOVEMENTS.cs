using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCMOVEMENTS : MonoBehaviour
{
    public Transform npc;
    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<Transform>();
        
    }

   
    

    // Update is called once per frame
    void Update()
    {

        float newX = npc.transform.position.x + .5f;
        npc.transform.position = new Vector3( newX, npc.transform.position.y, npc.transform.position.z );
      //  npc.transform.position.x = 20f;

    }
}
