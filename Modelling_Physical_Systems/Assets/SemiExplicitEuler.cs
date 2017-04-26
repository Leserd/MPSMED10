using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiExplicitEuler : MonoBehaviour {

    public Vector3 velocity;
    public float mass;
    public float k; //Spring constant
    private Vector3 newPosition;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       // newPosition = transform.position + Time.fixedDeltaTime * velocity;

        velocity = velocity + Time.fixedDeltaTime * ComputeForce() / mass;
        var newPosition2 = transform.position + Time.fixedDeltaTime * velocity;

        transform.position =  newPosition2;

    }

    Vector3 ComputeForce()
    {
        //Spring force: force = -k*x(t)
        return -k * transform.position;
    }
}
