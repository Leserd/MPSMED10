using UnityEngine;
using System.Collections;

public class WeightForce : MonoBehaviour {

    Vector3 gravityDirection;
    Vector3 gravityForce;
    public float gravityAcceleration;




    Rigidbody rb;

	// Use this for initialization
	void Start () {


        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        gravityDirection = Vector3.down * gravityAcceleration;
        gravityForce = rb.mass * gravityDirection;

        rb.AddForce(gravityForce);

    }
}
