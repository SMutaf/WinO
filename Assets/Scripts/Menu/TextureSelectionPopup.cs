using UnityEngine;

public class TextureSelectionPopup : MonoBehaviour
{
    private ObjectConfigItemView targetItem;

    public void Open(ObjectConfigItemView item)
    {
        targetItem = item;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        targetItem = null;
        gameObject.SetActive(false);
    }

    public void SelectRed()
    {
        ApplyColor(Color.red);
    }

    public void SelectBlue()
    {
        ApplyColor(Color.blue);
    }

    public void SelectGreen()
    {
        ApplyColor(Color.green);
    }

    public void SelectYellow()
    {
        ApplyColor(Color.yellow);
    }

    private void ApplyColor(Color color)
    {
        if (targetItem != null)
        {
            targetItem.SetColor(color);
        }

        Close();
    }
}