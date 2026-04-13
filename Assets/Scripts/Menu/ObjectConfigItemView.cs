using UnityEngine;
using UnityEngine.UI;

public class ObjectConfigItemView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text labelText;
    [SerializeField] private Button shapeButton;
    [SerializeField] private Button textureButton;
    [SerializeField] private Image previewImage;

    private int objectIndex;
    private RaceObjectConfig config = new RaceObjectConfig();
    private ObjectSetupController objectSetupController;

    public void Initialize(int index, ObjectSetupController controller)
    {
        objectIndex = index;
        objectSetupController = controller;

        if (labelText != null)
            labelText.text = $"Object {objectIndex}";

        if (shapeButton != null)
        {
            shapeButton.onClick.RemoveAllListeners();
            shapeButton.onClick.AddListener(OnShapeClicked);
        }

        if (textureButton != null)
        {
            textureButton.onClick.RemoveAllListeners();
            textureButton.onClick.AddListener(OnTextureClicked);
        }

        RefreshUI();
    }

    public RaceObjectConfig GetConfig()
    {
        return new RaceObjectConfig
        {
            shape = config.shape,
            color = config.color
        };
    }

    public void SetShape(ShapeType shapeType)
    {
        config.shape = shapeType;
        RefreshUI();
    }

    public void SetColor(Color color)
    {
        config.color = color;
        RefreshUI();
    }

    private void OnShapeClicked()
    {
        if (objectSetupController != null)
        {
            objectSetupController.OpenShapePopup(this);
        }
    }

    private void OnTextureClicked()
    {
        if (objectSetupController != null)
        {
            objectSetupController.OpenTexturePopup(this);
        }
    }

    private void RefreshUI()
    {
        if (previewImage != null)
        {
            previewImage.color = config.color;
        }

        if (shapeButton != null)
        {
            Text shapeText = shapeButton.GetComponentInChildren<Text>();
            if (shapeText != null)
            {
                shapeText.text = config.shape.ToString();
            }
        }
    }
}