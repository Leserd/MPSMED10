using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeStars : MonoBehaviour {

    public float lifeTime;
    public float lifeTimeRandomise = 0.2f;
    public float lengthPercent = 1;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        EventManager.Explosion += InitialExplosion;
    }

    private void OnDestroy()
    {
        EventManager.Explosion -= InitialExplosion;
    }

    public void InitialExplosion(int index, Vector3 point, float force)
    {
        if(transform.root.GetComponent<RocketInfo>().fireworksIndex == index)
        {
            rb.AddExplosionForce(force * lengthPercent, point, 1);

            Destroy(gameObject, Random.Range(lifeTime - lifeTimeRandomise, lifeTime + lifeTimeRandomise));
        }   
    }
}

