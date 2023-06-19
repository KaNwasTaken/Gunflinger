using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingScript : MonoBehaviour
{
    public int waitTime = 5;
    bool waiting;

    private void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Waiting)
        {
            if (waiting)
            {
                waiting = false;
                StartCoroutine(WaitingCoroutine());

            }
        }
        else
        {
            waiting = true;
        }

    }

    IEnumerator WaitingCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(GameObject.FindGameObjectWithTag("CannonBall"));
        Phases.currentPhase = Phases.GamePhase.Aiming;
        yield return null;
    }
}
