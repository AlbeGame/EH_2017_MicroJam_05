using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour {

    public float MinSpawnTime = 5f;
    public float MaxSpawnTime = 15f;

    public GameObject MeteorPrefab;

    float currentSpawnDelay;

    private void Start()
    {
        currentSpawnDelay = Random.Range(MinSpawnTime, MaxSpawnTime);
    }

    private void Update()
    {
        currentSpawnDelay -= Time.deltaTime;
        if(currentSpawnDelay < 0)
        {
            SpawnMeteor();
        }
    }

    void SpawnMeteor()
    {
        Instantiate(MeteorPrefab, transform.position, Quaternion.identity, transform);
        currentSpawnDelay = Random.Range(MinSpawnTime, MaxSpawnTime);
    }
}
