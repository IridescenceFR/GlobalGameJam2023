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
        rg.velocity = Vector3.left * vSpeed;
    }
}
