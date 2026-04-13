using UnityEngine;

public class ShapeSelectionPopup : MonoBehaviour
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

    public void SelectCircle()
    {
        if (targetItem != null)
        {
            targetItem.SetShape(ShapeType.Circle);
        }

        Close();
    }

    public void SelectSquare()
    {
        if (targetItem != null)
        {
            targetItem.SetShape(ShapeType.Square);
        }

        Close();
    }
}