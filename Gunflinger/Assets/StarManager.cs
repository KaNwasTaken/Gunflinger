using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public float maximumTime;
    public int minimumCannonballsLeft;

    public Image[] stars;
    public Color disabledColor;

    public static int awardedStars = 0;
    int starIndex = 0;

    private void Start()
    {
        foreach (Image i in stars)
        {
            i.color = disabledColor;
        }
    }

    public void AwardStars()
    {
        if (Objectives.objectivesLeft <= 0)
        {
            awardedStars += 1;
            stars[starIndex].color = Color.white;
            starIndex += 1;
        }
        
        if (Objectives.totalCannonballsLeft >= minimumCannonballsLeft)
        {
            awardedStars += 1;
            stars[starIndex].color = Color.white;
            starIndex += 1;
        }

        if (Time.timeSinceLevelLoad < maximumTime)
        {
            awardedStars += 1;
            stars[starIndex].color = Color.white;
            starIndex += 1;
        }

        Debug.Log($"Stars awarded: {awardedStars}");

        
    }

}
