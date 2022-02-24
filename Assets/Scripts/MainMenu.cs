using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] GameObject backgroundImage;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void PlayGame()
    {
        this.gameObject.SetActive(false);
        levelManager.LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
