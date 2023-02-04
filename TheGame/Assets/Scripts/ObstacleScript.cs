using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObstacleScript : MonoBehaviour
{
    public float vSpeed;
    public Rigidbody rg;
    float xMax;
    bool isCurrentlyColliding = false;
 
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "MovingObstacle") {
            isCurrentlyColliding = true;
        }
    }
    
    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "MovingObstacle") {
            isCurrentlyColliding = false;
        }
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
            rg.velocity = Vector3.right * vSpeed;
            if (transform.position.x > xMax) {
                Destroy(gameObject);
            }
        } else {
            rg.velocity = Vector3.zero;
        }
        
    }
}
