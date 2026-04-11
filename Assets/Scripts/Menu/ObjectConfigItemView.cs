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

    public void Initialize(int index)
    {
        objectIndex = index;

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

        UpdatePreview();
        UpdateButtonTexts();
    }

    public RaceObjectConfig GetConfig()
    {
        return new RaceObjectConfig
        {
            shape = config.shape,
            color = config.color
        };
    }

    private void OnShapeClicked()
    {
        config.shape = config.shape == ShapeType.Circle
            ? ShapeType.Square
            : ShapeType.Circle;

        Debug.Log($"Object {objectIndex} Shape: {config.shape}");
        UpdateButtonTexts();
    }

    private void OnTextureClicked()
    {
        config.color = new Color(Random.value, Random.value, Random.value);
        Debug.Log($"Object {objectIndex} Color Changed");
        UpdatePreview();
    }

    private void UpdatePreview()
    {
        if (previewImage != null)
        {
            previewImage.color = config.color;
        }
    }

    private void UpdateButtonTexts()
    {
        Text shapeText = shapeButton != null ? shapeButton.GetComponentInChildren<Text>() : null;

        if (shapeText != null)
        {
            shapeText.text = config.shape.ToString();
        }
    }
}