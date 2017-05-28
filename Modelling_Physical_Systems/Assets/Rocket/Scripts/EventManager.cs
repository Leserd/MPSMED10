using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void RocketStage(int index);
    public static event RocketStage StartThrust;
    public static event RocketStage StartRamp;
    public static event RocketStage StartFirstExplosion;

    public delegate void RocketExplosion(int index, Vector3 point, float force);
    public static event RocketExplosion Explosion;

    public delegate void RocketSpawn(Transform rocket);
    public static event RocketSpawn SpawnRocket;

    public static EventManager instance;


    private void Awake()
    {
        instance = this;
    }


    public void RocketThrust(int index)
    {
        if(StartThrust != null)
        {
            //Debug.Log("Thrust!");
            StartThrust(index);
        }
    }


    public void NewRocket(Transform rocket)
    {
        if (SpawnRocket != null)
        {
            //Debug.Log("Thrust!");
            SpawnRocket(rocket);
        }
    }

    public void RocketRamp(int index)
    {
        if (StartRamp != null)
        {
           // Debug.Log("Ramp!");
            StartRamp(index);
        }
    }


    public void FirstExplosion(int index)
    {
        if (StartFirstExplosion != null)
        {
            //Debug.Log("FirstExplosion!");
            StartFirstExplosion(index);
        }
    }


    public void StartMovingStars(int index, Vector3 point, float force)
    {
        if (Explosion != null)
        {
           // Debug.Log("Stars should move!");
            Explosion(index, point, force);
        }
    }
}
