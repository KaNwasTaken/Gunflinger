using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionScript : MonoBehaviour
{

    public AudioSource thudSound;

    public bool explodeOnContact;
    public bool bounceOnContact;

    public Animator explosionAnim;
    public AudioSource explosionSound;

    public AudioSource bounceSound;
    public AudioSource fizzle;
    public ParticleSystem fizzleParticle;

    int bounceCounter = 3;

    private void Start()
    {
        if (thudSound != null)
        thudSound.volume *= PlayerData.LoadSFXLevel();

        if (explosionSound != null)
        explosionSound.volume *= PlayerData.LoadSFXLevel();

        if (bounceSound != null)
            bounceSound.volume *= PlayerData.LoadSFXLevel();

        if (fizzle != null)
            bounceSound.volume *= PlayerData.LoadSFXLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") && !explodeOnContact)
        {

            if (collision.relativeVelocity.magnitude > 10)
            {
                thudSound.Play();
            }
        }

        if (explodeOnContact)
        {
            explodeOnContact = false;

            AddExplosionForce2D();

            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());

            explosionAnim.SetTrigger("Explode");
            explosionSound.Play();

            Invoke(nameof(DeleteSelf), 2);
        }



    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (bounceOnContact)
        {
            if (bounceCounter > 0)
            {
                bounceCounter -= 1;
                bounceSound.Play();
            }
            else
            {
                fizzle.Play();
                fizzleParticle.Play();

                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(GetComponent<BoxCollider2D>());

                Invoke(nameof(DeleteSelf), 2f );
            }
        }
    }

    void AddExplosionForce2D()
    {
        var affectedObjects = Physics2D.OverlapCircleAll(transform.position, 4);
        foreach (Collider2D obj in affectedObjects)
        {
            if (obj.attachedRigidbody != null) 
            { 
                var direction = obj.transform.position - transform.position;
                obj.attachedRigidbody.AddForce(direction.normalized * 25000);
            }
        }
    }
    void DeleteSelf()
    {
        Destroy(gameObject);
        Phases.currentPhase = Phases.GamePhase.Waiting;
    }
}
