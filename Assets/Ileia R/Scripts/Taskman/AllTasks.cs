using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTasks : MonoBehaviour
{
    //task 1
    public GameObject infosteal;
    public static bool hasInfo;

    //task 2 
    public GameObject leader;
    public bool LeaderInCar;
    public GameObject dropOff;
    //taskman script
    public TaskmanTXTbox taskmanScript;

    //car script 
    public Car carScript;

    // Start is called before the first frame update
    void Start()
    {
        // task 1
        infosteal = GameObject.FindGameObjectWithTag("info");

        //task 2 
        leader = GameObject.FindGameObjectWithTag("Leader");
        leader.SetActive(false);
        dropOff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //task 1
        if(collision.gameObject.tag == "info" && hasInfo == false)
        {
            infosteal.SetActive(false);
            hasInfo = true;

            infosteal.transform.position = gameObject.transform.position;
        }
        if(collision.gameObject.tag == "TaskMan" && hasInfo == true)
        {
            hasInfo = false;
            TaskmanTXTbox.doneTask1 = true;
        }
        //Task 2
        if(TaskmanTXTbox.doingTask2 == true)
        {
            leader.SetActive(true);
        }
        if (Car.isDriving == true && collision.gameObject.tag == "Leader")
        {
            leader.SetActive(false);
            leader.transform.position = Car.car.transform.position;

            LeaderInCar = true;
            dropOff.SetActive(true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DropOff" && LeaderInCar == true)
        {
            Destroy(leader);
            Destroy(dropOff);
            TaskmanTXTbox.doneTask2 = true;
        }
    }
}
