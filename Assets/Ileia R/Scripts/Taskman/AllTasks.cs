using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTasks : MonoBehaviour
{
    public GameObject infosteal;
    public bool hasInfo;

    public TaskmanTXTbox taskmanScript;
    // Start is called before the first frame update
    void Start()
    {
        infosteal = GameObject.FindGameObjectWithTag("info");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
    }
}
