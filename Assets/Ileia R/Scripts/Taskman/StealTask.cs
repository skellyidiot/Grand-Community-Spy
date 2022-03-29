using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealTask : MonoBehaviour
{
    public GameObject SpawnINBUILDING;
    public GameObject SpawnNOTINBUILDING;

    public bool isInBuilding;

    public bool hasAlreadyGoneIn;

    // Start is called before the first frame update
    void Start()
    {
        isInBuilding = false;

        hasAlreadyGoneIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DoorIn" && hasAlreadyGoneIn == false && isInBuilding == false && TaskmanTXTbox.doingTask1 == true)
        {
            isInBuilding = true;

            gameObject.transform.position = SpawnINBUILDING.transform.position;
        }

        if(collision.gameObject.tag == "DoorOut" && isInBuilding == true && AllTasks.hasInfo == true)
        {
            isInBuilding = false;
            hasAlreadyGoneIn = true;
            gameObject.transform.position = SpawnNOTINBUILDING.transform.position;
        }
    }
}
