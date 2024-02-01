using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector2> points;
    public float newPositionThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed;
    public AnimationCurve landing;
    float landingTimer;
    float randomPosition;
    float randomRotation;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteSpawner;
    
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteSpawner[Random.Range(0,4)];
        speed = Random.Range(1, 3);
        randomPosition = Random.Range(-5, 5);
        randomRotation = Random.Range(0, 360);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position);
        rigidbody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(randomPosition,randomPosition,0);
        transform.rotation = Quaternion.Euler(0, 0, randomRotation);
    }

    
    private void FixedUpdate()
    {
       
       currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }

        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.5f*Time.deltaTime;
            float interpolation= landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);

        }
        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPositionThreshold)
            {
                points.RemoveAt(0);
                for(int i =0; i < lineRenderer.positionCount-2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));

                }
                lineRenderer.positionCount--;
            }
        }
      
       
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


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        
        float tooClose = Vector3.Distance(gameObject.transform.position, collision.transform.position);
        
            print("too close");
            if (tooClose > -0.25)
            {

            spriteRenderer.color = Color.red;
             if(Vector2.Distance(transform.position, collision.transform.position) < 1.2f)//1.0f for planes to look like they actually collide
             {
                 Destroy(gameObject);
             }
            

        }
    }
    

    private void OnTriggerExit2D()
    {
        spriteRenderer.color = Color.white;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 3f);
    }


}
