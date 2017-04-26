using UnityEngine;
using System.Collections;

public class AirForces : MonoBehaviour {


    public Transform centerOfPressure;
    //float machNumber = 2;
    float dragCoefficient = 0;
    float altitude;
    float atmosphereDensity;
    float atmosphereHeight = 200.0f;
    //We use air density at zero degrees celcius
    float airDensity = 1.2922f;
    public Transform wingObj;

    Rigidbody rb;

    CapsuleCollider noseCol;

    void Start () {
        rb = GetComponent<Rigidbody>();
        noseCol = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        altitude = Mathf.Clamp(transform.position.y, 0, atmosphereHeight);
        Debug.Log(altitude);
        atmosphereDensity = Mathf.Clamp01((altitude / atmosphereHeight));
        //Debug.Log(atmosphereDensity);

        Vector3 lift;
        Vector3 drag;

        float angle;

        float noseArea = Mathf.PI * Mathf.Pow(noseCol.radius, 2);
        float totalWingArea = 0.0f;


        foreach (Transform child in wingObj)
        {
            BoxCollider wingCol = child.GetComponent<BoxCollider>();

            float smallWingArea = (wingCol.bounds.extents.y*wingCol.bounds.extents.z)*2;
            float largeWingArea = (wingCol.bounds.extents.x * wingCol.bounds.extents.z)*2;

            angle = Vector3.Angle(transform.up, child.up);

            float visibleWingArea = Mathf.Lerp(largeWingArea, smallWingArea, Mathf.Sin(angle));

            dragCoefficient += 0.045f;
            totalWingArea += visibleWingArea;
        }

        //add drag for the tip of the rocket
        dragCoefficient += 0.5f;

        float totalArea = noseArea + totalWingArea;

        Vector3 machNumber = -rb.velocity / 343.2f;
        //float machNumber = rb.velocity.magnitude / 343.2f;
        //Debug.Log(machNumber);

        lift = (0.5f * airDensity * rb.velocity.sqrMagnitude * totalArea * machNumber);
        //Debug.Log(lift);
        //drag = -rb.velocity.normalized*((dragCoefficient / 5) * 0.5f * airDensity * rb.velocity.sqrMagnitude * totalArea);
        drag = -0.1f * rb.velocity;
        //Debug.Log(drag);
        //areas of wings found by assuming the top part of the lerp(2, area of wing, sin(angle))
        rb.AddForceAtPosition((drag + lift), centerOfPressure.position);
        //Debug.Log((drag + lift) * atmosphereDensity);




        Debug.DrawRay(transform.position, drag.normalized * 5, Color.red);
        Debug.DrawRay(transform.position, lift.normalized * 5, Color.blue);
    }
}
