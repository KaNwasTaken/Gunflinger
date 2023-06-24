using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeData : MonoBehaviour
{
    public static float musicValue = 1;
    public static float SFXValue = 1;

    private void Start()
    {
        musicValue = PlayerData.LoadMusicLevel();
        SFXValue = PlayerData.LoadSFXLevel();
    }

}
