using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset;
    public Transform rocket;
    public int fireworksIndex;

    private void Awake()
    {
        offset = transform.position;
        EventManager.SpawnRocket += NewRocket;
        EventManager.StartFirstExplosion += StopFollowing;
    }

	
    private void NewRocket(Transform rocket)
    {
        this.rocket = rocket;
        fireworksIndex = rocket.GetComponent<RocketInfo>().fireworksIndex;
    }


    private void StopFollowing(int index)
    {
        if(index == fireworksIndex)
        {
            this.rocket = null;
        }
    }

	// Update is called once per frame
	void Update () {
        if(rocket != null)
        {
            transform.position = Vector3.Lerp(transform.position, rocket.position + offset, Time.deltaTime * 1000);
        }
    }
}
