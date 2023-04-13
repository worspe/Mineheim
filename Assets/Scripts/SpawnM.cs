using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnM : MonoBehaviour
{
    public GameObject[] orePrefabs;
    public GameObject[] oreRare;

    private float spawnDelay;
    public float oreCount;

    // Start is called before the first frame update
    void Start()
    {
        float repeatDelay = Random.Range(5, 10);
        float repeatDelayRare = Random.Range(20, 50);
        InvokeRepeating("Spawner", 0, repeatDelay);
        InvokeRepeating("SpawnerRare", 10, repeatDelayRare);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawner()
    {       
        if (oreCount < 10)
        {
            Spawn();
            oreCount++;

        }
    }void SpawnerRare()
    {
        if (oreCount < 10)
        {
            SpawnRareOre();
            oreCount++;

        }
    }

    void Spawn()
    {
        float xRange = Random.Range(-10, 3);
        float zRange = Random.Range(1, 8);
        float yPos = -0.13f;
        float yRotation = Random.Range(-90, 90);
        int oreIndex = Random.Range(0, orePrefabs.Length);

        Vector3 spawnPos = new Vector3(xRange, yPos, zRange);

        Quaternion spawnRot = Quaternion.Euler(0, yRotation, 0);

        Instantiate(orePrefabs[oreIndex], spawnPos, spawnRot);
    }void SpawnRareOre()
    {
        float xRange = Random.Range(-10, 3);
        float zRange = Random.Range(1, 8);
        float yPos = -0.13f;
        float yRotation = Random.Range(-90, 90);
        int oreIndex = Random.Range(0, orePrefabs.Length);

        Vector3 spawnPos = new Vector3(xRange, yPos, zRange);

        Quaternion spawnRot = Quaternion.Euler(0, yRotation, 0);

        Instantiate(oreRare[0], spawnPos, spawnRot);
    }
}
