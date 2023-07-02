using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinerenderScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform startPoint;

    private bool isDrawing = false;

    private void Update()
    {
        if (Phases.currentPhase == Phases.GamePhase.Aiming) 
        { 
            if (Input.touchCount > 0)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    DrawLine();
                }
            }

            if (Input.GetKey(KeyCode.T))
            {
                DrawLine();
            }
        }
    }

    private void DrawLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            lineRenderer.positionCount = 2;
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {


            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            /*Vector3 difference = mousePosition - lineRenderer.transform.position;
            Debug.Log(mousePosition);


            float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;*/

            //if (angle <= 92 && angle >= 0)
            Vector3 clampedMousePosition = new Vector3(Mathf.Clamp(mousePosition.x, gameObject.transform.position.x, float.PositiveInfinity), Mathf.Clamp(mousePosition.y, gameObject.transform.position.y, float.PositiveInfinity), 0);

            lineRenderer.SetPosition(1, clampedMousePosition);

            lineRenderer.SetPosition(0, startPoint.position);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            lineRenderer.positionCount = 0;
        }
    }
}
