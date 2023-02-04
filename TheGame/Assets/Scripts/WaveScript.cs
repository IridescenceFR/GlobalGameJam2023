using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WaveScript : MonoBehaviour
{
    public float outerLeft;
    public float outerRight;
    public float hSpeed;
    public float vSpeed;

    public Rigidbody rg;

    private void FixedUpdate()
    {
        float zAxis= Input.GetAxis("Horizontal");
        if (transform.position.z + zAxis < outerLeft || transform.position.z + zAxis > outerRight) {
            rg.velocity = new Vector3(-1 * vSpeed, 0, 0);
        } else {
            rg.velocity = new Vector3(-1 * vSpeed, 0, zAxis * hSpeed);
        }
    }
}
