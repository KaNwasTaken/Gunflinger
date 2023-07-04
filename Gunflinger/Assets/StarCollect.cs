using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{
    public GameObject starSpriteObject;
    public ParticleSystem starParticle;

    private void Start()
    {
        starParticle = starSpriteObject.GetComponent<ParticleSystem>();
    }
    public void PlayStarParticle()
    {
        starSpriteObject.transform.eulerAngles = new Vector3(-90, 0, 0);
        starParticle.Play();
    }
}
