using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionScript : MonoBehaviour
{

    public AudioSource thudSound;

    public bool explodeOnContact = false;
    public Animator explosionAnim;
    public AudioSource explosionSound;

    private void Start()
    {
        if (thudSound != null)
        thudSound.volume *= PlayerData.LoadSFXLevel();

        if (explosionSound != null)
        explosionSound.volume *= PlayerData.LoadSFXLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.relativeVelocity.magnitude > 10)
            {
                thudSound.Play();
            }
        }

    }

    /*void AddExplosionForce2D(Vector3 explosionOrigin, float explosionForce, float explosionRadius)
        {
            Vector3 direction = transform.position - explosionOrigin;
            float forceFalloff = 1 - (direction.magnitude / explosionRadius);
            GetComponent<Rigidbody2D>().AddForce(direction.normalized * (forceFalloff <= 0 ? 0 : explosionForce) * forceFalloff);
        }*/

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
