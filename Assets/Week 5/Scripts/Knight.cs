using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 destination;
    Vector2 movement;
    public float speed = 3f;
    Rigidbody2D rigidbody;
    Animator animator;
    bool clickOnSelf = false;
    public float health;
    public float maxHealth = 5;
    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movement=destination-(Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.deltaTime);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !clickOnSelf)
        {
            destination =Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        animator.SetFloat("Movement", movement.magnitude);
    }

    private void OnMouseDown()
    { clickOnSelf = true;
      takeDamage(1);
        
    }

    private void OnMouseUp() {
        clickOnSelf = false;
    }

    void takeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health==0)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            animator.SetTrigger("TakeDamage");
        }
       
    }

}
