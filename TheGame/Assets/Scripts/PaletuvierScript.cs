using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletuvierScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(objectToSpawn, transform.position + Vector3.right, Quaternion.identity);
        }   
    }
}
