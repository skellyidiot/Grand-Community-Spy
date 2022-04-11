using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public GameObject[] Slides;
    public int CurrSlide = 0;
    public int Length = 0;
    // Start is called before the first frame update
    void Start()
    {
        Length = Slides.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Slides[CurrSlide].SetActive(false);
            
            if (CurrSlide >= Length)
            {
                //end
            }
            else
            {
                CurrSlide += 1;
                Slides[CurrSlide].SetActive(true);
            }
        }
    }
}
