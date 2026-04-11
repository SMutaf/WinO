using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ContinueToRace()
    {
        if (RaceSetupSession.Instance == null)
        {
            Debug.LogError("RaceSetupSession instance not found.");
            return;
        }

        List<RaceObjectConfig> configs = new();

        foreach (Transform child in objectListContainer)
        {
            ObjectConfigItemView itemView = child.GetComponent<ObjectConfigItemView>();

            if (itemView != null)
            {
                configs.Add(itemView.GetConfig());
            }
        }

        RaceSetupSession.Instance.SetObjects(configs);
        SceneManager.LoadScene("Race");
    }
}