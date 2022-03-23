using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int startLevel = 1;
    [SerializeField] private Transform levelsParent = null;
    [SerializeField] private MobileControls mobileControls = null;
    private PauseMenu pauseMenu = null;

    private int currentLevel = 0;
    private Transform currentLevelInstance = null;

    void Start()
    {
        if(levelsParent!=null)
        {
            foreach(Transform level in levelsParent)
            {
                level.gameObject.SetActive(false);
            }
            currentLevel = startLevel - 1;
            currentLevelInstance = Instantiate(levelsParent.GetChild(currentLevel));
            currentLevelInstance.gameObject.SetActive(true);
        }
        if(FindObjectOfType<PauseMenu>())
        {
            pauseMenu = FindObjectOfType<PauseMenu>();
        }
        else
        {
            Debug.Log("Pause Menu not found in the current scene");
        }
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel >= levelsParent.childCount)
        {
            currentLevel = startLevel - 1;
        }
        ReloadLevel();
        // If the level manager is reloading the first level, i.e the player beat the game, deactivate
        // Mobile Controls from main screen
        if (currentLevel == startLevel - 1)
        {
            DeactivateMobileControls();
        }
        else
        {
            ActivateMobileControls();
        }
    }

    public void ReloadLevel()
    {
        Destroy(currentLevelInstance.gameObject);
        currentLevelInstance = Instantiate(levelsParent.GetChild(currentLevel));
        currentLevelInstance.gameObject.SetActive(true);
        mobileControls.LocateMovement();
    }

    public void IncrementStartLevel()
    {
        startLevel++;
    }

    public void ActivateMobileControls()
    {
        mobileControls.gameObject.SetActive(true);
    }

    public void DeactivateMobileControls()
    {
        mobileControls.gameObject.SetActive(false);
    }

    public void displayMobileOptionsMenu()
    {
        pauseMenu.DisplayAppropriateMenu();
    }
}
