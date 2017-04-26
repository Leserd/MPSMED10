using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDectection : MonoBehaviour {
    private SphereCollider collisionSphere = new SphereCollider();
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private GameObject Collided = null;

	// Use this for initialization
	void Start () {
        collisionSphere = gameObject.GetComponent<SphereCollider>();
	}
    void Update()
    {
        if (Collided != null)
        {
                    Collided.transform.position =  Vector3.Lerp(_startPoint, _endPoint, Time.time / (Vector3.Distance(_startPoint, _endPoint)));

        }
    }

    void OnTriggerEnter()
    {
        Debug.Log("Trigger");
        collisionSphere.material.bounciness = 1f;
    }
    void OnCollisionEnter(Collision collName)
    {
        Collided = collName.gameObject;
        _startPoint = collName.gameObject.transform.position;
        _endPoint = _startPoint - new Vector3(0, 2f, 0);

        Debug.Log("Collided");
        gameObject.GetComponent<MeshRenderer>().material.color = RandomColor();
       // collName.gameObject.transform.position = Vector3.Lerp(collName.gameObject.transform.position, (collName.gameObject.transform.position + new Vector3(0, -10f, 0)), Time.deltaTime);
       // collName.gameObject.transform.position -= new Vector3 (0,2f, 0);
    }

    private Color RandomColor()
    {
        var color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        return color;
        //var bla = Random.ColorHSV();
    }
}
