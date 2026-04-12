using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    private void Start()
    {
        SpawnSelectedLevel();
    }

    private void SpawnSelectedLevel()
    {
        if (RaceSetupSession.Instance == null)
        {
            Debug.LogError("RaceSetupSession instance not found.");
            return;
        }

        if (RaceSetupSession.Instance.SelectedLevel == null)
        {
            Debug.LogWarning("No selected level found.");
            return;
        }

        GameObject levelPrefab = RaceSetupSession.Instance.SelectedLevel.levelPrefab;

        if (levelPrefab == null)
        {
            Debug.LogWarning("Selected level prefab is missing.");
            return;
        }

        Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
    }
}