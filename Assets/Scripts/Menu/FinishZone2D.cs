using UnityEngine;

public class FinishZone2D : MonoBehaviour
{
    private bool raceFinished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (raceFinished)
            return;

        raceFinished = true;
        Debug.Log($"Winner: {other.gameObject.name}");
    }
}