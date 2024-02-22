using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor;

public class Piggy : MonoBehaviour
{
    //variables 
    public Rigidbody2D rigidbody;
    Animator animator;
    float speed=50;//speed variable
    bool move = false;
    bool inJail = false;
    // Start is called before the first frame update
    void Start()
    {
        //getting the components on the game object
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //allows the pigs to move when Move is true and when they are not in jail
        if (move==true && inJail==false)
        {
            rigidbody.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition) *speed *Time.deltaTime);
        }
        }
        void Update()
    {
        //checks the distances of the mouse positions and the gameobjects (pigs)
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), gameObject.transform.position);

        if(Input.GetMouseButtonDown(0)&& distance <0.45 ) {//if the LMB is pressed and the distance of the mouse and the pig is less than 0.45 then it will allow the player to move the pig

            move = true;
            animator.ResetTrigger("Idle");//resets the idle animation so it doesnt overlap the 
            animator.SetTrigger("Healthy Hold");//plays the healthy hold animation when the pig is grabbed
        }
       // print(distance);//debugging
        if (Input.GetMouseButtonUp(0))//when the mouse is released 
        {
           //set the trigger for the idle animation
            animator.SetTrigger("Idle");
            move = false;//Move becomes false
            rigidbody.position.Set(-8, 0);
            
        }
        if (Input.GetMouseButton(1) && inJail==true)//if the right mouse button is pressed
        {//and the pig is in jail, change their animation to badly damaged
            animator.SetTrigger("Nasty!");
        }
     

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       other.isTrigger = true;//when the trigger for the other game object (Holding Cell) is true
        inJail = true;//in jail becomes true not allowing the player to move the pig around 
        
        if(other.isTrigger)//if the other object detects a collision release the LMB and change the animation to in Jail and destroy the gameobject in five seconds
        {
            Input.GetMouseButtonUp(0);

           
            animator.SetTrigger("In Jail");
             
            Destroy(gameObject, 5);
        }
    }

}
