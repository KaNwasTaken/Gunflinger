using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static GameObject instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = gameObject;
        }

        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        Debug.Log("Started");
        Application.targetFrameRate = 60;
    }
}
