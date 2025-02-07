using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    //public GameObject cannonball;
    public float cannonForce = 5;
    public Transform parentTransform;
    public static GameObject shotball;
    public float ballSpin;
    public AudioSource shootSound;
    Animator anim;
    ParticleSystem particle;
    public CannonballManager cannonballManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Cannon").GetComponent<Animator>();
        particle = GameObject.FindGameObjectWithTag("CannonParticle").GetComponent<ParticleSystem>();
    }

    public void Fire()
    {
        if (Phases.currentPhase == Phases.GamePhase.Aiming)
        {
            if (SelectedCannonballCount() > 0)
            {
                Shoot();
                DecrementCannonball(1);
            }

        }
    }

    private void Shoot()
    {
        //add force to ball
        shotball = Instantiate(CannonballManager.currentCannonball.cannonballPrefab, transform.position, parentTransform.rotation);
        shotball.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * cannonForce, ForceMode2D.Impulse);
        shotball.GetComponent<Rigidbody2D>().AddTorque(ballSpin, ForceMode2D.Impulse);

        //Change to next phase
        Phases.currentPhase = Phases.GamePhase.Shooting;

        //animation and particles
        anim.SetTrigger("Shoot");
        particle.Play();

        shootSound.volume = AudioVolumeData.SFXValue;
        shootSound.Play();
    }
    void DecrementCannonball(int integer)
    {
        switch (CannonballManager.currentCannonball.name)
        {
            case "Default Cannonball":
                Objectives.cannonballCount -= integer;
                cannonballManager.cannonballUIText.text = Objectives.cannonballCount.ToString();
                break;

            case "Fireball":
                Objectives.fireballCount -= integer;
                cannonballManager.fireballUIText.text = Objectives.fireballCount.ToString();
                break;

            case "Bouncyball":
                Objectives.bouncyballCount -= integer;
                cannonballManager.bouncyballUIText.text = Objectives.bouncyballCount.ToString();
                break;

            case "Anticannonball":
                Objectives.anticannonballCount -= integer;
                cannonballManager.anticannonballUIText.text = Objectives.anticannonballCount.ToString();
                break;

        }
    }
    int SelectedCannonballCount()
    {
        int returnValue;

            switch (CannonballManager.currentCannonball.name)
            {
                case "Default Cannonball":
                    returnValue = Objectives.cannonballCount;
                    break;

                case "Fireball":
                    returnValue = Objectives.fireballCount;
                    break;

                case "Bouncyball":
                    returnValue = Objectives.bouncyballCount;
                    break;

                case "Anticannonball":
                    returnValue = Objectives.anticannonballCount;
                    break;

                default:
                    returnValue = 0;
                    break;
                
            }
        return returnValue;
    }
}
