using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTutorialText : MonoBehaviour
{
    public bool isInCar;
    public GameObject thing;

    private void Start()
    {
        isInCar = false;
    }
    private void Update()
    {
        isInCar = Car.isDriving;

        if (isInCar) Destroy(thing);
    }
}
