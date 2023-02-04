using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SeaScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    List<GameObject> obsList = new List<GameObject>();
    public int spawnAmountStart = 3;
    public int spawnAmountMiddle = 5;
    public int spawnAmountEnd = 8;
    Vector3 size;


    void Start()
    {
        size = GetComponent<Renderer>().bounds.size;
        SpawningObs(spawnAmountStart - 1, transform.position.x + (size.x / 6f), transform.position.x + (size.x / 2f));
        SpawningObs(spawnAmountMiddle - 1, transform.position.x - (size.x / 6f), transform.position.x + (size.x / 6f));
        SpawningObs(spawnAmountEnd - 1, transform.position.x - (size.x / 2f), transform.position.x - (size.x / 6f));
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
                distance = Mathf.Sqrt(Mathf.Pow( (obs.transform.position.x - randomSpawnPos.x), 2));
                if (distance < 12) {
                    // Random Position is too close
                    if (retry > 0) {
                        retry +=1;
                        i -=1;
                    }
                    break;
                } else if (distance >= 12 && obs == obsList.Last()) {
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
