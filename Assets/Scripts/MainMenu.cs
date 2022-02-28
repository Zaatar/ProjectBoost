using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] GameObject backgroundImage;
    [SerializeField] OptionsMenu optionsMenuUI;
    
    public void PlayGame()
    {
        backgroundImage.SetActive(false);
        this.gameObject.SetActive(false);
        levelManager.LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TransitionToOptionsMenu()
    {
        this.gameObject.SetActive(false);
        optionsMenuUI.gameObject.SetActive(true);
        optionsMenuUI.SetTransitionSource(OptionsMenu.TransitionSource.MAIN_MENU);
    }
}
