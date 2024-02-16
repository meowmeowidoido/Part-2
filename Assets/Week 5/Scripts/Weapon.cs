using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float timerSpawn;
   
    Vector2 moving = new Vector2(5, 0);
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collider)
    {
        collider.SendMessage("takeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
   
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +moving * Time.deltaTime);
    }

    private void Update()
    {
        timerSpawn += Time.deltaTime;
        if (timerSpawn > 5)
        {
            Destroy(gameObject);
            timerSpawn = 0;
        }
    }
   
}
