using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Runway : MonoBehaviour
{
    public int score;



    void Start()
    {

        score = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.OverlapPoint(collision.transform.position))

        { 
            score=score+1;
            print(score);

        }
    }
}
