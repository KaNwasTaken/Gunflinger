using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCannon : MonoBehaviour
{
    public GameObject[] cannonArray;
    [HideInInspector] public static GameObject selectedCannon;
    public int selectedCannonIndex;

    // Start is called before the first frame update
    void Start()
    {
        selectedCannon = cannonArray[selectedCannonIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
