using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] OptionsMenu optionsMenuUI;
    [SerializeField] GameObject pauseMenuUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DisplayAppropriateMenu();
        }
    }

    public void DisplayAppropriateMenu()
    {
        if (optionsMenuUI.gameObject.activeSelf)
        {
            DisplayPauseMenu();
        }
        else if(GameIsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void DisplayPauseMenu()
    {
        optionsMenuUI.gameObject.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void TransitionToOptionsMenu()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.gameObject.SetActive(true);
        optionsMenuUI.SetTransitionSource(OptionsMenu.TransitionSource.PAUSE_MENU);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
