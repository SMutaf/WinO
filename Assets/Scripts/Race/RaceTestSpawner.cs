using System.Collections.Generic;
using UnityEngine;

public class RaceTestSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private GameObject squarePrefab;

    [Header("Spawn")]
    [SerializeField] private Transform spawnPoint;

    [Header("Test Counts")]
    [SerializeField] private int circleCount = 3;
    [SerializeField] private int squareCount = 2;

    [Header("Spawn Spread")]
    [SerializeField] private float horizontalSpread = 1.5f;
    [SerializeField] private float verticalSpacing = 0.6f;

    public List<Transform> SpawnedObjects { get; } = new();

    private void Start()
    {
        SpawnTestObjects();
    }

    private void SpawnTestObjects()
    {
        int spawnedIndex = 0;

        for (int i = 0; i < circleCount; i++)
        {
            Spawn(circlePrefab, spawnedIndex);
            spawnedIndex++;
        }

        for (int i = 0; i < squareCount; i++)
        {
            Spawn(squarePrefab, spawnedIndex);
            spawnedIndex++;
        }
    }

    private void Spawn(GameObject prefab, int index)
    {
        if (prefab == null || spawnPoint == null)
        {
            Debug.LogWarning("Prefab or SpawnPoint is missing.");
            return;
        }

        Vector3 spawnOffset = new Vector3(
            Random.Range(-horizontalSpread, horizontalSpread),
            -(index * verticalSpacing),
            0f
        );

        GameObject spawned = Instantiate(prefab, spawnPoint.position + spawnOffset, Quaternion.identity);
        SpawnedObjects.Add(spawned.transform);
    }
}