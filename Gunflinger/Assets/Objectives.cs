using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objectives : MonoBehaviour
{
    public int startCannonballsCount;

    public static int objectivesLeft;
    public static int cannonballsLeft;

    private void Start()
    {
        objectivesLeft = GameObject.FindGameObjectsWithTag("Money").Length;
        cannonballsLeft = startCannonballsCount;
    }
    private void Update()
    {
        //Debug.Log("Objectives: " + objectivesLeft);

        if (objectivesLeft <= 0)
        {
            Debug.Log("win");
            Phases.currentPhase = Phases.GamePhase.Victory;
            Phases.GameOver = true;

            //Unlock next level if current level was won the first time;
            if (LevelsData.unlockedLevels == SceneManager.GetActiveScene().buildIndex)
            {
                LevelsData.unlockedLevels = SceneManager.GetActiveScene().buildIndex + 1;
            }
        }
        if (cannonballsLeft <= 0 && Phases.currentPhase == Phases.GamePhase.Waiting && objectivesLeft > 0)
        {
            Debug.Log("lose");
            Phases.currentPhase = Phases.GamePhase.Defeat;
            Phases.GameOver = true;
        }
    }
}
