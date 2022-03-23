﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskmanTXTbox : MonoBehaviour
{
    public GameObject player;
    int curtext = 0;
    private GameObject textobj;

    public Text txt;
    public GameObject RootObjectOfHFactsTextBox;
    public bool isTalking;

    public bool doingTask1;
    public bool doingTask2;
    public bool doingTask3;

    public bool doneTask1;
    public bool doneTask2;
    public bool doneTask3;

    public string Text1 = "Do whatever you want";
    public string Text2 = "Do whatever I want";
    public string Text3 = "leave";

    // Start is called before the first frame update
    void Start()
    {
        RootObjectOfHFactsTextBox.SetActive(false);

        txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Hey, I am task man, which task do you want to do? \n 1.) Go kill some pedestrian \n 2.) Go and do something else \n 3.) idk";
    }

    void Update()
    {

        if (isTalking == true)
        {
            if (Input.GetKeyDown("1") && doneTask1 != true)
            {
                doingTask1 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
            }
            if (Input.GetKeyDown("2") && doneTask2 != true)
            {
                doingTask2 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
            }
            if (Input.GetKeyDown("3") && doneTask3 != true)
            {
                doingTask3 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
            }
        }
        if(doneTask1 == true)
        {
            doingTask1 = false;
        }
        if (doneTask2 == true)
        {
            doingTask2 = false;
        }
        if (doneTask3 == true)
        {
            doingTask3 = false;
        }

        if (doneTask1 == true && doneTask2 == false && doneTask3 == false && doingTask2 == false && doingTask3 == false)
        {
            txt.text = "good job doing task 1, now pick one of these tasks \n 2.) Go and do something else \n 3.) idk";
        }
        if (doneTask1 == true && doneTask2 == true && doneTask3 == false && doingTask3 == false)
        {
            txt.text = "good job doing task 1 and two, you can only do this task: \n 3.) idk";
        }
        if (doneTask1 == false && doneTask2 == true && doneTask3 == false && doingTask3 == false && doingTask1 == false)
        {
            txt.text = "good job doing task 2, you can only do this task: \n 1.) Go kill some pedestrian \n 3.) idk";
        }
        if (doneTask1 == true && doneTask3 == true && doneTask2 != true && doingTask2 != true)
        {
            txt.text = "Good job doing task 1 and task 3, now do this task: \n 2.) Go and do something else)";
        }
        if(doneTask2 == true && doneTask3 == true && doneTask1 != true && doingTask1 != true)
        {
            txt.text = "Good job doing task 2 and task 3, now do this task: \n 1.) Go kill some pedestrian";
        }
        if (doneTask2 != true && doneTask3 == true && doneTask1 != true && doingTask1 != true && doingTask2 != true)
        {
            txt.text = "Good job doing task 3, now do this task: \n 1.) Go kill some pedestrian \n 2.) Go and do something else)";
        }
        if(doneTask1 == true && doneTask2 == true && doneTask3 == true)
        {
            txt.text = "Good job you are done!";
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && doingTask1 != true && doingTask2 != true && doingTask3 != true)
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        RootObjectOfHFactsTextBox.SetActive(false);
        isTalking = false;
    }
}