using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] MainMenu mainMenuUI;
    [SerializeField] PauseMenu pauseMenuUI;
    Resolution[] resolutions;
    TransitionSource transitionSource = TransitionSource.PAUSE_MENU;

    public enum TransitionSource
    {
        MAIN_MENU,
        PAUSE_MENU
    };

    private void Start()
    {
        populateResolutionDropdown();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;   
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetTransitionSource(TransitionSource source)
    {
        transitionSource = source;
    }

    void populateResolutionDropdown()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + "@" + resolutions[i].refreshRate + "Hz";
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void TransitionFromOptionsMenu()
    {
        this.gameObject.SetActive(false);
        if(transitionSource == TransitionSource.MAIN_MENU)
        {
            mainMenuUI.gameObject.SetActive(true);
        }
        else
        {
            pauseMenuUI.gameObject.SetActive(true);
        }
    }
}
