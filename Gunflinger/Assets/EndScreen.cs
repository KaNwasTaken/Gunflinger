using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public GameObject victoryScreen;
    public GameObject defeatScreen;

    public TextMeshProUGUI victoryTimer;
    public TextMeshProUGUI defeatTimer;

    public Animator victoryAnim;
    public Animator defeatAnim;
    
    float timer;
    bool capturedtime = false;

    bool ScreenShown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Victory && !ScreenShown)
        {
            Invoke(nameof(ShowVictoryScreen), 1);
            ScreenShown = true;
        }
        if (Phases.currentPhase == Phases.GamePhase.Defeat && !ScreenShown)
        {
            Invoke(nameof(ShowDefeatScreen), 1);
            ScreenShown = true;
        }
    }

    private void ShowDefeatScreen()
    {
        if (!capturedtime)
        {
            timer = Time.timeSinceLevelLoad;
            capturedtime = true;
        }

        defeatScreen.SetActive(true);
        defeatAnim.SetTrigger("DefeatScreen");
        defeatTimer.text = "Time: " + timer.ToString("F2") + "s";
    }

    private void ShowVictoryScreen()
    {
        if (!capturedtime)
        {
            timer = Time.timeSinceLevelLoad;
            capturedtime = true;
        }

        victoryScreen.SetActive(true);
        victoryAnim.SetTrigger("VictoryScreen");
        victoryTimer.text = "Time: " + timer.ToString("F2") + "s";
    }
}
