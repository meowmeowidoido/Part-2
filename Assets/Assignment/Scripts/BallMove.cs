using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class BallMove : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public GameObject ball;
    Animator animator;
    float speed;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
       
        ball= GetComponent<GameObject>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //mouseS
        rigidbody.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition) * speed * Time.deltaTime);
    }
    void Update()
    {
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), gameObject.transform.position);

        if(Input.GetMouseButtonDown(0)&& distance <1) {

            speed = 50f;
            animator.SetTrigger("HealthyHold");
        }
        print(distance);//debugging
        if (Input.GetMouseButtonUp(0))
        {
            animator.ResetTrigger("HealthyHold");
            animator.SetTrigger("HealthyRelease");
            speed = 0;
            rigidbody.position.Set(-8, 0);
            
        }
    }


}
