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
    TextMeshProUGUI cannonballUIText;

    //public TextMeshProUGUI fireballCounterText;
    [SerializeField] GameObject fireballUIPrefab;
    TextMeshProUGUI fireballUIText;

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
        }
        if (Objectives.fireballCount > 0)
        {

            Debug.Log("Testing");
            var fireballUI = Instantiate(fireballUIPrefab, slots[slotIndex].position, Quaternion.identity, slots[slotIndex]);
            fireballUIText = fireballUI.GetComponentInChildren<TextMeshProUGUI>();
            slotIndex += 1;

            if (!alreadySelected)
            {
                SelectFireball();
                alreadySelected = true;
            }
        }

        //Clear Unused Slots
        for (int i = slotIndex; i < slots.Length; i++)
        {
            Destroy(slots[i].gameObject);
        }

    }
    void Update()
    {
        if (cannonballUIText != null)
        cannonballUIText.text = Objectives.cannonballCount.ToString();

        if (fireballUIText != null)
        fireballUIText.text = Objectives.fireballCount.ToString();
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
}
