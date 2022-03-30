using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCast : MonoBehaviour
{
    private int numberOfObjects;
    public LayerMask lm;
    public float[] speedX;
    public float[] speedy;

    public float[] Vx;
    public float[] Vy;

    public Rigidbody2D playerSpeed;
    public GameObject script;
    public GameObject mainPlayer;
    
    public float oldX, oldY;
    public float vX, vY;
    private Vector2[] NPCspeed;
    private float sigma = 0.5f;

    // Update is called once per frame
    private void Start()
    {
        playerSpeed.GetComponent<Rigidbody2D>();
        Vx = new float[10];
        speedX = new float[10];
        speedy = new float[10];
        Vy = new float[10];
        NPCspeed = new Vector2[10];
}

    void Update()
    {
        CheckForNPC();
        //if(Input.GetKeyDown(KeyCode.L)) script.GetComponent<Pathfinding.AIDestinationSetter>().enabled = true;
       

       

    }

    private void FixedUpdate()
    {
        vX = (mainPlayer.transform.position.x - oldX) / (Time.deltaTime / 0.5f);
        vY = (mainPlayer.transform.position.y - oldY) / (Time.deltaTime / 0.5f);
        Debug.Log(vX + " ---- " + vY);



        oldX = mainPlayer.transform.position.x;
        oldY = mainPlayer.transform.position.y;
    }

    private void CheckForNPC()
    {
        RaycastHit2D[] boxResult;
        
        boxResult = Physics2D.BoxCastAll(gameObject.transform.position, new Vector2(10, 10), 0f, new Vector2(0, 1f), 10f, lm);
        //Debug.Log(boxResult.Length);


        //calculating volcity of each npc 
        for (int i = 0; i <= boxResult.Length-1; i++)
        {
            //Debug.Log(i + ": " + boxResult[i].collider.name);
            //Debug.Log(Vx[i] + "==========");
            Vx[i] = (transform.position.x - speedX[i] / Time.deltaTime) / 100f;
            Vy[i] = (transform.position.y - speedy[i] / Time.deltaTime) / 100f;
            speedy[i] = boxResult[i].transform.position.y;
            speedX[i] = boxResult[i].transform.position.x;

        }
        
        
        //putting each npc volcity in a array
        for(int i = 0; i < boxResult.Length-1; i++)
        {
            NPCspeed[i] = new Vector2(Vx[i], Vy[i]);
          //  Debug.Log(i + ">>>>>>>>>>>>>>>>>>>>>>> " + NPCspeed[i]);
        }
        Vector2 sum = new Vector2(0, 0);
        //summing the vocity
        for (int i = 0; i < speedX.Length; i++)
        {
            
            sum += NPCspeed[i];
        }
       //finding the average of the volcity
        sum = sum / speedy.Length;
       //Debug.Log(sum);
     

        //Vector2 playerSped = new Vector2(playerSpeed.velocity.x, playerSpeed.velocity.y);
        Debug.Log(sum.x + " " + sum.y  + " " + vX + " " + vY );
        float avgV = Mathf.Sqrt(sum.x * sum.x + sum.y * sum.y);
        float plyV = Mathf.Sqrt(vX * vX + vY * vY);
        Debug.Log(avgV + " ~~~~~~~~~~~~~~~~~ " + plyV);


        if(sum.y >= 0)
        {
            if ( (Mathf.Abs(vY) < Mathf.Abs(sum.y) - 0.5 && Mathf.Abs(vX) < Mathf.Abs(sum.x) - 0.5))
            {

                script.GetComponent<Pathfinding.AIDestinationSetter>().enabled = true;
            }
        }
        
    }
}
