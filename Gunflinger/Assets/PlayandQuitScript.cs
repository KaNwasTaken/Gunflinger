using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayandQuitScript : MonoBehaviour
{
    public GameObject MainMenuButtons;
    public GameObject LevelSelectionScreen;

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        MainMenuButtons.SetActive(false);
        LevelSelectionScreen.SetActive(true);
    }
    public void Return()
    {
        MainMenuButtons.SetActive(true);
        LevelSelectionScreen.SetActive(false);
    }
}
