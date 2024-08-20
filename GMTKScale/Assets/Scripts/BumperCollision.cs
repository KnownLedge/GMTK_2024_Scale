using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCollision : MonoBehaviour
{
    public bool hitWall = false;
    public float hitForce = 0;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        hitWall = true;

        Debug.Log("OW");
    }
}
