using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RaceTestSpawner raceTestSpawner;

    [Header("Follow Settings")]
    [SerializeField] private float smoothSpeed = 4f;
    [SerializeField] private float yOffset = -2f;
    [SerializeField] private bool neverMoveUp = true;

    private float currentLowestY;

    private void Start()
    {
        currentLowestY = transform.position.y;
    }

    private void LateUpdate()
    {
        if (raceTestSpawner == null || raceTestSpawner.SpawnedObjects.Count == 0)
            return;

        Transform leader = GetLowestObject(raceTestSpawner.SpawnedObjects);

        if (leader == null)
            return;

        float targetY = leader.position.y + yOffset;

        if (neverMoveUp)
        {
            targetY = Mathf.Min(currentLowestY, targetY);
        }

        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        currentLowestY = transform.position.y;
    }

    private Transform GetLowestObject(List<Transform> objects)
    {
        Transform lowest = null;
        float lowestY = float.MaxValue;

        foreach (Transform obj in objects)
        {
            if (obj == null)
                continue;

            if (obj.position.y < lowestY)
            {
                lowestY = obj.position.y;
                lowest = obj;
            }
        }

        return lowest;
    }
}