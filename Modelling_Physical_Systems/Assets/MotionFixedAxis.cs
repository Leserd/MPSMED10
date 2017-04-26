using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionFixedAxis : MonoBehaviour {
    public bool First, Second, Third;
    public Vector3 Center, Axis;
    public float AngularVelocity;
    Vector3 r0;
    float t0;
    Quaternion q0;

	// Use this for initialization
	void Start () {
        r0 = transform.position;
        t0 = Time.fixedTime;
        q0 = transform.rotation;
		
	}
    void FixedUpdate()
    {
        if (First)
        {

            var theta = AngularVelocity * (Time.fixedTime - t0);
            var w = Axis.normalized * AngularVelocity;
            Vector3 u = Vector3.Dot(r0 - Center, w) / w.sqrMagnitude * w;
            Vector3 y = Vector3.Cross(w, r0 - Center);
            y = y.normalized * (r0 - (Center + u)).magnitude;
            transform.position = Center + u + Mathf.Cos(theta) * (r0 - (Center + u)) + Mathf.Sin(theta) * y;
        }

        if (Second)
        {
            var theta = AngularVelocity * (Time.fixedTime - t0);
            transform.position = r0;
            transform.rotation = q0;
            transform.RotateAround(Center, Axis, theta * 180f / Mathf.PI);
        }

        if (Third)
        {
            var deltaTheta = AngularVelocity * Time.fixedDeltaTime;
            transform.RotateAround(Center, Axis, deltaTheta * 180f / Mathf.PI);
        }
    }

}
