using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);    
    }

    void Update()
    {

    }

    void SpawnRandomAnimals()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalsPrefabs.Length);
        Instantiate(animalsPrefabs[animalIndex], spawnPos, animalsPrefabs[animalIndex].transform.rotation);
    }
}
