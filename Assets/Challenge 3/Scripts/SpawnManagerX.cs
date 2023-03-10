using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    /* public GameObject[] objectPrefabs;
     private float spawnDelay = 2;
     private float spawnInterval = 1.5f;

     private PlayerControllerX playerControllerScript;

     // Start is called before the first frame update
     void Start()
     {
         InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
         playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
     }

     // Spawn obstacles
     void SpawnObjects ()
     {
         // Set random spawn location and random object index
         Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
         int randomidx = Random.Range(0, objectPrefabs.Length);

         // If game is still active, spawn new object
         if (!playerControllerScript.gameOver)
         {
             Instantiate(objectPrefabs[randomidx], spawnLocation, objectPrefabs[randomidx].transform.rotation);
         }

     } */

    public GameObject[] obstaclePrefab;
    private float startDelay = 2;
    private float repeatRate = 1.5f;

    private float spawnRangeY = 4f;
    private float spawnPosX = 19f;

    private PlayerControllerX playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = FindObjectOfType<PlayerControllerX>();
      
    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }
    private void SpawnObstacle()
    {
        int randomIdx = Random.Range(0, obstaclePrefab.Length);
        

        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab[randomIdx], RandomSpawnPos(), obstaclePrefab[randomIdx].transform.rotation);
        }
                 
    }

    private Vector3 RandomSpawnPos()
    {
        //float randomX = Random.Range(-spawnRangeY, spawnRangeY);
        float randomX = Random.Range(2, 16);
        return new Vector3(spawnPosX, randomX, 0);
    }
}
