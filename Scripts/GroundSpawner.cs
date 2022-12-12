using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity); // spawning the ground tile
        nextSpawnPoint = temp.transform.GetChild(1).transform.position; // updating the next spawn point

        if (spawnItems)
        {
            // spawning obstacles and coins from the GroundTile script
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true); // spawning obstacles and coins only after the first 3 ground tiles
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
