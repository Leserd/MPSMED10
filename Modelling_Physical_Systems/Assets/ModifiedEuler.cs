using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedEuler : MonoBehaviour {

    public Vector3 velocity;

    public float mass;
    public float k; //Spring constant

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forceAtPosition = ComputeForce(transform.position, velocity);


        //full euler step
        Vector3 stdEulerPosition = transform.position + Time.fixedDeltaTime  * velocity;
        Vector3 stdEulerVelocity = velocity + Time.fixedDeltaTime * forceAtPosition / mass;


        var newPos = transform.position + Time.fixedDeltaTime * (velocity + stdEulerVelocity) / 2.0f;
        //Velocity = VelocityAtPosition + Timestep *( mass^-1 * ForceAtPosition + mass^-1 *ForceAtNextEulerStep)/2
        velocity = velocity + Time.fixedDeltaTime * (forceAtPosition + ComputeForce(stdEulerPosition, stdEulerVelocity))/mass / 2.0f ;
        //Vector3 newPosition = transform.position + Time.fixedDeltaTime * velocity;
        transform.position = newPos;

    }


    Vector3 ComputeForce(Vector3 position, Vector3 velocity)
    {
        //Spring force: force = -k*x(t)
        return -k * position;
    }
}

