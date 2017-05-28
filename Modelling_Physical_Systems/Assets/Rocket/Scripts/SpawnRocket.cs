using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocket : MonoBehaviour {

    public GameObject[] rocketPrefab;
    public float angleRandomise = 35f;
    public int curFireworksIndex = 0;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject rocket = GameObject.Instantiate(rocketPrefab[Random.Range((int)0, (int)2)], new Vector3(0, 1, 0), Quaternion.identity);
            Vector3 rot = rocket.transform.rotation.eulerAngles;

            float x = Random.Range(rot.x - angleRandomise, rot.x + angleRandomise);
            float y = Random.Range(rot.y - angleRandomise, rot.y + angleRandomise);
            float z = Random.Range(rot.z - angleRandomise, rot.z + angleRandomise);

            rocket.transform.Rotate(new Vector3(x, y, z));

            rocket.GetComponent<RocketInfo>().fireworksIndex = curFireworksIndex;
            EventManager.instance.NewRocket(rocket.transform);

            curFireworksIndex++;
        }
	}
}
