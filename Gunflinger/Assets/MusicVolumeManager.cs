using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeManager : MonoBehaviour
{
    public AudioSource musicAudio;

    private void Update()
    {
        musicAudio.volume = AudioVolumeData.musicValue;
    }


}
