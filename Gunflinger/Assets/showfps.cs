using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showfps : MonoBehaviour
{
    public TextMeshProUGUI fpscounter;
    public GameObject counter;
    bool showFps = false;

    public void ToggleCounter()
    {
        switch (showFps)
        {
            case true:
                showFps = false;
                break;
            case false:
                showFps = true;
                break;
        }
    }
    private void Update()
    {
        if (showFps)
        {
            counter.SetActive(true);
            fpscounter.text = "FPS: " + (1f / Time.unscaledDeltaTime);
        }
        else
        {
            counter.SetActive(false);
        }

    }

}
