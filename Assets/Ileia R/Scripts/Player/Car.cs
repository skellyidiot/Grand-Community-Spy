using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public bool isDriving;

    public GameObject car;

    public float carXR;
    public float carYR;
    public float carZR;
    // Start is called before the first frame update
    void Start()
    {
        isDriving = false;

        car = GameObject.FindGameObjectWithTag("car");
        carXR = car.transform.rotation.x;
        carYR = car.transform.rotation.y;
        carZR = car.transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Car");
            if (collision.gameObject.tag == "car" && isDriving == false)
            {
                gameObject.transform.position = car.transform.position;
                gameObject.transform.rotation = Quaternion.Euler(carXR, carYR, carZR);
                car.transform.SetParent(gameObject.transform);
                //car.transform.localScale = new Vector3(6.5F, 6.5F, 1F);
                isDriving = true;
            }
        }
        
    }
}
