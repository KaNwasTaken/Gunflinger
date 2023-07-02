using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioLowPassFilter lowPassFilter;
    public AudioSource musicSource;
    float defaultVolume;

    private void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Aiming || Phases.GameOver)
        {
            lowPassFilter.cutoffFrequency = 10000;
        }
        else
        {
            lowPassFilter.cutoffFrequency = 700;
        }
    }
}
