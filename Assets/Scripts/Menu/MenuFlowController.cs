using UnityEngine;

public class MenuFlowController : MonoBehaviour
{
    [Header("Main Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject trackSelectionPanel;
    [SerializeField] private GameObject objectSetupPanel;

    [Header("Popup Panels")]
    [SerializeField] private GameObject objectConfigPopup;

    private void Start()
    {
        ShowMainPanel(MenuPanelType.MainMenu);
        CloseAllPopups();
    }

    public void ShowMainPanel(MenuPanelType panelType)
    {
        HideAllMainPanels();

        switch (panelType)
        {
            case MenuPanelType.MainMenu:
                mainMenuPanel.SetActive(true);
                break;

            case MenuPanelType.TrackSelection:
                trackSelectionPanel.SetActive(true);
                break;

            case MenuPanelType.ObjectSetup:
                objectSetupPanel.SetActive(true);
                break;
        }
    }

    public void OpenMainMenu()
    {
        ShowMainPanel(MenuPanelType.MainMenu);
        CloseAllPopups();
    }

    public void OpenTrackSelection()
    {
        ShowMainPanel(MenuPanelType.TrackSelection);
        CloseAllPopups();
    }

    public void OpenObjectSetup()
    {
        ShowMainPanel(MenuPanelType.ObjectSetup);
        CloseAllPopups();
    }

    public void OpenObjectConfigPopup()
    {
        objectConfigPopup.SetActive(true);
    }

    public void CloseObjectConfigPopup()
    {
        objectConfigPopup.SetActive(false);
    }

    private void HideAllMainPanels()
    {
        mainMenuPanel.SetActive(false);
        trackSelectionPanel.SetActive(false);
        objectSetupPanel.SetActive(false);
    }

    private void CloseAllPopups()
    {
        objectConfigPopup.SetActive(false);
    }
}