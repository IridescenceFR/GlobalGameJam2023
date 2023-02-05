using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Linq;
using Unity.VisualScripting;

public class BeachScript : MonoBehaviour
{
    public float spawnSpeed;
    private float cooldown;
    public List<GameObject> objectToSpawn = new List<GameObject>();

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
        cooldown = spawnSpeed;
    }

    void Update()
    {
        if (numberSpawned < maxSpawned)
        {
            if (cooldown < 0)
            {
                Vector3 randomSpawnPos = new Vector3(
                    Random.Range(min.x, max.x),
                    transform.position.y + 2,
                    Random.Range(min.z, max.z)
                );
                int index = Random.Range(0, objectToSpawn.Count-1);
                Instantiate(objectToSpawn[index], randomSpawnPos, Quaternion.identity);
                numberSpawned += 1;
                cooldown = spawnSpeed;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }
}