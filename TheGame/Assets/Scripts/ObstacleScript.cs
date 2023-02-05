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
    public float xMax;
    public float outerLeft;
    public float outerRight;
    public Vector3 offset;
    public GameObject tree;
    public GameObject sea;

    private void FixedUpdate()
    {
        if (moving)
        {
            var wave = GameObject.Find("Wave");
            float distanceWave = Mathf.Sqrt(Mathf.Pow((wave.transform.position.x - transform.position.x), 2));
            float distanceTree = Mathf.Sqrt(Mathf.Pow((tree.transform.position.x - transform.position.x), 2));

            if (distanceWave > 20 && distanceTree > 10) {
                Debug.Log(distanceWave);
                Debug.Log("FAST");
                rg.velocity = Vector3.right * vSpeedMax;
            } else {
                // Debug.Log(distanceWave);
                Debug.Log("SLOW");
                rg.velocity = Vector3.right * vSpeed;
            }

            if (transform.position.x > xMax)
            {
                Destroy(gameObject);
            }

            if (transform.position.z - offset.z < outerLeft)
            {
                transform.position += offset + Vector3.right;
            }
            else if (transform.position.z + offset.z > outerRight)
            {
                transform.position -= offset + Vector3.right;
            }
        }
    }

    public void SetMovingTrue()
    {
        moving = true;
    }
}