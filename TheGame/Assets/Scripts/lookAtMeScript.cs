using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtMeScript : MonoBehaviour
{
    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(rotation.x,rotation.y,rotation.z,Space.Self);
    }
}
