using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplicitEuler : MonoBehaviour {


    public Vector3 velocity;
    public float mass;
    public float k; //Spring constant
    private Vector3 newPosition;


    // Update is called once per frame
    void FixedUpdate()
    {
        newPosition = transform.position + Time.fixedDeltaTime * velocity;

        velocity = velocity + Time.fixedDeltaTime * ComputeForce() / mass;
        transform.position = newPosition;
    }


    Vector3 ComputeForce()
    {
        //Spring force: force = -k*x(t)
        return -k * transform.position;
    }
}



