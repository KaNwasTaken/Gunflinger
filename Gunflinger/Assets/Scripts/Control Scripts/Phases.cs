using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phases : MonoBehaviour
{
    public static Phases instance { get; private set; }

    public enum GamePhase
    {
        Aiming,
        Scouting,
        Shooting,
        Waiting,
        Victory,
        Defeat
    }
    public static GamePhase currentPhase;
    public static bool IsPaused;
    public GameObject pauseMenu;
    public static bool GameOver;


    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.Log("Another Instance was found");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        GameOver = false;

        IsPaused = false;
        currentPhase = GamePhase.Aiming;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentPhase);
        if (pauseMenu.activeSelf)
        {
            IsPaused = true;
        }
        else
        {
            IsPaused = false;
        }
    }
}
