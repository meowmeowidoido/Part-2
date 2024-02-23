using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    Vector2 startingPosition;
    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = gameObject.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.ballScore += 1;
        gameObject.transform.position = startingPosition;
        rb.velocity = Vector2.zero;
    }
}
