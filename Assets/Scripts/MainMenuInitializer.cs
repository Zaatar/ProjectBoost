using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject backgroundImage;

    void Start()
    {
        mainMenuUI.SetActive(true);
        backgroundImage.SetActive(true);
    }
}
