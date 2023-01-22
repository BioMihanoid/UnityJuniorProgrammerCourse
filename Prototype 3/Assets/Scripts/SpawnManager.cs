using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private int indexObstacle;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
            
    }

    void SpawnObstacle()
    {
        indexObstacle = Random.RandomRange(0, obstaclePrefabs.Length);

        if (!playerControllerScript.gameOver)
            Instantiate(obstaclePrefabs[indexObstacle], spawnPos, obstaclePrefabs[indexObstacle].transform.rotation);
    }
}
