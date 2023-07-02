using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhase : MonoBehaviour
{
    bool checkifstopped;
    Rigidbody2D rb;
    public float stopThreshold;
    private void Start()
    {
        checkifstopped = true;
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (rb != null)
        {
            if (rb.velocity.magnitude < 0 + stopThreshold && checkifstopped)
            {
                if (!Phases.GameOver)
                {
                    Phases.currentPhase = Phases.GamePhase.Waiting;
                    checkifstopped = false;
                }
            }
        }
    }
}
