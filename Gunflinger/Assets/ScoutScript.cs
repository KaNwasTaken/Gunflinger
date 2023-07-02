using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ScoutScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool buttonDown;
    public UnityEvent OnButtonHold;
    public void Scout()
    {
        Debug.Log("Scouting");
        while (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Holding");
        }
    }
    public void OnPointerDown(PointerEventData pointerEvent)
    {
        buttonDown = true;
    }

    public void OnPointerUp(PointerEventData pointerEvent)
    {
        buttonDown = false;
        Phases.currentPhase = Phases.GamePhase.Aiming;
    }

    private void Update()
    {
        if (buttonDown)
        {
            Phases.currentPhase = Phases.GamePhase.Scouting;
        }
    }
}
