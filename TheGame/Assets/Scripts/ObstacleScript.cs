using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObstacleScript : MonoBehaviour
{
    public float vSpeed;

    public Rigidbody rg;

    private void FixedUpdate()
    {
        rg.velocity = Vector3.right * vSpeed;
    }
}
