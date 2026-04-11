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

    private string currentShape = "Sphere";
    private Color currentColor = Color.white;

    public void Initialize(int index)
    {
        objectIndex = index;

        if (labelText != null)
            labelText.text = $"Object {objectIndex}";

        shapeButton.onClick.RemoveAllListeners();
        shapeButton.onClick.AddListener(OnShapeClicked);

        textureButton.onClick.RemoveAllListeners();
        textureButton.onClick.AddListener(OnTextureClicked);

        UpdatePreview();
    }

    private void OnShapeClicked()
    {
        // Basit toggle
        currentShape = currentShape == "Sphere" ? "Cube" : "Sphere";

        Debug.Log($"Object {objectIndex} Shape: {currentShape}");
    }

    private void OnTextureClicked()
    {
        // Renk deðiþtir (þimdilik texture yerine)
        currentColor = new Color(Random.value, Random.value, Random.value);

        Debug.Log($"Object {objectIndex} Color Changed");

        UpdatePreview();
    }

    private void UpdatePreview()
    {
        if (previewImage != null)
        {
            previewImage.color = currentColor;
        }
    }
}