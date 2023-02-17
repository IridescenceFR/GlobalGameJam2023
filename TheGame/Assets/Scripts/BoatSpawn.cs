using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawn : MonoBehaviour
{
    
    public GameObject boatPrefab;
    private GameObject actualBoat;

    public float spawnRate;

    void FixedUpdate()
    {
        if(Random.value < spawnRate)
        {
            actualBoat = Instantiate(boatPrefab, transform.position + (Vector3.up * 0.3f), Quaternion.identity);       
        }
    }
}
