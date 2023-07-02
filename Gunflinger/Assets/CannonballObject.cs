using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCannonball", menuName = "Cannonball")]

public class CannonballObject : ScriptableObject
{
    public GameObject cannonballPrefab;
    public Sprite cannonballDisplayimage;
    public float damageModifier = 1;
}
