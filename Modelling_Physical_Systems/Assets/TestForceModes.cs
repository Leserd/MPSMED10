using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForceModes : MonoBehaviour {
    public bool Force, ForceAcc, ForceVel, ForceImp;
    Rigidbody test;

	// Use this for initialization
	void Start () {
        test =gameObject.AddComponent<Rigidbody>();
		
	}


	
	// Update is called once per frame
	void Update () {
        if (Force)
        {
            test.AddForce(Physics.gravity / test.mass, ForceMode.Force);
        }
        if (ForceAcc)
        {
            test.AddForce(Physics.gravity , ForceMode.Acceleration);
        }
        if (ForceVel)
        {
            test.AddForce(Physics.gravity * Time.fixedDeltaTime / test.mass, ForceMode.VelocityChange);
        }
        if (ForceImp)
        {
            test.AddForce(Physics.gravity * Time.fixedDeltaTime, ForceMode.Impulse);
        }

		
	}
}
