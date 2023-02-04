using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletuvierScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    Plane ground = new Plane(Vector3.up, Vector3.zero);
    public int outerLeft;
    public int outerRight;
    List<GameObject> obstacleList = new List<GameObject>();
    public int inventorySize;
    bool throwCoolDownFinished = true;
    public float throwCoolDown;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Camera cam = GameObject.Find("MangroveCamera").GetComponent<Camera>();
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            float distToGround = -1f;

            if (obstacleList.Count < inventorySize) {
                // if click on obs on the beach, add to inventory
                if (Physics.Raycast(ray, out hit) && hit.collider.name.Contains("StaticObstacle")) {
                    GameObject obs = hit.collider.gameObject;
                    if (obs.transform.position.x < transform.position.x) {
                        var beach = GameObject.Find("Beach").GetComponent<BeachScript>().numberSpawned -= 1;
                        obs.transform.position = new Vector3(obs.transform.position.x, obs.transform.position.y - 10, obs.transform.position.z);
                        obstacleList.Add(obs);
                        return;
                    }
                    
                }
            }
            if (throwCoolDownFinished && obstacleList.Count > 0) {
                ground.Raycast(ray, out distToGround);
                Vector3 worldPos = ray.GetPoint(distToGround);
                
                // if click in sea spawn moving obs
                if (worldPos.z >= outerLeft && worldPos.z <= outerRight && worldPos.x >= transform.position.x) {
                    obstacleList[0].transform.position = worldPos;
                    obstacleList[0].GetComponent<ObstacleScript>().vSpeed = 5;
                    obstacleList.RemoveAt(0);
                }
                throwCoolDownFinished = false;
                StartCoroutine(throwCoolDownReload());
            }
        }
    }

    IEnumerator throwCoolDownReload() {
        yield return new WaitForSeconds(throwCoolDown); 
        throwCoolDownFinished = true;
    }
}
