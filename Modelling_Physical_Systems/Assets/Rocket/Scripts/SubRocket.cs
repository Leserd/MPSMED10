using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRocket : MonoBehaviour {

	private void Awake () {
        RocketExplostion.Explode += OnRocketExplosion;
        transform.position += new Vector3(Random.Range(-.25f, 0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));


    }
	


    private void OnRocketExplosion(Vector3 centerExplosion)
    {
        Debug.Log("start event");
        RocketExplostion.Explode -= OnRocketExplosion;

        GetComponent<Rigidbody>().AddExplosionForce(80f, centerExplosion, 0);
        Invoke("Explode", 1.3f);
    }


    private void Explode()
    {
        Debug.Log("Subrocket explde");
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        Destroy(gameObject, 2);

    }

}
