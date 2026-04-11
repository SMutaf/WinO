using UnityEngine;

[System.Serializable]
public class RaceObjectConfig
{
    public ShapeType shape;
    public Color color;

    public RaceObjectConfig()
    {
        shape = ShapeType.Circle;
        color = Color.white;
    }
}