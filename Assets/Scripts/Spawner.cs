using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnee;
    public bool stopSpawning = false;
    public Vector3 radius;
    public int numEnemies;
    public float spawnDelay;

    public void SpawnObject()
    {
        int numSpawn = numEnemies;
        while (numSpawn > 0)
        {
            Vector3 nSpawnPoint = spawnPoint.position + new Vector3(Random.Range(-radius.x, radius.x), 0, Random.Range(-radius.z, radius.z));
            Instantiate(spawnee, nSpawnPoint, spawnPoint.rotation);
            numSpawn -= 1;
        }
    }

    public virtual void OnTriggerEnter()
    {
        if (!stopSpawning)
        {
            InvokeRepeating("SpawnObject", 0f, spawnDelay);
        }
    }

    public virtual void OnTriggerExit() => CancelInvoke("SpawnObject");

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawCube(spawnPoint.position, radius * 2);
    }
}