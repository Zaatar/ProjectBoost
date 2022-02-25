using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;

    void Start()
    {
        mainMenuUI.SetActive(true);
    }
}
