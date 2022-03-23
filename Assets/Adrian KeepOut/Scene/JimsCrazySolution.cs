using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimsCrazySolution : MonoBehaviour
{
    

    public List<Transform> patrolPts = new List<Transform>();

    Transform[] patrolPoints = new Transform[] { };

    public int patrolPath;

    public float pathTime;

    public float currentTime;
    public float offset;
    int nPoints;
   

    void Start()

    {
        offset = Random.Range(1, 5);
        patrolPath = 0;

        patrolPoints = patrolPts.ToArray();

        nPoints = patrolPoints.Length;


        

    }



    // Update is called once per frame

    void Update()

    {

        currentTime += Time.deltaTime;

        if (currentTime > pathTime+offset)

        {

            currentTime = 0; //reset the timer

            patrolPath++;

            if (patrolPath > nPoints - 1) patrolPath = 0;



        }

        transform.position = Vector3.Lerp(patrolPoints[patrolPath].position, patrolPoints[(patrolPath + 1) % nPoints].position, (currentTime / (pathTime+offset)));



    }

}

