using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneycollect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            Objectives.objectivesLeft -= 1;
            Destroy(gameObject);
        }
    }
}
