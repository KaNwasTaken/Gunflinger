using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CannonBrowser : MonoBehaviour
{
    public CannonUpgradeData[] cannonUpgrades;
    CannonUpgradeData currentlySelectedCannon;

    public Image cannonDisplayImage;
    public Button equipButton;
    public TextMeshProUGUI equipButtonText;

    int selectedCannonIndex;

    private void Start()
    {
        //gets the index associated with the cannon
        selectedCannonIndex = (int)PlayerUpgradesData.selectedCannon;
        currentlySelectedCannon = cannonUpgrades[selectedCannonIndex];

        cannonDisplayImage.sprite = currentlySelectedCannon.upgradeDisplaySprite;
    }

    private void Update()
    {
        //update selected cannon with index
        currentlySelectedCannon = cannonUpgrades[selectedCannonIndex];
        cannonDisplayImage.sprite = currentlySelectedCannon.upgradeDisplaySprite;

        //equip button and purchase button display control
        if (currentlySelectedCannon.purchased)
        {
            if (currentlySelectedCannon.upgradeName == PlayerUpgradesData.selectedCannon)
            {
                equipButtonText.text = "Equipped";
                equipButton.interactable = false;
            }
            else
            {
                equipButtonText.text = "Equip";
                equipButton.interactable = true;
            }
        }
        else
        {
            equipButtonText.text = "Purchase";
            equipButton.interactable = true;
        }
        Debug.Log(selectedCannonIndex);
    }

    public void NextUpgrade()
    {
        if (selectedCannonIndex < cannonUpgrades.Length - 1)
        {
            selectedCannonIndex += 1;
        }
        else
        {
            selectedCannonIndex = 0;
        }
    }
    public void PreviousUpgrade()
    {
        if (selectedCannonIndex > 0)
        {
            selectedCannonIndex -= 1;
        }
        else
        {
            selectedCannonIndex = cannonUpgrades.Length - 1;
        }
    }

}
