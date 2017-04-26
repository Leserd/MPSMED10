using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotentialKineticEnergi : MonoBehaviour {

    Rigidbody rigid;
   public float Etotal;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        Etotal = 0.5f * rigid.mass *  rigid.velocity.sqrMagnitude -rigid.mass * Physics.gravity.y * transform.position.y;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var speed = Mathf.Sqrt((2 / rigid.mass) * (Etotal + rigid.mass * Physics.gravity.y * transform.position.y));

        if (rigid.velocity.magnitude > 0.0005f)
        {
            rigid.velocity = rigid.velocity / rigid.velocity.magnitude * speed;

        }


	}
}
