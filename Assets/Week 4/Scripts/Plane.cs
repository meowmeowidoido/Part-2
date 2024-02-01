using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector2> points;
    public float newPositionThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    private void Start()
    {
       lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position);
    }
    private void  OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1; 
        lineRenderer.SetPosition(0, transform.position);
    }
    

  private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(newPosition, lastPosition) > newPositionThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }

        }
    }
