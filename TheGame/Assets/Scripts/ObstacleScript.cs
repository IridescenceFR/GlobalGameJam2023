using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObstacleScript : MonoBehaviour
{
    public bool moving = false;
    public float vSpeed;
    public Rigidbody rg;
    public float xMax;
    public float outerLeft;
    public float outerRight;
    public Vector3 offset;

    public GameObject sea;

    private void FixedUpdate()
    {
        if (moving)
        {
            rg.velocity = Vector3.right * vSpeed;
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}