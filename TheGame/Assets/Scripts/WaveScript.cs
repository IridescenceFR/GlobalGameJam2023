using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WaveScript : MonoBehaviour
{
    public int outerLeft;
    public int outerRight;
    public float hSpeed;
    public float vSpeed;
    public float vSpeedMax;
    public int life = 3;

    public Rigidbody rg;
    public GameManager gm;
    public UIScript ui;

    void Start()
    {
        ui.UpdateLife(life);
    }

    private void FixedUpdate()
    {
        float zAxis = Input.GetAxis("Horizontal");
        if (transform.position.z + zAxis * 0.1f < outerLeft || transform.position.z + zAxis * 0.1f > outerRight)
        {
            rg.velocity = Vector3.left * vSpeed;
        }
        else
        {
            rg.velocity = new Vector3(-1 * vSpeed, 0, zAxis * hSpeed);
        }

        if (vSpeed < vSpeedMax)
        {
            vSpeed += 0.1f;
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Obstacle") {
            GameObject.Find("SoundEffect").GetComponent<TriggerZoneScript>().PlaySoundObstacle();
            Destroy(hit.gameObject);
            life--;
            ui.UpdateLife(life);
            if (vSpeed > 0)
            {
                vSpeed -= 5f;
            }

            if (life < 1)
            {
                gm.OnMangroveWin();
            }
        }

        if (hit.gameObject.tag == "SpawnZone")
        {
            gm.OnWaveWin();
        }
    }
}