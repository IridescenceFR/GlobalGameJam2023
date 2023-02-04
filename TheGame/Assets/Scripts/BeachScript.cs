using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Linq;

public class BeachScript : MonoBehaviour
{
    public float spawnSpeed;
    public GameObject objectToSpawn;
    Vector3 size;
    Vector3 min;
    Vector3 max;
    public int maxSpawned;
    public int numberSpawned = 0;

    void Start()
    {
        size = GetComponent<Renderer>().bounds.size;
        min = new Vector3(transform.position.x - (size.x / 2f) + 1.5f, 0, transform.position.z - (size.z / 2f) + 1.5f);
        max = new Vector3(transform.position.x + (size.x / 2f) - 1.5f, 0, transform.position.z + (size.z / 2f) - 1.5f);
        StartCoroutine(spawnObstacles());
    }

    IEnumerator spawnObstacles() {
        while (true) {
            if (numberSpawned < maxSpawned) {
                Vector3 randomSpawnPos = new Vector3(
                    Random.Range(min.x, max.x),
                    0,
                    Random.Range(min.z, max.z)
                );
                Instantiate(objectToSpawn, randomSpawnPos, Quaternion.identity);
                numberSpawned +=1;
            }
            yield return new WaitForSeconds(spawnSpeed);
        }    
    }
}
