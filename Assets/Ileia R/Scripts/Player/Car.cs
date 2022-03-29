using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public bool isDriving;

    public GameObject car;
    public GameObject GetOut;

    Rigidbody2D RB;

    private float carXS;
    private float carYS;
    private float carZS;

    private float carXR;
    private float carYR;
    private float carZR;

    private float carX;
    private float carY;
    private float carZ;

    public GameObject RootObjectOfHFactsTextBox;

    // Start is called before the first frame update
    void Start()
    {
        isDriving = false;
        RootObjectOfHFactsTextBox.SetActive(false);

        car = GameObject.FindGameObjectWithTag("car");

        RB = GetComponent<Rigidbody2D>();

        carXS = car.transform.localScale.x;
        carYS = car.transform.localScale.y;
        carZS = car.transform.localScale.z;

        carXR = car.transform.rotation.x;
        carYR = car.transform.rotation.y;
        carZR = car.transform.rotation.z;

        carX = car.transform.position.x;
        carY = car.transform.position.y;
        carZ = car.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDriving == true)
        {
            RootObjectOfHFactsTextBox.SetActive(false);
            this.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponent<Shoot>().enabled = false;
            this.GetComponent<CarController>().enabled = true;
            this.GetComponent<CarInputHandler>().enabled = true;
            RB.constraints = RigidbodyConstraints2D.None;

            RB.drag = 5f;
            RB.angularDrag = 20f;

        }
        if(isDriving == true && Input.GetKey(KeyCode.F))
        {
            if (isDriving == true)
            {
                carX = car.transform.position.x - .2F;
                carY = car.transform.position.y;
                carZ = car.transform.position.z;

                GetOut.transform.position = new Vector3(carX, carY, carZ);
                gameObject.transform.position = GetOut.transform.position;
                car.transform.parent = null;
                isDriving = false;
            }
        }
        if(isDriving == false)
        {
            this.GetComponent<PlayerMovement>().enabled = true;
            this.GetComponent<Shoot>().enabled = true;
            this.GetComponent<CarController>().enabled = false;
            this.GetComponent<CarInputHandler>().enabled = false;

            RB.constraints = RigidbodyConstraints2D.FreezeRotation;
            RB.drag = 0f;
            RB.angularDrag = 0.05f;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "car" && isDriving == false)
        {
            RootObjectOfHFactsTextBox.SetActive(true);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Car");
            if (collision.gameObject.tag == "car" && isDriving == false)
            {
                gameObject.transform.position = car.transform.position;
                gameObject.transform.rotation = Quaternion.Euler(carXR, carYR, carZR);
                car.transform.SetParent(gameObject.transform);
                car.transform.localScale = new Vector3(carXS, carYS, carZS);
                WaitForSeconds();
                isDriving = true;
            }   
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        RootObjectOfHFactsTextBox.SetActive(false);
    }

    IEnumerable WaitForSeconds()
    {
        yield return new WaitForSeconds(.5F);
    }
}
