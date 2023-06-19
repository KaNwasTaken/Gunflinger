using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Remember that DisableUI controls disabling of the firebutton on change of phase;

public class DisableUI : MonoBehaviour
{
    public GameObject firebutton;

    private void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Aiming)
        {
            firebutton.SetActive(true);
        }
        else
        {
            firebutton.SetActive(false);
        }
    }



}
