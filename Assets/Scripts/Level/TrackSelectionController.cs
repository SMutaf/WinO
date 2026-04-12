using UnityEngine;

public class TrackSelectionController : MonoBehaviour
{
    [SerializeField] private MenuFlowController menuFlowController;
    [SerializeField] private LevelData selectedLevel;

    public void SelectLevel(LevelData levelData)
    {
        selectedLevel = levelData;

        if (selectedLevel != null)
        {
            Debug.Log("Selected Level: " + selectedLevel.displayName);
        }
    }

    public void ContinueToObjectSetup()
    {
        if (selectedLevel == null)
        {
            Debug.LogWarning("No level selected.");
            return;
        }

        if (RaceSetupSession.Instance == null)
        {
            Debug.LogError("RaceSetupSession instance not found.");
            return;
        }

        RaceSetupSession.Instance.SetLevel(selectedLevel);

        if (menuFlowController != null)
        {
            menuFlowController.OpenObjectSetup();
        }
        else
        {
            Debug.LogError("MenuFlowController reference is missing.");
        }
    }
}