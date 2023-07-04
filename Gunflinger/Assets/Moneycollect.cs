using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneycollect : MonoBehaviour
{
    public ParticleSystem particles;
    public AudioSource collectAudio;
    public StarCollect starCollect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            Objectives.objectivesLeft -= 1;
            particles.Play();
            collectAudio.Play();
            starCollect.PlayStarParticle();

            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject.GetComponent<Collider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());

            Destroy(gameObject, 1f);
        }
    }
}
