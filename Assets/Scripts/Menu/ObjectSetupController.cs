using UnityEngine;

public class ObjectSetupController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform objectListContainer;
    [SerializeField] private ObjectConfigItemView objectConfigItemPrefab;

    private int objectCount = 0;

    public void AddObjectConfigItem()
    {
        objectCount++;

        ObjectConfigItemView newItem = Instantiate(objectConfigItemPrefab, objectListContainer);
        newItem.Initialize(objectCount);
    }
}