using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballInventory : MonoBehaviour
{
    public CannonballObject[] cannonballsArray;

    public static GameObject selectedCannonballPrefab;

    private void Update()
    {
        /*switch (CannonballManager.currentCannonball)
        {
            case CannonballManager.SelectedCannonball.Cannonball:
                selectedCannonballPrefab = cannonballPrefab;
                break;

            case CannonballManager.SelectedCannonball.Fireball:
                selectedCannonballPrefab = fireballPrefab;
                break;
        }
        */
    }

}
