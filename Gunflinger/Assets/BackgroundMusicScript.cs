using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioLowPassFilter lowPassFilter;

    private void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Aiming || Phases.GameOver)
        {
            lowPassFilter.enabled = false;
        }
        else
        {
            lowPassFilter.enabled = true;
        }
    }
}
