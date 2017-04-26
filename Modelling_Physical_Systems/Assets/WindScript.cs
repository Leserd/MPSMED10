using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour {

    public Vector3 VelocityWind;
    public float DragCoeff;

	

	void FixedUpdate () {
        var rb = GetComponent<Rigidbody>();
        var velocity = rb.velocity - VelocityWind;
        var dragForce = -DragCoeff * velocity.sqrMagnitude * velocity.normalized;

        var gravity = Physics.gravity * rb.mass;

        rb.AddForce(dragForce);
        rb.AddForce(gravity);
	}
}
