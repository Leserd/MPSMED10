using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset;
    public Transform rocket;

    private void Awake()
    {
        offset = transform.position;
    }

	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, rocket.position + offset, Time.deltaTime * 1000);
	}
}
