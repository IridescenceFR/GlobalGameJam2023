using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObstacleScript : MonoBehaviour
{
    public float vSpeed;
    public Rigidbody rg;
    public float xMax;
    bool isCurrentlyColliding = false;
 
    private void OnTriggerEnter(Collider hit)
    {
        isCurrentlyColliding = true;
        Debug.Log(isCurrentlyColliding);
    }
    
    private void OnTriggerExit(Collider hit)
    {
        isCurrentlyColliding = false;
        Debug.Log(isCurrentlyColliding);
    }

    void Start()
    {
        var sea = GameObject.Find("Sea");
        Vector3 size = sea.GetComponent<Renderer>().bounds.size;
        xMax = sea.transform.position.x + (size.x / 2f);
    }

    private void FixedUpdate()
    {
        if (!isCurrentlyColliding) {
            Debug.Log("MOVING !!!!!");
            rg.velocity = Vector3.right * vSpeed;
            if (transform.position.x > xMax) {
                Destroy(gameObject);
            }
        }
        
    }

    // public void setVSpeed(float speed) {
    //     vSpeed = speed;
    // }
}
