using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBall : MonoBehaviour {
    public Vector3 Velocity;
    public bool NoRigid, RigidKinematic, RigidNonKinematic;


    void FixedUpdate()
    {

        //no rigidbody
        if (NoRigid)
        {
            transform.position = transform.position + Velocity * Time.fixedDeltaTime;
        }
        //if rigidbody and kinematic
        if(RigidKinematic)GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Velocity * Time.fixedDeltaTime);

        //unchecked kinematic
        if(RigidNonKinematic)GetComponent<Rigidbody>().velocity = Velocity;
    }
}
