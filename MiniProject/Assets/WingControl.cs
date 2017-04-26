using UnityEngine;
using System.Collections;

public class WingControl : MonoBehaviour {

    public float maxAngle = 45.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 rotationAxis = Vector3.Cross(transform.parent.up,Vector3.up);
        //print(rotationAxis);

        //GimbalWings(rotationAxis);
	}

    void GimbalWings(Vector3 rotationAxis)
    {
        if (rotationAxis != Vector3.zero)
        {
            foreach (Transform child in transform)
            {

                float wingAngle = Vector3.Angle(child.up, rotationAxis);
                wingAngle = Mathf.Clamp(wingAngle, 0, maxAngle);

                float rotationAmount = Time.deltaTime * Mathf.Sin(Vector3.Angle(transform.parent.up, Vector3.up));

                child.Rotate(Vector3.forward, Mathf.LerpAngle(0, wingAngle, rotationAmount));

            }
        }
    }
}
