using UnityEngine;

public class RaceSceneSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private GameObject squarePrefab;

    [Header("Spawn")]
    [SerializeField] private Transform spawnPoint;

    [Header("Spawn Settings")]
    [SerializeField] private float horizontalSpread = 1.5f;
    [SerializeField] private float verticalSpacing = 0.8f;

    private void Start()
    {
        SpawnConfiguredObjects();
    }

    private void SpawnConfiguredObjects()
    {
        if (RaceSetupSession.Instance == null)
        {
            Debug.LogError("RaceSetupSession instance not found.");
            return;
        }

        var objects = RaceSetupSession.Instance.SelectedObjects;

        if (objects == null || objects.Count == 0)
        {
            Debug.LogWarning("No configured objects found. Nothing will be spawned.");
            return;
        }

        for (int i = 0; i < objects.Count; i++)
        {
            RaceObjectConfig config = objects[i];

            GameObject prefabToSpawn = config.shape == ShapeType.Circle
                ? circlePrefab
                : squarePrefab;

            Vector3 spawnOffset = new Vector3(
                Random.Range(-horizontalSpread, horizontalSpread),
                (i * verticalSpacing),
                0f
            );

            GameObject spawned = Instantiate(prefabToSpawn, spawnPoint.position + spawnOffset, Quaternion.identity);

            SpriteRenderer spriteRenderer = spawned.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = config.color;
            }
        }
    }
}