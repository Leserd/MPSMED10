using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrag : MonoBehaviour {

    
    public float dragCoefficient = 0.42f;   //Halfsphere (rocketHead) drag coefficient = 0.42
    public float dragForce;
    public Vector3 dragDirection;
    public float airDensity = 1.225f;
    public Transform rocketHead, rocketStick;

    private Rigidbody rb;
    private RocketInfo ri;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ri = GetComponent<RocketInfo>();
    }


    private void FixedUpdate()
    {

        rb.AddForceAtPosition(-ri.thrustPos.up * CalculateDragForce(), ri.centerOfGravityPos.position);
    }


    public float CalculateSurfaceArea()
    {
        float area = 0;

        area += Mathf.PI * rocketHead.localScale.x * rocketHead.localScale.x;
        //area += rocketStick.localScale.x * rocketStick.localScale.y * rocketStick.localScale.z;

        return area;
    }

    
    public float CalculateDragForce()
    {
        float drag = 0;

        drag = 0.5f * airDensity * rb.velocity.sqrMagnitude * dragCoefficient * CalculateSurfaceArea();

        return drag;
    }
}
