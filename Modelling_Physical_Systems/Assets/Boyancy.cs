using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyancy : MonoBehaviour {
    public float Radius;
    public float submergedVolume;
    public float DensityFluid;
    Rigidbody _rigid;
    

	// Use this for initialization
	void Start () {
        _rigid = GetComponent<Rigidbody>();

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Radius = GetComponent<SphereCollider>().radius;

        
        if (transform.position.y >Radius)
        {
            submergedVolume = 0.0f;
            //is above water
        }
        else if (transform.position.y > 0f)
        {
            submergedVolume = NotThatSubmerged();
        }
        else if (transform.position.y > -Radius)
        {
            submergedVolume = MostlySubmerged();
        }
        else
        {
            submergedVolume = Submerged();
        }
        _rigid.AddForce(-Physics.gravity.y * DensityFluid * submergedVolume*Vector3.up);
	}


    float Submerged()
    {
        var volume =( 4 / 3) * Mathf.PI * Mathf.Pow(Radius,3.0f);
        return volume;
    }

    float MostlySubmerged()
    {
        var height = Radius - transform.position.y;
        var volume2 = (Mathf.PI * height * height) / 3 * (3 * Radius - height);
        return volume2 -Submerged();
    }
    float NotThatSubmerged()
    {
        var height = Radius - transform.position.y;
        var volume2 = (Mathf.PI * height * height) / 3 * (3 * Radius - height);
        return volume2;

    }

}
