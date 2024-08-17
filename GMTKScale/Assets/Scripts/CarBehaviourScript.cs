using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    float input_X = 0f;
    float input_Y = 0f;

    public float x_Move = 5f;
    public float y_Move = 5f;

    public float speed_Limit = 45f;

    public Transform back;


    public float forward_Force = 0f;

    public Vector3 velocityOutput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(forward_Force <= 0f)
        {
            forward_Force = 1f;
        }
        input_X = Input.GetAxis("Horizontal") * x_Move;
        input_Y = Input.GetAxis("Vertical") * (y_Move - y_Move * (forward_Force / speed_Limit));




        gameObject.transform.Rotate(new Vector3(0, input_X, 0));

        


        rb.AddForceAtPosition(transform.forward * input_Y, new Vector3(back.position.x,back.position.y, back.position.z - 10f),ForceMode.Acceleration);
        

        velocityOutput = rb.velocity;

        forward_Force = ((rb.velocity.x * rb.velocity.x) / 2) + ((rb.velocity.z * rb.velocity.z) / 2);

    }
}
