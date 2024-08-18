using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CarBehaviourScript : MonoBehaviour
{
    [Tooltip("Rigidbody Component for Collisions and Gravity")]
    Rigidbody rb;
    [Tooltip("Horizontal input value")]
    float input_X = 0f;
    [Tooltip("Vertical input value")]
    float input_Y = 0f;

    [Tooltip(" Turning speed value")]
    public float x_Speed = 5f;
    [Tooltip(" driving speed value")]
    public float y_Speed = 5f;
    [Tooltip("Maximum speed vehicle can move at")]
    public float speed_Limit = 45f;

    [Tooltip("Output of the magnitiude of movement")]
    public float forward_Force = 0f;

    public float drag = 0.98f;

    public Vector3 velocityOutput;

    [Tooltip("Vector for tracking velocity of vehicle")]
    public Vector3 moveForce;

    [Tooltip("Readjust turning to prevent sliding")]
    public float traction = 1f;

    private float storeGrav; // stores vertical velocity;

    [Tooltip("Reference to vehicle tranform for visual effects")]
    public Transform vehicleObj;

    [Tooltip("Boosts car speed depending on how hard the car is drifting")]
    public float driftAccel = 0f;

    [Tooltip("How much driftAccel affects speed")]
    public float driftAccelRate = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        input_X = Input.GetAxis("Horizontal");
        input_Y = Input.GetAxis("Vertical");


        moveForce += transform.forward * input_Y * (y_Speed  + driftAccel * driftAccelRate)* Time.deltaTime;


        storeGrav = rb.velocity.y;

        //transform.position += moveForce * Time.deltaTime;
        rb.velocity = moveForce;

        rb.velocity = new Vector3(rb.velocity.x, storeGrav, rb.velocity.z);

        transform.Rotate(Vector3.up * input_X * x_Speed * moveForce.magnitude * Time.deltaTime);

        moveForce *= drag;

        moveForce = Vector3.ClampMagnitude(moveForce, speed_Limit);
        
        velocityOutput = rb.velocity;


        forward_Force = moveForce.magnitude;

        //Traction
        Debug.DrawRay(transform.position, moveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        vehicleObj.forward = Vector3.Reflect(moveForce.normalized, transform.forward);
        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;

        driftAccel = Vector3.Distance(moveForce.normalized, transform.forward);
    }
}

//float currentSpeed = Rigidbody.velocity.magnitude;
//float accelRampT = currentSpeed / maxSpeed;