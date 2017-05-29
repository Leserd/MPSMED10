using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketInfo : MonoBehaviour {

   // public static RocketInfo instance;
    public List<RocketPart> rocketObjects;
    public Transform thrustPos, centerOfGravityPos;
    public Rigidbody rb;
    public int fireworksIndex;

    private float totalWeight;



    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {
        rb.mass = TotalWeight();
    }



    public float TotalWeight()
    {
        totalWeight = 0;

        foreach (RocketPart part in rocketObjects)
        {
            totalWeight += part.weight;
        }
        
        return totalWeight;
    }
}

[System.Serializable]
public struct RocketPart
{
    public Transform part;
    public float weight;
}