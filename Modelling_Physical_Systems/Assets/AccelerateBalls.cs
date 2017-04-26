using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateBalls : MonoBehaviour {
    public Vector3 Velocity, Acceleration;
    void FixedUpdate()
    {
        Velocity = Velocity + Acceleration * Time.fixedDeltaTime;

        transform.position = transform.position + Velocity * Time.fixedDeltaTime;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
