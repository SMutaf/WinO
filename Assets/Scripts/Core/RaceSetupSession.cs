using System.Collections.Generic;
using UnityEngine;

public class RaceSetupSession : MonoBehaviour
{
    public static RaceSetupSession Instance { get; private set; }

    public List<RaceObjectConfig> SelectedObjects { get; private set; } = new();
    public LevelData SelectedLevel { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetObjects(List<RaceObjectConfig> objects)
    {
        SelectedObjects.Clear();
        SelectedObjects.AddRange(objects);
    }

    public void SetLevel(LevelData levelData)
    {
        SelectedLevel = levelData;
    }

    public void Clear()
    {
        SelectedObjects.Clear();
        SelectedLevel = null;
    }
}