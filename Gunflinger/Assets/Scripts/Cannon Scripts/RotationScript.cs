using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationScript : MonoBehaviour
{
    Vector3 mousePosition;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Aiming)
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Check if finger is over a UI element
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }


            }
            //Debug Key: T
            if (Input.GetKey(KeyCode.T))
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            Vector3 difference = mousePosition - transform.position;

            float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(Mathf.Clamp(angle, 0, 90), Vector3.forward);
            Quaternion targetRotation = Quaternion.AngleAxis(Mathf.Clamp(angle, 0, 90), Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        }

    }

}
