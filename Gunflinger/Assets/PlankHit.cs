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
    public float destroyObjectDelay = 0.1f;


    private void Start()
    {
        currentHp = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.relativeVelocity.magnitude > threshold)
        {
            if (collision.gameObject.CompareTag("CannonBall"))
            {
                currentHp -= Mathf.RoundToInt(collision.relativeVelocity.magnitude * CannonballManager.currentCannonball.damageModifier);
            }
            else
            {
                if (gameObject != null && collision.rigidbody != null)
                {
                    //Debug.Log(gameObject + " " + collision.gameObject);
                    currentHp -= Mathf.RoundToInt(collision.relativeVelocity.magnitude * collision.rigidbody.mass * 0.25f);
                }
                else if (gameObject != null)
                {
                    //Debug.Log(gameObject + " " + collision.gameObject);
                    currentHp -= Mathf.RoundToInt(collision.relativeVelocity.magnitude);

                }
            }

            if (currentHp <= 0)
            {
                particle.Play();
                hitAudio.volume *= AudioVolumeData.SFXValue;
                hitAudio.Play();


                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(GetComponent<Rigidbody2D>());

                Destroy(gameObject, destroyObjectDelay);
            }

            float healthPercent = Mathf.Clamp((float)currentHp / health, 0.5f, 1);

            if (gameObject.GetComponent<SpriteRenderer>() != null)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(healthPercent, healthPercent, healthPercent, 1);
            }
            
        }
    }
}
