using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CrocoScript : MonoBehaviour
{
    public float hSpeed;
    public float zMin;
    public float zMax;
    public bool isGoingForward = true;
    public Rigidbody rg;
    public SpriteRenderer sr;

    private void Start()
    {
        hSpeed = Random.Range(3,7);
    }

    private void FixedUpdate()
    {
        if (isGoingForward) {
            rg.velocity = Vector3.forward * hSpeed;
            sr.flipX = false;
            if (transform.position.z > zMax) {
                isGoingForward = !isGoingForward;
            }
        } else {
            rg.velocity = Vector3.back * hSpeed;
            sr.flipX = true;
            if (transform.position.z < zMin) {
                isGoingForward = !isGoingForward;
            }
        }
    }
}
