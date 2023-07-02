using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingScript : MonoBehaviour
{
    public int waitTime = 5;
    bool waiting;

    private void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Waiting && !Phases.GameOver)
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
        if (!Phases.GameOver)
        {
        Phases.currentPhase = Phases.GamePhase.Aiming;
        }

        if (Objectives.totalCannonballsLeft > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("CannonBall"));
        }
        yield return null;
    }
}
