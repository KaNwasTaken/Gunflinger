using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradesData : MonoBehaviour
{
    public enum CannonUpgradesEnum
    {
        CannonDefault,
        Cannon2
    }

    public static CannonUpgradesEnum selectedCannon;

    private void Start()
    {
        selectedCannon = (CannonUpgradesEnum)PlayerData.LoadSavedCannonUpgradeIndex();
    }

}
