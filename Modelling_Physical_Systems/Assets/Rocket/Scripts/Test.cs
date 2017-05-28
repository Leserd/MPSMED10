using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Local" + transform.localPosition);
        Debug.Log("Position" + transform.position);
        //Debug.Log("Local" + transform.localPosition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
