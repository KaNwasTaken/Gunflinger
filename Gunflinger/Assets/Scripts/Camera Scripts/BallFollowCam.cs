using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollowCam : MonoBehaviour
{
    GameObject cannonball;
    public float cameraSpeed;
    public float returnSpeed = 5;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;
    Vector3 cannonPosition;
    public Transform scoutTarget;

    // Start is called before the first frame update
    void Start()
    {
        cannonPosition = GameObject.FindGameObjectWithTag("Cannon").transform.position;
        cannonPosition += offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Shooting || Phases.currentPhase == Phases.GamePhase.Waiting || Phases.GameOver) 
        {
            cannonball = ShootScript.shotball;
            //transform.position = Vector3.Lerp(transform.position, cannonball.transform.position, cameraSpeed);
            if (cannonball != null) {
                transform.position = Vector3.SmoothDamp(transform.position, cannonball.transform.position, ref velocity, cameraSpeed);
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            }

        }
        if (Phases.currentPhase == Phases.GamePhase.Aiming)
        {
            transform.position = Vector3.Lerp(transform.position, cannonPosition, Time.deltaTime * returnSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }

        if (Phases.currentPhase == Phases.GamePhase.Scouting)
        {
            transform.position = Vector3.Lerp(transform.position, scoutTarget.position, Time.deltaTime * returnSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
