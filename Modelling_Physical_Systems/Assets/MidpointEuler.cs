using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidpointEuler : MonoBehaviour {
    public Vector3 velocity;

    public float mass;
    public float k; //Spring constant


    void FixedUpdate()
    {
        Vector3 forceAtPosition = ComputeForce(transform.position, velocity);

        Vector3 midPosition = transform.position + Time.fixedDeltaTime / 2.0f * velocity;
        Vector3 midVelocity = velocity + Time.fixedDeltaTime / 2.0f * forceAtPosition / mass;

        var newPos = transform.position + Time.fixedDeltaTime * midVelocity;

        //Vector3 newPosition = transform.position + Time.fixedDeltaTime * velocity;
        velocity = velocity + Time.fixedDeltaTime * ComputeForce(midPosition, midVelocity) / mass;
        transform.position = newPos;
    }


    Vector3 ComputeForce(Vector3 position, Vector3 velocity)
    {
        //Spring force: force = -k*x(t)
        return -k * position;
    }
}

		
