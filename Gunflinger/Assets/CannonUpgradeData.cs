using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName ="Upgrade")]
public class CannonUpgradeData : ScriptableObject
{
    public PlayerUpgradesData.CannonUpgradesEnum upgradeName;
    public int cost;
    public bool purchased;
    public Sprite upgradeDisplaySprite;
    public bool equipped;

    public void Purchase()
    {
        purchased = true;
        Debug.Log($"{upgradeName} purchased successfully!");
    }
}
