using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject starsObject;
    public float explosionForce;
    public Transform explosionPosition;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        EventManager.StartFirstExplosion += Explode;
    }

    private void OnDestroy()
    {
        EventManager.StartFirstExplosion -= Explode;

    }

    private void Explode(int index)
    {
        if(index == GetComponent<RocketInfo>().fireworksIndex)
        {
            starsObject.SetActive(true);
            
            Debug.Log("Explode");
            EventManager.instance.StartMovingStars(index, explosionPosition.position, explosionForce);
            //ri.GetComponent<TrailRenderer>().enabled = false;
            Destroy(gameObject, 6f);
        }
    }

}
