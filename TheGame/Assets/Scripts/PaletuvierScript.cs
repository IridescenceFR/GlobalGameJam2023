using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaletuvierScript : MonoBehaviour
{
    public int outerLeft;
    public int outerRight;
    List<GameObject> obstacleList = new List<GameObject>();
    public int inventorySize;
    public float throwCoolDown;
    private float cooldown;
    public Camera cam;
    public BeachScript beach;
    public UIScript ui;

    void Start()
    {
        ui.UpdateInventaire(obstacleList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Obstacle" && obstacleList.Count < inventorySize &&
                    !hit.collider.gameObject.GetComponent<ObstacleScript>().moving)
                {
                    GameObject obs = hit.collider.gameObject;
                    beach.numberSpawned -= 1;
                    obs.transform.position += (Vector3.down+ Vector3.left) * 10;
                    obstacleList.Add(obs);
                    ui.UpdateInventaire(obstacleList.Count);
                }
                else if (hit.collider.gameObject.tag == "SpawnZone")
                {
                    if (cooldown < 0 && obstacleList.Count > 0)
                    {
                        Vector3 spawnCoord = new Vector3(hit.point.x,0,hit.point.z);
                        obstacleList[0].transform.position = spawnCoord;
                        obstacleList[0].GetComponent<ObstacleScript>().SetMovingTrue();
                        obstacleList.RemoveAt(0);
                        ui.UpdateInventaire(obstacleList.Count);
                        cooldown = throwCoolDown;
                    }
                }
            }
        }
        cooldown -= Time.deltaTime;

        /*if (obstacleList.Count < inventorySize) {
            // if click on obs on the beach, add to inventory
            if (Physics.Raycast(ray, out hit) && !hit.collider.GetComponent<ObstacleScript>().moving) {
                GameObject obs = hit.collider.gameObject;
                if (obs.transform.position.x < transform.position.x) {
                    var beach = GameObject.Find("Beach").GetComponent<BeachScript>().numberSpawned -= 1;
                    obs.transform.position = new Vector3(obs.transform.position.x, obs.transform.position.y - 10, obs.transform.position.z);
                    obstacleList.Add(obs);
                    return;
                }
                
            }
        }
        if (cooldown < 0 && obstacleList.Count > 0) {
            ground.Raycast(ray, out distToGround);
            Vector3 worldPos = ray.GetPoint(distToGround);
            
            // if click in sea spawn moving obs
            if (worldPos.z >= outerLeft && worldPos.z <= outerRight && worldPos.x >= transform.position.x) {
                obstacleList[0].transform.position = worldPos;
                obstacleList[0].GetComponent<ObstacleScript>().moving = true;
                obstacleList.RemoveAt(0);
            }
            
            cooldown = throwCoolDown;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }*/
    }
}