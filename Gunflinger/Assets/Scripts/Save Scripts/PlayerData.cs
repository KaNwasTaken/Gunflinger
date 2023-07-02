using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{

    public static int LoadUnlockedLevels()
    {
        return PlayerPrefs.GetInt("Unlocked levels", 1);
    }
    public static void SetUnlockedLevels(int integer)
    {
        PlayerPrefs.SetInt("Unlocked levels", integer);
    }

    public static float LoadSFXLevel()
    {
        return PlayerPrefs.GetFloat("SFX level", 1);
    }
    public static void SetSFXLevel(float f)
    {
        PlayerPrefs.SetFloat("SFX level", f);
    }
    public static float LoadMusicLevel()
    {
        return PlayerPrefs.GetFloat("Music level", 1);
    }
    public static void SetMusicLevel(float f)
    {
        PlayerPrefs.SetFloat("Music level", f);
    }

    public static int LoadSavedCannonUpgradeIndex()
    {
        return PlayerPrefs.GetInt("CannonUpgradeIndex", 0);
    }

    public static void SaveCannonUpgradeIndex(int integer)
    {
        PlayerPrefs.SetInt("CannonUpgradeIndex", integer);
    }

}
