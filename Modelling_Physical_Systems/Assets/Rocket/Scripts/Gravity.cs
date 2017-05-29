using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    public float gravityAcceleration;

    private Rigidbody rb;
    private Vector3 gravityDirection = Vector3.down;
    private Vector3 gravityForce;
    private RocketInfo ri;
    private bool useGravity = false;


    private void Awake()
    {
        EventManager.StartThrust += EnableGravity;
        rb = GetComponent<Rigidbody>();
        ri = GetComponent<RocketInfo>();
        ri.centerOfGravityPos.localPosition = CalcCenterOfGravity;
    }


    private void EnableGravity(int index)
    {
        if(index == ri.fireworksIndex)
            useGravity = true;
    }


    private void OnDestroy()
    {
        EventManager.StartThrust -= EnableGravity;

    }

    private void FixedUpdate()
    {
        ri.centerOfGravityPos.localPosition = CalcCenterOfGravity;
        rb.centerOfMass = ri.centerOfGravityPos.localPosition;

        if (useGravity)
        {

            gravityForce = rb.mass * gravityDirection * gravityAcceleration;

            rb.AddForceAtPosition(gravityForce, ri.centerOfGravityPos.position);
        }
        
    }



    Vector3 CalcCenterOfGravity
    {
        get
        {
            Vector3 centerOfGravity = new Vector3();

            
            foreach(RocketPart part in ri.rocketObjects)
            {
                centerOfGravity += part.part.localPosition * part.weight;
            }

            centerOfGravity /= ri.TotalWeight();

            return centerOfGravity;
        }
    }

}
