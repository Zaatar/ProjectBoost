using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int startLevel = 1;
    [SerializeField] private Transform levelsParent = null;

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
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel >= levelsParent.childCount)
        {
            currentLevel = startLevel - 1;
        }
        ReloadLevel();
    }

    public void ReloadLevel()
    {
        Destroy(currentLevelInstance.gameObject);
        currentLevelInstance = Instantiate(levelsParent.GetChild(currentLevel));
        currentLevelInstance.gameObject.SetActive(true);
    }
}
