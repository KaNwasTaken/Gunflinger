using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Remember that DisableUI controls disabling of the firebutton on change of phase
//Remember that this script disables the UI the moment it is not in the aiming or scouting phase

public class DisableUI : MonoBehaviour
{
    public GameObject firebutton;

    private void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Aiming || Phases.currentPhase == Phases.GamePhase.Scouting)
        {
            firebutton.SetActive(true);
        }
        else
        {
            firebutton.SetActive(false);
        }
    }



}
