using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject menuButtons;

    public Slider musicSlider;
    public Slider sfxSlider;

    public void ShowSettings()
    {
        settingsMenu.SetActive(true);
        menuButtons.SetActive(false);
    }
    public void HideSettings()
    {
        settingsMenu.SetActive(false);
        menuButtons.SetActive(true);

        PlayerData.SetMusicLevel(musicSlider.value);
        PlayerData.SetSFXLevel(sfxSlider.value);
    }
    private void Start()
    {
        musicSlider.value = AudioVolumeData.musicValue;
        sfxSlider.value = AudioVolumeData.SFXValue;
    }
    private void Update()
    {
        if (settingsMenu.activeSelf) 
        { 
            AudioVolumeData.musicValue = musicSlider.value;
            AudioVolumeData.SFXValue = sfxSlider.value;
        }
    }


}
