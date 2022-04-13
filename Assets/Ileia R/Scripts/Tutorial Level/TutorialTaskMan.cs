using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTaskMan : MonoBehaviour
{
    public GameObject player;
    private GameObject textobj;

    public Text txt;
    public GameObject RootObjectOfHFactsTextBox;
    public bool isTalking;


     void Start()
        {
            RootObjectOfHFactsTextBox.SetActive(false);

            txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "I am Jose, I will give you tasks, and you do them, are you ready to help the community now? Press the corresponding key to answer: \n 1.) Yes \n 2.) No";
        }
}
