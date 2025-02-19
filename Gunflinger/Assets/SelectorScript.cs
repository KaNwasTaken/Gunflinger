using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorScript : MonoBehaviour
{
    Button button;
    Image buttonImage;
    public Color color;
    [SerializeField] bool CannonballSelect = false;
    [SerializeField] bool FireballSelect = false;
    [SerializeField] bool BouncyballSelect = false;
    [SerializeField] bool AnticannonballSelect = false;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        buttonImage = gameObject.GetComponent<Image>();
    }
    
    void OnClick()
    {
        if (CannonballSelect)
            CannonballManager.SelectCannonball();

        if (FireballSelect)
            CannonballManager.SelectFireball();

        if (BouncyballSelect)
            CannonballManager.SelectBouncyball();

        if (AnticannonballSelect)
            CannonballManager.SelectAnticannonball();

    }
    private void Update()
    {

        if (CannonballSelect)
        {
            if (CannonballManager.currentCannonball.name == "Default Cannonball")
            {
                buttonImage.color = Color.white;
            }
            else
            {
                buttonImage.color = color;
            }
        }

        if (FireballSelect) 
        {
            if (CannonballManager.currentCannonball.name == "Fireball")
                {
                    buttonImage.color = Color.white;
                }
            else
                {
                    buttonImage.color = color;
                }
        }
        if (BouncyballSelect)
        {
            if (CannonballManager.currentCannonball.name == "Bouncyball")
            {
                buttonImage.color = Color.white;
            }
            else
            {
                buttonImage.color = color;
            }
        }
        if (AnticannonballSelect)
        {
            if (CannonballManager.currentCannonball.name == "Anticannonball")
            {
                buttonImage.color = Color.white;
            }
            else
            {
                buttonImage.color = color;
            }
        }
    }
}
