using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlankHit : MonoBehaviour
{
    public float threshold = 5;
    public ParticleSystem particle;
    public int health = 50;
    public AudioSource hitAudio;
    int currentHp;


    private void Start()
    {
        currentHp = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("CannonBall") && collision.relativeVelocity.magnitude > threshold)
        {
            currentHp -= (int)collision.relativeVelocity.magnitude;

            if (currentHp <= 0) 
            {
                particle.Play();
                hitAudio.volume = AudioVolumeData.SFXValue;
                hitAudio.Play();


                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
