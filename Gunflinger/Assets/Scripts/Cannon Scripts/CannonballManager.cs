using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CannonballManager : MonoBehaviour
{
    public TextMeshProUGUI cannonCounterText;
    void Update()
    {
        cannonCounterText.text = Objectives.cannonballsLeft.ToString();
    }
}
