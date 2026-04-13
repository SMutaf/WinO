using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSetupController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform objectListContainer;
    [SerializeField] private ObjectConfigItemView objectConfigItemPrefab;

    [Header("Popups")]
    [SerializeField] private ShapeSelectionPopup shapeSelectionPopup;
    [SerializeField] private TextureSelectionPopup textureSelectionPopup;

    private int objectCount = 0;

    public void AddObjectConfigItem()
    {
        objectCount++;

        ObjectConfigItemView newItem = Instantiate(objectConfigItemPrefab, objectListContainer);
        newItem.Initialize(objectCount, this);
    }

    public void OpenShapePopup(ObjectConfigItemView targetItem)
    {
        if (shapeSelectionPopup != null)
        {
            shapeSelectionPopup.Open(targetItem);
        }
    }

    public void OpenTexturePopup(ObjectConfigItemView targetItem)
    {
        if (textureSelectionPopup != null)
        {
            textureSelectionPopup.Open(targetItem);
        }
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