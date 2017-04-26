using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearDrag : MonoBehaviour {

    public Vector3 velocity;
    public float linearDrag, MagVelocity;
    
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = gameObject.AddComponent<Rigidbody>();
        rigid.useGravity = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        rigid.AddForce(Physics.gravity, ForceMode.Acceleration);
        velocity = rigid.velocity;
        MagVelocity = velocity.sqrMagnitude;
        rigid.AddForce(-linearDrag*velocity);
		
	}
}
