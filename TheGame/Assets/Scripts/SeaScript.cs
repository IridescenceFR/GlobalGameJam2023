using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SeaScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    public List<GameObject> obsList = new List<GameObject>();
    Vector3 size;


    void Start()
    {
        size = GetComponent<Renderer>().bounds.size;
        SpawningObs(2, transform.position.x + (size.x / 3f), transform.position.x + (size.x / 2f));
        SpawningObs(4, transform.position.x - (size.x / 6f), transform.position.x + (size.x / 6f));
        SpawningObs(7, transform.position.x - (size.x / 3f), transform.position.x - (size.x / 2f));
    }

    private void SpawningObs(int amount, float minRange, float maxRange)
    {
        bool isGoingForward;
        var random = new System.Random();
        float distance = 0f;

        for (int i = 0; i < amount; i+= 1) {
            int retry = 3;
            isGoingForward = random.Next(2) == 1;

            Vector3 randomSpawnPos = new Vector3(
                Random.Range(minRange, maxRange),
                0,
                (isGoingForward? transform.position.z - size.z : transform.position.z + size.z)
            );

            if (obsList.Count == 0) {
                    var newObs = Instantiate(objectToSpawn, randomSpawnPos, Quaternion.identity);
                    newObs.GetComponent<MovingObstacleScript>().isGoingForward = isGoingForward;
                    
                    // Add to our list
                    obsList.Add(newObs);
            }

            foreach(GameObject obs in obsList) {
                // Calculate the distance between our Random Position and each obstacle from our list
                distance = Mathf.Sqrt( Mathf.Pow( (obs.transform.position.x - randomSpawnPos.x), 2) + Mathf.Pow( (obs.transform.position.z - randomSpawnPos.z), 2));
                if (distance < 12) {
                    // Random Position is too close
                    if (retry > 0) {
                        retry +=1;
                        i -=1;
                    }
                    break;
                } else if (distance >= 12 && obs == obsList.Last()) {
                    Debug.Log(retry);
                    var newObs = Instantiate(objectToSpawn, randomSpawnPos, Quaternion.identity);
                    newObs.GetComponent<MovingObstacleScript>().isGoingForward = isGoingForward;
                    
                    // Add to our list
                    obsList.Add(newObs);
                    break;
                }
            }
            
        }
    }
}
