using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovingObstacleScript : ObstacleScript
{
    public float hSpeed;
    public float zMax;
    public bool isGoingForward = true; 

    void Start()
    {
        var sea = GameObject.Find("Sea");
        Vector3 size = sea.GetComponent<Renderer>().bounds.size;
        zMax = isGoingForward ? sea.transform.position.z + size.z : sea.transform.position.z - size.z;
    }

    private void FixedUpdate()
    {
        if (isGoingForward) {
            rg.velocity = Vector3.forward * hSpeed;
            if (transform.position.z > zMax) {
                Destroy(gameObject);
            }
        } else {
            rg.velocity = Vector3.back * hSpeed;
            if (transform.position.z < zMax) {
                Destroy(gameObject);
            }
        }
    }
}
