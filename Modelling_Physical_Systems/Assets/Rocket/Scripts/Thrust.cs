using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {
    public float thrustTime = 1.5f;
    public float rampTime = 2f;
    public float thrustForce = 50;
    public float torqueForce = 5;
    public float timeBeforeExplode = 1.5f;
    private RocketInfo ri;
    private Transform thrustPos;
    private Rigidbody rb;
    private float startTime;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        EventManager.StartThrust += StartThrust;
        EventManager.StartRamp += StartRamp;
        ri = GetComponent<RocketInfo>();
        thrustPos = ri.thrustPos;
    }

    private void Start()
    {
        //EventManager.instance.RocketRamp(GetComponent<RocketInfo>().fireworksIndex);
        StartRamp(ri.fireworksIndex);
    }

    private void OnDestroy()
    {
        EventManager.StartThrust -= StartThrust;
        EventManager.StartRamp -= StartRamp;
    }

    private void StartThrust(int index)
    {
        if(index == ri.fireworksIndex)
        {
            StartCoroutine(ThrustCoroutine());
        }
    }


    private void StartRamp(int index)
    {
        if (index == ri.fireworksIndex)
        {
            StartCoroutine(RampCoroutine());
        }
    }


    private IEnumerator RampCoroutine()
    {
        yield return new WaitForSeconds(rampTime);

        StartThrust(ri.fireworksIndex);
        //EventManager.instance.RocketThrust(ri.fireworksIndex);
    }


    private IEnumerator ThrustCoroutine()
    {
        startTime = Time.time;
        float endTime = startTime + thrustTime;

        while (Time.time < endTime)
        {
            rb.AddForceAtPosition(thrustPos.up * thrustForce, thrustPos.position);
            rb.AddRelativeTorque(new Vector3(0, torqueForce, 0));

            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(timeBeforeExplode);
        ri.thrustPos.GetComponent<TrailRenderer>().enabled = false;
        EventManager.instance.FirstExplosion(ri.fireworksIndex);        
    }

}
