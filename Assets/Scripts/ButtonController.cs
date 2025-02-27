using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public GameObject panel;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsOpen()
    {
        panel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeController()
    {
        // Выбранное управление
        panel.SetActive(false);
    }
}
