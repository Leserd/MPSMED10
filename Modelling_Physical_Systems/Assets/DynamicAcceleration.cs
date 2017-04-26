using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAcceleration : MonoBehaviour {
    public bool UsingRigid, UsingAccelerate;
    public Vector3 Velocity, Acceleration;
    public float Mass, GravitationalForce;
    public Rigidbody RBody;

    void FixedUpdate()
    {
        var force = -GravitationalForce * Mass * Vector3.up;

        Acceleration = Mathf.Pow(Mass, -1) * force;
        Velocity = Velocity + Acceleration * Time.fixedDeltaTime;
        if (UsingRigid)
        {
            RBody.AddForce(force);
        }

        if (UsingAccelerate)
        {
            transform.position = transform.position + Velocity * Time.fixedDeltaTime;
        }

    }

    // Use this for initialization
    void Start () {


        RBody = gameObject.AddComponent<Rigidbody>();
        RBody.mass = Mass;
        RBody.useGravity = false;
        
		
	}

}
