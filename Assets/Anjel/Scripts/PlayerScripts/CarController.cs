using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float accelerationFactor = 30.0f;
    public float turnFactor = 35f;

    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;

    Rigidbody2D carRB2;

    // Start is called before the first frame update
    void Start()
    {
        carRB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        
        if(Mathf.Abs(carRB2.velocity.x) + Mathf.Abs(carRB2.velocity.y) >= 1)
        {
            ApplySteering();
        }
    }

    void ApplyEngineForce()
    {
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        carRB2.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        carRB2.angularVelocity -= steeringInput * turnFactor;

    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
