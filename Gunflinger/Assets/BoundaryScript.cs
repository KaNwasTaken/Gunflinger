using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            ShootScript.shotball = null;
            Phases.currentPhase = Phases.GamePhase.Waiting;

            StartCoroutine(DeletionCoroutine(collision.gameObject));
        }

    }

    IEnumerator DeletionCoroutine(GameObject gameObject)
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        yield return null;
    }

}
