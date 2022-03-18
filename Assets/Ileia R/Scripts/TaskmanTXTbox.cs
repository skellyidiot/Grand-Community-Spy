using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskmanTXTbox : MonoBehaviour
{
    public GameObject player;
    int curtext = 0;
    private GameObject textobj;

    public GameObject RootObjectOfHFactsTextBox;
    public bool isTalking;

    public bool doingTask1;
    public bool doingTask2;
    public bool doingTask3;

    public string Text1 = "Do whatever you want";
    public string Text2 = "Do whatever I want";
    public string Text3 = "leave";

    public float time = 3;

    // Start is called before the first frame update
    void Start()
    {
        RootObjectOfHFactsTextBox.SetActive(false);
    }

    void Update()
    {
        if(isTalking == true)
        {
            if (Input.GetKeyDown("1"))
            {
                doingTask1 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
                time -= Time.deltaTime;
            }
            if (Input.GetKeyDown("2"))
            {
                doingTask2 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
                time -= Time.deltaTime;
            }
            if (Input.GetKeyDown("3"))
            {
                doingTask3 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
                time -= Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && doingTask1 != true && doingTask2 != true && doingTask3 != true && time >= 3)
        {
            RootObjectOfHFactsTextBox.SetActive(true);
            isTalking = true;
        }
        if (collision.gameObject.tag != "Player")
        {
            RootObjectOfHFactsTextBox.SetActive(false);
            isTalking = false;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        RootObjectOfHFactsTextBox.SetActive(false);
    }

}
