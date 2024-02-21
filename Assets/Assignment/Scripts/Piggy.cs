using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

public class Piggy : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    Animator animator;
    float speed=50;
    bool move = false;
    bool inJail = false;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //mouseS
        if (move==true && inJail==false)
        {
            rigidbody.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition) *speed *Time.deltaTime);
        }
        }
        void Update()
    {
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), gameObject.transform.position);

        if(Input.GetMouseButtonDown(0)&& distance <0.45 ) {

            move = true;
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Healthy Hold");
        }
       // print(distance);//debugging
        if (Input.GetMouseButtonUp(0))
        {
           
            animator.SetTrigger("Idle");
            move = false;
            rigidbody.position.Set(-8, 0);
            
        }
        if (Input.GetMouseButton(1) && inJail==true)
        {
            animator.SetTrigger("Whack");
        }
       // print(distance);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       other.isTrigger = true;
        inJail = true;
        if(other.isTrigger)
        {
            Input.GetMouseButtonUp(0); 
         
            animator.SetTrigger("In Jail");
            Destroy(gameObject, 5);
        }
    }

}
