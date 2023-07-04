using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//<summary>
//Contains cannon functions to be used by selection buttons
//And updates the counter each frame
//</summary>

public class CannonballManager : MonoBehaviour
{


    [SerializeField] GameObject CannonballsContainer;

    //public TextMeshProUGUI cannonballCounterText;
    [SerializeField] GameObject cannonballUIPrefab;
    public TextMeshProUGUI cannonballUIText;

    //public TextMeshProUGUI fireballCounterText;
    [SerializeField] GameObject fireballUIPrefab;
    public TextMeshProUGUI fireballUIText;

    [SerializeField] GameObject bouncyballUIPrefab;
    public TextMeshProUGUI bouncyballUIText;

    [SerializeField] GameObject anticannonballUIPrefab;
    public TextMeshProUGUI anticannonballUIText;

    [SerializeField] RectTransform[] slots;
    int slotIndex;
    /*public enum SelectedCannonball
    {
        Cannonball,
        Fireball
    }*/

    public static CannonballObject[] cannonballsArray;

    public static CannonballObject currentCannonball;

    private void Start()
    {

        cannonballsArray = GetComponentInParent<CannonballInventory>().cannonballsArray;

        slotIndex = 0;
        bool alreadySelected = false;

        //Instantiates the UI Objects;
        if (Objectives.cannonballCount > 0)
        {
            var cannonballUI = Instantiate(cannonballUIPrefab, slots[slotIndex].position, Quaternion.identity, slots[slotIndex]);
            cannonballUIText = cannonballUI.GetComponentInChildren<TextMeshProUGUI>();
            slotIndex += 1;
            if (!alreadySelected)
            {
                SelectCannonball();
                alreadySelected = true;
            }
            cannonballUIText.text = Objectives.cannonballCount.ToString();
        }
        if (Objectives.fireballCount > 0)
        {


            var fireballUI = Instantiate(fireballUIPrefab, slots[slotIndex].position, Quaternion.identity, slots[slotIndex]);
            fireballUIText = fireballUI.GetComponentInChildren<TextMeshProUGUI>();
            slotIndex += 1;

            if (!alreadySelected)
            {
                SelectFireball();
                alreadySelected = true;
            }
            fireballUIText.text = Objectives.fireballCount.ToString();
        }
        if (Objectives.bouncyballCount > 0)
        {

 
            var bouncyballUI = Instantiate(bouncyballUIPrefab, slots[slotIndex].position, Quaternion.identity, slots[slotIndex]);
            bouncyballUIText = bouncyballUI.GetComponentInChildren<TextMeshProUGUI>();
            slotIndex += 1;

            if (!alreadySelected)
            {
                SelectBouncyball();
                alreadySelected = true;
            }
            bouncyballUIText.text = Objectives.bouncyballCount.ToString();
        }
        if (Objectives.anticannonballCount > 0)
        {
            var anticannonballUI = Instantiate(anticannonballUIPrefab, slots[slotIndex].position, Quaternion.identity, slots[slotIndex]);
            anticannonballUIText = anticannonballUI.GetComponentInChildren<TextMeshProUGUI>();
            slotIndex += 1;

            if (!alreadySelected)
            {
                SelectAnticannonball();
                alreadySelected = true;
            }
            anticannonballUIText.text = Objectives.anticannonballCount.ToString();
        }

        //Clear Unused Slots
        for (int i = slotIndex; i < slots.Length; i++)
        {
            Destroy(slots[i].gameObject);
        }
        
        /*if (cannonballUIText != null)
            cannonballUIText.text = Objectives.cannonballCount.ToString();

        if (fireballUIText != null)
            fireballUIText.text = Objectives.fireballCount.ToString();*/

    }

    public static void SelectCannonball()
    {
        CannonballManager.currentCannonball = cannonballsArray[0];
    }

    public static void SelectFireball()
    {
        currentCannonball = cannonballsArray[1];
        //CannonballManager.currentCannonball = SelectedCannonball.Fireball;
    }

    public static void SelectBouncyball()
    {
        currentCannonball = cannonballsArray[2];
    }

    public static void SelectAnticannonball()
    {
        currentCannonball = cannonballsArray[3];
    }
}
