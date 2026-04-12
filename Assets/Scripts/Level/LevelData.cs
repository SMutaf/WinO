using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    public string levelId;
    public string displayName;
    public Sprite previewImage;
    public GameObject levelPrefab;
}