using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsData : MonoBehaviour
{
    public static int unlockedLevels;
    private void Start()
    {
        unlockedLevels = PlayerData.LoadUnlockedLevels();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            PlayerData.SetUnlockedLevels(unlockedLevels);
        }
    }
    private void OnApplicationQuit()
    {
        PlayerData.SetUnlockedLevels(unlockedLevels);
    }
}
