using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2); // Destroying the tile after player has passed to save memory
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    public void SpawnObstacle()
    {
        //choosing a random point to spawn obstacle
        int spawnObstacleIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(spawnObstacleIndex).transform;
        //spawning the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    public void SpawnCoins()
    {
        int coinsToSpawn = 10; // spawning ten coins in one ground tile
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>()); // getting the random point to spawn coin
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            ); // choosing a random point to spawn coin
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider); // making sure two coins don't spawn at the same point
        }

        point.y = 1;
        return point;
    }
}
