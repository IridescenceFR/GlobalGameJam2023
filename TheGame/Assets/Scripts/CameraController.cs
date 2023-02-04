using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public Quaternion rotation;
    // Update is called once per frame
    private void Update()
    {
        // Follow the player with the offset.
        transform.position = target.position + offset;
        transform.rotation = rotation;
    }
}
