using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objectives : MonoBehaviour
{
    public int startCannonballsCount;
    public int startFireballsCount;
    public int startBouncyballsCount;
    public int startAnticannonballCount;

    public static int objectivesLeft;
    public static int totalCannonballsLeft;
    public static int totalBouncyballsLeft;
    public static int totalAnticannonballsLeft;

    public static int cannonballCount;
    public static int fireballCount;
    public static int bouncyballCount;
    public static int anticannonballCount;

    bool starsAwarded = false;

    private void Start()
    {
        objectivesLeft = GameObject.FindGameObjectsWithTag("Money").Length;
        totalCannonballsLeft = startCannonballsCount + startFireballsCount + bouncyballCount;

        cannonballCount = startCannonballsCount;
        fireballCount = startFireballsCount;
        bouncyballCount = startBouncyballsCount;
        anticannonballCount = startAnticannonballCount;
    }
    private void Update()
    {
        //Debug.Log("Objectives: " + objectivesLeft);
        totalCannonballsLeft = cannonballCount + fireballCount + bouncyballCount;

        if (objectivesLeft <= 0)
        {
            //Debug.Log("win");
            Phases.currentPhase = Phases.GamePhase.Victory;
            Phases.GameOver = true;

            if (!starsAwarded)
            {
                GetComponent<StarManager>().AwardStars();
                starsAwarded = true;
            }


            //Unlock next level if current level was won the first time;
            if (LevelsData.unlockedLevels == SceneManager.GetActiveScene().buildIndex)
            {
                LevelsData.unlockedLevels = SceneManager.GetActiveScene().buildIndex + 1;
            }
        }
        if (totalCannonballsLeft <= 0 && Phases.currentPhase == Phases.GamePhase.Waiting && objectivesLeft > 0)
        {
            //Debug.Log("lose");
            Phases.currentPhase = Phases.GamePhase.Defeat;
            Phases.GameOver = true;
        }
    }
}
