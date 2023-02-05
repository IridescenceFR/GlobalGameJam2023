using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CrocoScript : MonoBehaviour
{
    public float hSpeed;
    float zMin;
    float zMax;
    public bool isGoingForward = true;
    public Rigidbody rg;

    void Start()
    {
        var sea = GameObject.Find("Sea");
        Vector3 size = sea.GetComponent<Renderer>().bounds.size;
        zMin = sea.transform.position.z - size.z;
        zMax = sea.transform.position.z + size.z;
    }

    private void FixedUpdate()
    {
        if (isGoingForward) {
            rg.velocity = Vector3.forward * hSpeed;
            if (transform.position.z > zMax) {
                transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                isGoingForward = !isGoingForward;
            }
        } else {
            rg.velocity = Vector3.back * hSpeed;
            if (transform.position.z < zMin) {
                transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                isGoingForward = !isGoingForward;
            }
        }
    }
}
