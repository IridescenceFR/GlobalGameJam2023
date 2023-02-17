using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObstacleScript : MonoBehaviour
{
    public bool moving = false;
    public float vSpeed;
    public float vSpeedMax;
    public Rigidbody rg;
    public float outerLeft;
    public float outerRight;
    public Vector3 offset;
    public GameObject tree;
    public GameObject sea;
    public Collider cl;
    public bool isABoat = false;

    private void FixedUpdate()
    {
        if (moving)
        {
            var wave = GameObject.Find("Wave");
            float distanceWave = Mathf.Sqrt(Mathf.Pow((wave.transform.position.x - transform.position.x), 2));
            float distanceTree = Mathf.Sqrt(Mathf.Pow((tree.transform.position.x - transform.position.x), 2));

            if (distanceWave > 70 && distanceTree > 20) {
                cl.isTrigger = true;
                rg.velocity = Vector3.right * vSpeedMax;
            } else {
                cl.isTrigger = false;
                rg.velocity = Vector3.right * vSpeed;
            }

            if (transform.position.x > wave.transform.position.x + 5)
            {
                Destroy(gameObject);
            }

            if (transform.position.z - offset.z < outerLeft)
            {
                transform.position += offset;
            }
            else if (transform.position.z + offset.z > outerRight)
            {
                transform.position -= offset;
            }
        }
        else if(isABoat == true)
        {
            if(transform.position.z < 15)
            {
                rg.velocity = Vector3.forward * vSpeed;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetMovingTrue()
    {
        moving = true;
        cl.isTrigger = false;
    }
}