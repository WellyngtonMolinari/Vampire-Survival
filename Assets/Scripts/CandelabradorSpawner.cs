using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandelabradorSpawner : MonoBehaviour
{
    public GameObject candelabradorPrefab;
    public float spawnDelay = 10f;
    public float spawnRadius = 10f;

    private float spawnTimer;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnDelay;
        playerTransform = PlayerController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnCandelabrador();
            spawnTimer = spawnDelay;
        }
    }

    private void SpawnCandelabrador()
    {
        Vector3 spawnPosition = GetSpawnPosition();
        Instantiate(candelabradorPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnOffset = new Vector3(randomCircle.x, randomCircle.y, 0f);
        Vector3 spawnPosition = playerTransform.position + spawnOffset;
        return spawnPosition;
    }
}
