using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupStars : MonoBehaviour {
    public GameObject starLongPrefab, starShortPrefab;
    public Transform starParent;
    public int starAmount;
    public float sphereRadius;


    private void Awake()
    {
        for(int i = 0; i < starAmount; i++)
        {
            SpawnInSphereShort();
            SpawnInSphereLong();
        }
    }



    public void SpawnInSphereLong()
    {
        Vector3 spawnPosition = Random.onUnitSphere * sphereRadius + starParent.position;
        GameObject newStar = Instantiate(starLongPrefab, spawnPosition, Quaternion.identity) as GameObject;
        newStar.transform.parent = starParent;
    }

    public void SpawnInSphereShort()
    {
        Vector3 spawnPosition = Random.onUnitSphere * sphereRadius / 2 + starParent.position;
        GameObject newStar = Instantiate(starShortPrefab, spawnPosition, Quaternion.identity) as GameObject;
        newStar.transform.parent = starParent;
    }
}
