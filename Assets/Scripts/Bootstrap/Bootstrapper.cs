using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "Menu";

    private void Start()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}