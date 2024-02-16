using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    bool isDead = false;
    float screenTimer;
    public HealthBar healthBar;
    public SceneLoader sceneLoader;
    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
        health = PlayerPrefs.GetFloat("Health", maxHealth);
        healthBar.slider.value=PlayerPrefs.GetFloat("Health",health);
        SendMessage("takeDamage", 0, SendMessageOptions.DontRequireReceiver);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isDead) return;
        movement =destination-(Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.deltaTime);
    }
    void Update()
    {
        if (health != PlayerPrefs.GetFloat("Health", health)){//works without the if statement as well
            PlayerPrefs.SetFloat("Health", health);

        }
      
        if (isDead)
        {
            screenTimer += Time.deltaTime;
            if (screenTimer > 4)
            {

                sceneLoader.LoadNextScene();
                screenTimer = 0;
            }
            return;
        }
        
        if (Input.GetMouseButtonDown(0) && !clickOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination =Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        animator.SetFloat("Movement", movement.magnitude);
        if(Input.GetMouseButton(1) && !clickOnSelf)
        {
            attack();
        }
        
    }

    private void OnMouseDown()
    {
      if (isDead) return;
      clickOnSelf = true;
      SendMessage("takeDamage", 1);


    }

    private void OnMouseUp() {
        clickOnSelf = false;
    }

   public void takeDamage(float damage)
    {
        
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health==0)
        {
            isDead = true;
            animator.SetTrigger("Death");
            
            
          
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }
        rememberHealth(health);
       
    }
    void attack()
    {
        animator.SetTrigger("Attack");
    }

    public void rememberHealth(float storeHealth)
    {
        health = storeHealth;
  


    }
}
